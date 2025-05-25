import math
from .geometry_utils import cross_product, distance

def cross(o, a, b):
    return (a[0] - o[0]) * (b[1] - o[1]) - (a[1] - o[1]) * (b[0] - o[0])

def graham_scan(points):
    if len(points) < 3:
        return []
    
    # Нахождение начальной точки
    start = min(points, key=lambda p: (p[1], p[0]))
    
    # Сортировка точек по полярному углу
    def polar_angle(p):
        return math.atan2(p[1] - start[1], p[0] - start[0])
    
    points_sorted = sorted(points, key=polar_angle)
    
    # Удаление коллинеарных точек, оставляя самые дальние
    i = 1
    while i < len(points_sorted):
        if polar_angle(points_sorted[i]) == polar_angle(points_sorted[i-1]):
            if distance(start, points_sorted[i]) < distance(start, points_sorted[i-1]):
                points_sorted.pop(i)
            else:
                points_sorted.pop(i-1)
        else:
            i += 1
    
    if len(points_sorted) < 3:
        return []
    
    # Построение выпуклой оболочки
    stack = [points_sorted[0], points_sorted[1], points_sorted[2]]
    
    for i in range(3, len(points_sorted)):
        while len(stack) > 1 and cross(stack[-2], stack[-1], points_sorted[i]) <= 0:
            stack.pop()
        stack.append(points_sorted[i])
    
    return stack

def jarvis_march(points):
    if len(points) < 3:
        return []
    
    # Нахождение самой левой точки
    leftmost = min(points, key=lambda p: p[0])
    
    hull = []
    current = leftmost
    
    while True:
        hull.append(current)
        next_point = None
        
        for point in points:
            if point == current:
                continue
            
            if next_point is None:
                next_point = point
                continue
            
            val = cross(hull[-1], next_point, point)
            if val > 0 or (val == 0 and distance(hull[-1], point) > distance(hull[-1], next_point)):
                next_point = point
        
        current = next_point
        
        if current == hull[0]:
            break
    
    return hull