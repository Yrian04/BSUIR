def is_point_inside_polygon(point, polygon):
    """Улучшенная проверка принадлежности точке полигону"""
    x, y = point
    n = len(polygon)
    inside = False
    p1x, p1y = polygon[0]
    
    for i in range(n + 1):
        p2x, p2y = polygon[i % n]
        if y > min(p1y, p2y):
            if y <= max(p1y, p2y):
                if x <= max(p1x, p2x):
                    if p1y != p2y:
                        xints = (y - p1y) * (p2x - p1x) / (p2y - p1y) + p1x
                    if p1x == p2x or x <= xints:
                        inside = not inside
        p1x, p1y = p2x, p2y
    return inside

def is_edge(point, polygon):
    for i in range(len(polygon)):
        p1 = polygon[i]
        p2 = polygon[(i+1)%len(polygon)]
        if (point == p1) or (point == p2) or is_between(point, p1, p2):
            return True
    return False

def is_between(p, a, b):
    # Проверка, лежит ли точка p на отрезке ab
    return (min(a[0], b[0]) <= p[0] <= max(a[0], b[0])) and \
           (min(a[1], b[1]) <= p[1] <= max(a[1], b[1])) and \
           ( (p[0] - a[0])*(b[1] - a[1]) == (b[0] - a[0])*(p[1] - a[1]) )