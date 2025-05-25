import math
from .geometry_utils import cross_product

class Polygon:
    def __init__(self, vertices=None):
        self.vertices = vertices or []

    def set_vertices(self, vertices):
        self.vertices = vertices

    def is_convex(self):
        n = len(self.vertices)
        if n < 3:
            return False

        prev = 0
        for i in range(n):
            a = self.vertices[i]
            b = self.vertices[(i+1) % n]
            c = self.vertices[(i+2) % n]

            ab = (b[0] - a[0], b[1] - a[1])
            bc = (c[0] - b[0], c[1] - b[1])

            cross_val = cross_product(ab, bc)

            if cross_val == 0:
                continue

            if prev == 0:
                prev = cross_val
            elif (cross_val > 0) != (prev > 0):
                return False

        return True

    def get_normals(self):
        normals = []
        if len(self.vertices) < 2:
            return normals

        area = 0.0
        for i in range(len(self.vertices)):
            x1, y1 = self.vertices[i]
            x2, y2 = self.vertices[(i + 1) % len(self.vertices)]
            area += (x1 * y2) - (x2 * y1)  # Формула площади многоугольника
        area /= 2.0

        for i in range(len(self.vertices)):
            a = self.vertices[i]
            b = self.vertices[(i + 1) % len(self.vertices)]

            dx = b[0] - a[0]
            dy = b[1] - a[1]

            normal = (dy, -dx) if area < 0 else (-dy, dx)
            length = (normal[0] ** 2 + normal[1] ** 2) ** 0.5
            if length == 0:
                continue

            scale = 10 / length  # Скалируем до длины 10 пикселей
            nx = normal[0] * scale
            ny = normal[1] * scale

            mid_x = (a[0] + b[0]) / 2
            mid_y = (a[1] + b[1]) / 2

            normals.append(((mid_x, mid_y), (mid_x + nx, mid_y + ny)))

        return normals