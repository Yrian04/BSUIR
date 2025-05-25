import tkinter as tk
import time
from src.algorithms.rasterizer import rasterize_polygon
from src.algorithms.floodfill import floodfill
from src.algorithms.line_floodfill import line_floodfill
from src.utils.helpers import is_point_inside_polygon

class DrawingCanvas(tk.Canvas):
    def __init__(self, parent, width=800, height=600):
        super().__init__(parent, width=width, height=height)
        self.width = width
        self.height = height
        self.current_poly = []
        self.polygons = []
        self.bind("<Button-1>", self.add_vertex)
        self.bind("<Double-Button-1>", self.finish_polygon)
        
        # Инициализация алгоритма и отладки
        self.algorithm = "raster"
        self.debug = False
        
        self.pixels = [[None for _ in range(self.height)] for _ in range(self.width)]
        
    def add_vertex(self, event):
        self.current_poly.append((event.x, event.y))
        self.create_oval(event.x-2, event.y-2, event.x+2, event.y+2, fill="black")
        
    def finish_polygon(self, event):
        if len(self.current_poly) >= 3:
            self.polygons.append(self.current_poly.copy())
            self.create_line(self.current_poly + [self.current_poly[0]], fill="black")
        self.current_poly = []
        
    def set_pixel(self, x, y, color):
        if 0 <= x < self.width and 0 <= y < self.height:
            if self.pixels[x][y] != color:
                self.pixels[x][y] = color
                self.create_rectangle(x, y, x+1, y+1, fill=color, outline='')
                
    def get_pixel(self, x, y):
        return self.pixels[x][y] if 0 <= x < self.width and 0 <= y < self.height else None
                
    def fill_polygon(self, polygon, color):
        if not polygon:
            return
        if self.debug:
            self.master.update_idletasks()
            time.sleep(0.01)
            
        if self.algorithm == "raster":
            rasterize_polygon(polygon, self, debug=self.debug)
        elif self.algorithm == "floodfill":
            # Поиск точки внутри полигона
            centroid_x = sum(p[0] for p in polygon) // len(polygon)
            centroid_y = sum(p[1] for p in polygon) // len(polygon)
            
            # Убедимся, что точка внутри
            while not is_point_inside_polygon((centroid_x, centroid_y), polygon):
                # Смещаем точку в случайном направлении
                centroid_x += 1
                centroid_y += 1
                if centroid_x >= self.width or centroid_y >= self.height:
                    break
            
            target_color = self.get_pixel(centroid_x, centroid_y)
            if target_color == color:
                return  # Если уже заполнено
            
            # Запускаем затравку с передачей полигона
            floodfill(
                centroid_x, centroid_y,
                target_color,
                color,
                self,
                polygon,  # Передаем полигон для проверки
                debug=self.debug
            )
        elif self.algorithm == "line_floodfill":
            line_floodfill(
                polygon,
                color,
                self,
                debug=self.debug  # Передаем debug
            )
    
    def update(self):
        self.update_idletasks()