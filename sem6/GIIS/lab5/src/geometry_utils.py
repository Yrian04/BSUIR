import math

def cross_product(v1, v2):
    return v1[0] * v2[1] - v1[1] * v2[0]

def distance(p1, p2):
    return (p1[0] - p2[0])**2 + (p1[1] - p2[1])**2

def point_in_polygon(point, polygon):
    x, y = point
    inside = False
    n = len(polygon)
    
    if n < 3:
        return False
    
    p1x, p1y = polygon[0]
    for i in range(n + 1):
        p2x, p2y = polygon[i % n]
        if y > min(p1y, p2y) and y <= max(p1y, p2y) and x <= max(p1x, p2x):
            if p1y != p2y:
                xints = (y - p1y) * (p2x - p1x) / (p2y - p1y) + p1x
            if p1x == p2x or x <= xints:
                inside = not inside
        p1x, p1y = p2x, p2y
    return inside

def line_intersection(line1, line2):
    p0_x, p0_y = line1[0]
    p1_x, p1_y = line1[1]
    p2_x, p2_y = line2[0]
    p3_x, p3_y = line2[1]
    
    s10_x = p1_x - p0_x
    s10_y = p1_y - p0_y
    s32_x = p3_x - p2_x
    s32_y = p3_y - p2_y
    
    denom = s10_x * s32_y - s32_x * s10_y
    if denom == 0:
        return None  # Параллельные или совпадающие
    
    denom_positive = denom > 0
    
    s02_x = p0_x - p2_x
    s02_y = p0_y - p2_y
    
    s_numer = s10_x * s02_y - s10_y * s02_x
    if (s_numer < 0) == denom_positive:
        return None  # Пересечение вне первого отрезка
    
    t_numer = s32_x * s02_y - s32_y * s02_x
    if (t_numer < 0) == denom_positive:
        return None  # Пересечение вне второго отрезка
    
    if (s_numer > denom) == denom_positive or (t_numer > denom) == denom_positive:
        return None  # Пересечение вне отрезков
    
    t = t_numer / denom
    intersection_x = p0_x + (t * s10_x)
    intersection_y = p0_y + (t * s10_y)
    
    return (intersection_x, intersection_y)