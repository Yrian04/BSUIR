import time
from src.utils.helpers import is_point_inside_polygon

def floodfill(x, y, target_color, fill_color, canvas, polygon, debug=False):
    """Запуск затравки с проверкой на принадлежность полигону"""
    print('floodfill')
    if (not is_point_inside_polygon((x, y), polygon) or 
        canvas.get_pixel(x, y) != target_color):
        return
    
    stack = [(x, y)]
    while stack:
        cx, cy = stack.pop()
        if (canvas.get_pixel(cx, cy) == target_color and 
            is_point_inside_polygon((cx, cy), polygon)):
            canvas.set_pixel(cx, cy, fill_color)
            if debug:
                canvas.update()
                time.sleep(0.1)
            for dx, dy in [(-1,0), (1,0), (0,-1), (0,1)]:
                nx, ny = cx + dx, cy + dy
                if (0 <= nx < canvas.width and 
                    0 <= ny < canvas.height and 
                    canvas.get_pixel(nx, ny) == target_color and 
                    is_point_inside_polygon((nx, ny), polygon)):
                    stack.append((nx, ny))