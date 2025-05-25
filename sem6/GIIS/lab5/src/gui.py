import tkinter as tk
from .polygon import Polygon
from .convex_hull import graham_scan, jarvis_march
from .geometry_utils import point_in_polygon, line_intersection

class App:
    def __init__(self, root):
        self.root = root
        self.root.title("Графический редактор")
        self.canvas = tk.Canvas(root, width=800, height=600)
        self.canvas.pack()
        
        self.vertices = []
        self.polygon = Polygon()
        self.selected_points = []
        
        self.setup_ui()
        self.bind_events()

    def setup_ui(self):
        # Меню
        menubar = tk.Menu(self.root)
        
        # Построение выпуклых оболочек
        hull_menu = tk.Menu(menubar, tearoff=0)
        hull_menu.add_command(label="Метод Грэхема", command=self.build_graham)
        hull_menu.add_command(label="Метод Джарвиса", command=self.build_jarvis)
        menubar.add_cascade(label="Построение полигонов", menu=hull_menu)
        
        # Дополнительные функции
        func_menu = tk.Menu(menubar, tearoff=0)
        func_menu.add_command(label="Проверить выпуклость", command=self.check_convex)
        func_menu.add_command(label="Найти внутренние нормали", command=self.draw_normals)
        func_menu.add_command(label="Проверить точку в полигоне", command=self.enable_point_check)
        func_menu.add_command(label="Проверить пересечение отрезка", command=self.enable_line_check)
        menubar.add_cascade(label="Функции", menu=func_menu)
        
        self.root.config(menu=menubar)

    def bind_events(self):
        self.canvas.bind("<Button-1>", self.add_point)
        self.root.bind("<Escape>", lambda e: self.clear_canvas())

    def add_point(self, event):
        x, y = event.x, event.y
        self.vertices.append((x, y))
        self.draw_polygon()
        self.draw_points()

    def draw_polygon(self):
        self.canvas.delete("polygon")
        if len(self.vertices) >= 2:
            for i in range(len(self.vertices)-1):
                self.canvas.create_line(self.vertices[i], self.vertices[i+1], tags="polygon")
        if len(self.vertices) >= 3:
            self.canvas.create_line(self.vertices[-1], self.vertices[0], tags="polygon")

    def draw_points(self):
        self.canvas.delete("points")
        for x, y in self.vertices:
            self.canvas.create_oval(x-3, y-3, x+3, y+3, fill="red", tags="points")

    def clear_canvas(self):
        self.vertices = []
        self.selected_points = []
        self.canvas.delete("all")

    def build_graham(self):
        if len(self.vertices) < 3:
            return
        self.vertices = graham_scan(self.vertices)
        self.draw_polygon()
        self.draw_points()

    def build_jarvis(self):
        if len(self.vertices) < 3:
            return
        self.vertices = jarvis_march(self.vertices)
        self.draw_polygon()
        self.draw_points()

    def check_convex(self):
        if len(self.vertices) < 3:
            print("Нужно минимум 3 точки")
            return
        self.polygon.set_vertices(self.vertices)
        if self.polygon.is_convex():
            print("Полигон выпуклый")
        else:
            print("Полигон невыпуклый")

    def draw_normals(self):
        if len(self.vertices) < 3:
            return
        self.polygon.set_vertices(self.vertices)
        normals = self.polygon.get_normals()
        self.canvas.delete("normals")
        for start, end in normals:
            self.canvas.create_line(start, end, arrow=tk.LAST, tags="normals")

    def enable_point_check(self):
        self.canvas.bind("<Button-1>", self.check_point_in_polygon)
        print("Выберите точку для проверки")

    def check_point_in_polygon(self, event):
        point = (event.x, event.y)
        if point_in_polygon(point, self.vertices):
            print(f"Точка {point} находится внутри полигона")
        else:
            print(f"Точка {point} находится вне полигона")
        self.canvas.unbind("<Button-1>")

    def enable_line_check(self):
        self.canvas.bind("<Button-1>", self.select_line_point)
        self.selected_points = []
        print("Выберите две точки для отрезка")

    def select_line_point(self, event):
        self.selected_points.append((event.x, event.y))
        if len(self.selected_points) == 2:
            self.check_line_intersection(self.selected_points)
            self.selected_points = []
            self.canvas.unbind("<Button-1>")

    def check_line_intersection(self, line_points):
        line1 = (line_points[0], line_points[1])
        intersections = []
        
        for i in range(len(self.vertices)):
            a = self.vertices[i]
            b = self.vertices[(i+1) % len(self.vertices)]
            line2 = (a, b)
            pt = line_intersection(line1, line2)
            if pt:
                intersections.append(pt)
        
        self.canvas.delete("intersections")
        for x, y in intersections:
            self.canvas.create_oval(x-3, y-3, x+3, y+3, fill="blue", tags="intersections")
        
        print(f"Найдено {len(intersections)} точек пересечения: {intersections}")