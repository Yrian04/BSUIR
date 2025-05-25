import tkinter as tk
from tkinter import ttk
from idlelib.tooltip import Hovertip

from .services import FilteredSearchService


class ManagerApp:
    def __init__(
        self,
        search_service: FilteredSearchService,
    ) -> None:
        self.root = tk.Tk()
        self.search_service = search_service

        self.build()
    
    def build(self):
        self.root.title("Corpus Manager")
        # self.root.geometry("2300x1800")

        style = ttk.Style()
        style.theme_use("clam")
        style.configure("Treeview", rowheight=40)

        ttk.Label(
            self.root,
            text="Query:"
        ).pack(pady=10)

        self.entry_var = tk.StringVar()
        entry = ttk.Entry(self.root, textvariable=self.entry_var)
        entry.pack()
        Hovertip(
            entry, 
            ("Type your query here to get results. Query must be a "
            "word wordforms of which you would like to find.")
        )

        ttk.Label(
            self.root,
            text="POS:"
        ).pack(pady=10)

        self.pos_var = tk.StringVar()
        entry = ttk.Entry(self.root, textvariable=self.pos_var)
        entry.pack()
        Hovertip(
            entry, 
            "Type your path of speech here to get results " \
            "with that path of speech."
        )

        srch = ttk.Button(
            self.root, 
            text="Search", 
            command=self.search
        )
        srch.pack(pady=10)
        Hovertip(
            srch, 
            ("Press this button to get results from the corpus. "
            "Before pressing this button you should type something "
            "in the input above.")
        )
        
        score_frame = ttk.Frame(self.root)
        score_frame.pack(pady=10)

        ttk.Label(
            score_frame, 
            text="Number of occurences: "
        ).pack(pady=10, side='left')

        self.score_numb = tk.StringVar()
        ttk.Label(
            score_frame, 
            textvariable=self.score_numb, 
        ).pack(pady=10, side='left')

        ttk.Label(
            self.root,
            text="Search results:"
        ).pack(pady=10)
        
        container = ttk.Frame(self.root)
        container.pack(fill='both', expand=True)

        canvas = tk.Canvas(container)
        scrollbar = ttk.Scrollbar(container, orient="vertical", command=canvas.yview)

        self.tables_frame = ttk.Frame(canvas)
        self.tables_frame.pack(pady=10, fill='both', expand=True)

        self.tables_frame.bind(
            "<Configure>",
            lambda e: canvas.configure(
                scrollregion=canvas.bbox("all")
            )
        )

        canvas.create_window((0, 0), window=self.tables_frame, anchor="nw")
        canvas.configure(yscrollcommand=scrollbar.set)
        canvas.pack(side="left", fill="both", expand=True)
        scrollbar.pack(side="right", fill="y")

        # Table 1
        # Создаем фрейм для таблицы
        self.table_frame = ttk.Frame(self.tables_frame)
        self.table_frame.pack(pady=10, fill='both', side='top', expand=True)

        columns=("Wordform", "Lemma", "POS", "Link")
        # Создаем Treeview с 4 колонками
        self.tree = ttk.Treeview(
            self.table_frame, 
            columns=columns, 
            show="headings", 
            height=20
        )

        # Настраиваем колонки
        for col in columns:
            self.tree.heading(col, text=col)
            self.tree.column(col)
            
        # Создаем вертикальный скроллбар
        scrollbar = ttk.Scrollbar(
            self.table_frame, 
            orient="vertical", 
            command=self.tree.yview  # Связываем с Treeview по вертикали
        )

        # Привязываем скроллбар к Treeview
        self.tree.configure(yscrollcommand=scrollbar.set)

        # Упаковываем элементы
        self.tree.pack(side="left", fill="x", expand=True)  # Таблица слева
        scrollbar.pack(side="right", fill="y")    # Скроллбар справа
        Hovertip(
            self.tree, 
            ("In this table you can see the results of a search. Wordform "
             "is a specific wordform entry from the table, lemma is lemma\n"
             "of that specific wordform, POS stands for part of speech and "
             "link is a link to the movie where this specific wordform was used.")
        )

        # Table 2
        self.sent_table_frame = ttk.Frame(self.tables_frame)
        self.sent_table_frame.pack(pady=10, fill='x', expand=True, side='top')

        columns=("Sentence", "Link")
        self.sent_tree = ttk.Treeview(
            self.sent_table_frame, 
            columns=columns, 
            show="headings", 
            height=20
        )

        for col in columns:
            self.sent_tree.heading(col, text=col)
            self.sent_tree.column(col)
            
        scrollbar = ttk.Scrollbar(
            self.sent_table_frame, 
            orient="vertical", 
            command=self.sent_tree.yview
        )

        self.sent_tree.configure(yscrollcommand=scrollbar.set)

        self.sent_tree.pack(side="left", fill="x", expand=True)
        scrollbar.pack(side="right", fill="y")

    def search(self):
        from .schemas import SentenceSearchResult
        word = self.entry_var.get()
        pos = self.pos_var.get()
        pos = None if pos == '' else pos
        result: SentenceSearchResult = self.search_service.search(word, pos)
        self.score_numb.set(result.count)

        # Clear existing data
        for item in self.tree.get_children():
            self.tree.delete(item)

        for item in self.sent_tree.get_children():
            self.sent_tree.delete(item)

        # Insert new data
        for word_form in result.word_forms:
            self.tree.insert("", "end", values=(
                word_form.word,
                word_form.lemma,
                word_form.pos,
                word_form.document_title
            ))
        

        for sent in result.sentences:
            self.sent_tree.insert("", "end", values=(
                sent.content,
                sent.document_title
            ))
    
    def run(self) -> None:
        self.root.mainloop()
