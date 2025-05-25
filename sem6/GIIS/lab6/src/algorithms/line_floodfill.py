import time
from src.utils.helpers import is_point_inside_polygon
from .floodfill import floodfill


def line_floodfill(polygon, color, canvas, debug=False):
    min_y = min(p[1] for p in polygon)
    max_y = max(p[1] for p in polygon)
    
    for y in range(min_y, max_y + 1):
        intersections = []  # Список x-координат пересечений ребер с линией y
        
        # Находим пересечения всех ребер с текущей горизонтальной линией
        for i in range(len(polygon)):
            p1 = polygon[i]
            p2 = polygon[(i + 1) % len(polygon)]
            
            y1, y2 = p1[1], p2[1]
            
            # Если ребро пересекает линию y
            if (y1 < y and y2 >= y) or (y2 < y and y1 >= y):
                # Вычисляем x пересечения
                x = p1[0] + (y - p1[1]) * (p2[0] - p1[0]) / (p2[1] - p1[1])
                intersections.append(x)
        
        # Сортируем пересечения по x
        intersections.sort()
        
        # Запускаем затравку между парами x
        for i in range(0, len(intersections), 2):
            if i + 1 >= len(intersections):
                continue  # Пропускаем, если нечетное количество точек
            
            x_start = int(intersections[i])
            x_end = int(intersections[i + 1])
            mid_x = (x_start + x_end) // 2  # Берем среднюю точку
            
            # Проверяем, что точка внутри полигона
            if is_point_inside_polygon((mid_x, y), polygon):
                current_color = canvas.get_pixel(mid_x, y)
                if current_color != color:
                    floodfill(
                        mid_x, y,
                        current_color,  # Текущий цвет пикселя
                        color,
                        canvas,
                        polygon,
                        debug=debug
                    )
                    if debug:
                        time.sleep(0.1)