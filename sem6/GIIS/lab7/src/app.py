import tkinter as tk
import matplotlib.tri as tri
import matplotlib.pyplot as plt
from scipy.spatial import Voronoi, voronoi_plot_2d

class DelaunayVoronoiApp:
    def __init__(self, master):
        self.master = master
        master.title("Триангуляция Делоне и Диаграмма Вороного")

        self.canvas_width = 600
        self.canvas_height = 400
        self.canvas = tk.Canvas(master, width=self.canvas_width, height=self.canvas_height, bg="white")
        self.canvas.pack()

        self.points = [] 
        self.point_radius = 3 

        self.canvas.bind("<Button-1>", self.add_point)

        self.clear_button = tk.Button(master, text="Очистить", command=self.clear_canvas)
        self.clear_button.pack()

        self.menubar = tk.Menu(master)

        self.toolsmenu = tk.Menu(self.menubar, tearoff=0)
        self.toolsmenu.add_command(label="Триангуляция Делоне", command=self.delaunay_triangulation)
        self.toolsmenu.add_command(label="Диаграмма Вороного", command=self.voronoi_diagram)

        self.menubar.add_cascade(label="Инструменты", menu=self.toolsmenu)

        master.config(menu=self.menubar)

    def add_point(self, event):
        x, y = event.x, event.y
        self.points.append((x, y))
        self.canvas.create_oval(x - self.point_radius, y - self.point_radius,
                                 x + self.point_radius, y + self.point_radius,
                                 fill="black", tag="point")

    def delaunay_triangulation(self):
        if len(self.points) < 3:
            print("Нужно больше точек для триангуляции!")
            return

        self.canvas.delete("delaunay")

        try:
            x = [p[0] for p in self.points]
            y = [p[1] for p in self.points]
            triangulation = tri.Triangulation(x, y)

            for triangle in triangulation.triangles:
                x1, y1 = x[triangle[0]], y[triangle[0]]
                x2, y2 = x[triangle[1]], y[triangle[1]]
                x3, y3 = x[triangle[2]], y[triangle[2]]
                self.canvas.create_polygon(x1, y1, x2, y2, x3, y3, outline="blue", tag="delaunay")

        except Exception as e:
            print(f"Ошибка триангуляции Делоне: {e}")

    def voronoi_diagram(self):
        if len(self.points) < 3:
            print("Нужно больше точек для диаграммы Вороного!")
            return

        try:
            points_array = [[p[0], p[1]] for p in self.points]  
            vor = Voronoi(points_array)

            fig, ax = plt.subplots()
            voronoi_plot_2d(vor, ax, show_vertices=False, line_colors='red', line_width=2, line_alpha=0.6)
            ax.set_xlim(0, self.canvas_width)
            ax.set_ylim(0, self.canvas_height)
            plt.show()

        except Exception as e:
            print(f"Ошибка при построении диаграммы Вороного: {e}")

    def clear_canvas(self):
        self.points = []
        self.canvas.delete("all")