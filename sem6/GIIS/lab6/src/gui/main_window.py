import tkinter as tk
from tkinter import ttk
from .canvas_widget import DrawingCanvas  # Убедитесь в правильном пути

class MainWindow(tk.Tk):
    def __init__(self):
        super().__init__()
        self.title("Графический редактор")
        # self.geometry("800x600")  # Восстановите размер
        
        self.menu_bar = tk.Menu(self)
        self.algorithm_menu = tk.Menu(self.menu_bar, tearoff=0)
        self.algorithm_menu.add_command(
            label="Растровая развертка",
            command=lambda: self.set_algorithm("raster")
        )
        self.algorithm_menu.add_command(
            label="Затравка",
            command=lambda: self.set_algorithm("floodfill")
        )
        self.algorithm_menu.add_command(
            label="Построчная затравка",
            command=lambda: self.set_algorithm("line_floodfill")
        )
        self.menu_bar.add_cascade(label="Алгоритмы", menu=self.algorithm_menu)
        
        self.debug_var = tk.BooleanVar()
        self.menu_bar.add_checkbutton(
            label="Режим отладки",
            variable=self.debug_var,
            command=self.update_debug_flag  # Привяжите к методу
        )
        self.config(menu=self.menu_bar)
        
        self.canvas = DrawingCanvas(self, width=800, height=600)
        self.canvas.pack(side=tk.TOP, fill=tk.BOTH, expand=True)
        
        self.current_algorithm = "raster"
        
        self.fill_button = ttk.Button(
            self,
            text="Заполнить",
            command=self.fill_last_polygon
        )
        self.fill_button.pack(side=tk.BOTTOM, pady=10)
        
        # Синхронизация флага отладки
        self.debug_var.trace("w", self.update_debug_flag)
        
    def update_debug_flag(self, *args):
        self.canvas.debug = self.debug_var.get()
        
    def set_algorithm(self, algorithm):
        """Обновляет алгоритм в canvas"""
        self.current_algorithm = algorithm
        self.canvas.algorithm = algorithm  # Ключевая строка!
        
    def fill_last_polygon(self):
        if self.canvas.polygons:
            polygon = self.canvas.polygons[-1]
            self.canvas.fill_polygon(polygon, "red")