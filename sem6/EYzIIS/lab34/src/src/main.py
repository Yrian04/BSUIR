import tkinter as tk
from tkinter import filedialog, ttk
import tkinter.messagebox as messagebox
from idlelib.tooltip import Hovertip
import webbrowser
import subprocess
import pypandoc

# Импорты из наших модулей
from .syntactic_analysis import SyntacticAnalyzer, generate_syntactic_html
from .semantic_analysis import SemanticAnalysis, generate_semantic_html

class TextAnalyzerApp(tk.Tk):
    def __init__(self):
        super().__init__()
        self.title("Русский Анализатор Текста")
        self.geometry("800x600")
        self.file_path = tk.StringVar()
        self.analysis_type = tk.StringVar(value="syntax")

        self.create_widgets()

    def create_widgets(self):
        # Заголовок
        ttk.Label(self, text="Анализатор текста", font=("Arial", 14)).pack(pady=20)

        # Поле выбора файла
        file_frame = ttk.Frame(self)
        file_frame.pack(pady=10, padx=20, fill=tk.X)

        ttk.Label(file_frame, text="Выберите файл:").pack(side=tk.LEFT)
        self.file_entry = ttk.Entry(file_frame, textvariable=self.file_path, state="readonly", width=50)
        self.file_entry.pack(side=tk.LEFT, padx=10, fill=tk.X, expand=True)

        select_btn = ttk.Button(file_frame, text="Выбрать файл", command=self.select_file)
        Hovertip(select_btn, "Выберите файл для анализа (.txt, .rtf)")
        select_btn.pack(side=tk.RIGHT)

        # Выбор типа анализа
        analysis_frame = ttk.Frame(self)
        analysis_frame.pack(pady=15, padx=20, fill=tk.X)

        ttk.Label(analysis_frame, text="Тип анализа:").pack(side=tk.LEFT)
        ttk.Radiobutton(analysis_frame, text="Синтаксический", variable=self.analysis_type, value="syntax").pack(side=tk.LEFT, padx=10)
        ttk.Radiobutton(analysis_frame, text="Семантический", variable=self.analysis_type, value="semantic").pack(side=tk.LEFT, padx=10)

        # Кнопка анализа
        self.analyze_btn = ttk.Button(self, text="Анализировать", command=self.analyze_file, style="Accent.TButton")
        Hovertip(self.analyze_btn, "Запустить выбранный тип анализа")
        self.analyze_btn.pack(pady=30, padx=20, fill=tk.X)

    def select_file(self):
        path = filedialog.askopenfilename(
            title="Выбор файла",
            filetypes=[("Текстовые файлы", "*.txt *.rtf"), ("Все файлы", "*.*")]
        )
        if path:
            self.file_path.set(path)

    def analyze_file(self):
        path = self.file_path.get()
        if not path:
            return

        try:
            # Попытка чтения RTF через subprocess + unrtf
            if path.endswith('.rtf'):
                result = subprocess.run(
                    ['unrtf', '--html', path],
                    # capture_output=True,
                    # check=True,
                    # text=True,
                    stdout=subprocess.PIPE
                )
                with open("temp.html", "w") as f:
                    f.write(result.stdout.decode('utf-8'))
                text = pypandoc.convert_file("temp.html", 'plain')
            else:
                # Для текстовых файлов
                with open(path, 'r', encoding='utf-8', errors='replace') as f:
                    text = f.read()
        except Exception as e:
            tk.messagebox.showerror("Ошибка", f"Не удалось прочитать файл: {str(e)}")
            return

        print(text)

        # Выбор типа анализа
        analysis_type = self.analysis_type.get()
        if analysis_type == "syntax":
            analyzer = SyntacticAnalyzer(text)
            html_content = generate_syntactic_html(analyzer)
        else:
            analyzer = SemanticAnalysis(text)
            html_content = generate_semantic_html(analyzer)

        # Сохранение и открытие файла
        filename = f'{path}-{analysis_type}.html'
        with open(filename, "w") as f:
            f.write(html_content)
            webbrowser.open("file://" + filename)

# Настройка стилей
def setup_styles():
    style = ttk.Style()
    style.configure("TButton", padding=6, relief="flat", background="#3498db")
    style.map("TButton",
             foreground=[('active', '!disabled', 'white')],
             background=[('active', '!disabled', '#2980b9')])
    style.configure("Accent.TButton", 
                   background="#2ecc71", 
                   foreground="white",
                   font=("Arial", 12))
    style.map("Accent.TButton",
             background=[('active', '#27ae60')])

if __name__ == "__main__":
    app = TextAnalyzerApp()
    setup_styles()
    app.mainloop()