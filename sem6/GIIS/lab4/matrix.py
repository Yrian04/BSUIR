import math
import itertools

class Point3D:
    def __init__(self, x, y, z, w=1.0):
        self.x = float(x)
        self.y = float(y)
        self.z = float(z)
        self.w = float(w)
    
    def to_homogeneous(self):
        return [self.x, self.y, self.z, self.w]
    
    @staticmethod
    def from_homogeneous(coords):
        w = coords[3]
        if w == 0:
            return Point3D(coords[0], coords[1], coords[2])
        return Point3D(coords[0]/w, coords[1]/w, coords[2]/w, 1.0)
    
    # Оператор вычитания
    def __sub__(self, other):
        if isinstance(other, Point3D):
            return Point3D(
                self.x - other.x,
                self.y - other.y,
                self.z - other.z,
                self.w - other.w
            )
        raise TypeError("Нельзя вычесть не-Point3D")
    
    # Оператор сложения
    def __add__(self, other):
        if isinstance(other, Point3D):
            return Point3D(
                self.x + other.x,
                self.y + other.y,
                self.z + other.z,
                self.w + other.w
            )
        raise TypeError("Нельзя сложить с не-Point3D")
    
    # Оператор умножения на скаляр
    def __mul__(self, scalar):
        if isinstance(scalar, (int, float)):
            return Point3D(
                self.x * scalar,
                self.y * scalar,
                self.z * scalar,
                self.w
            )
        raise TypeError("Умножение на не-число")
    
    # Оператор обратного умножения (число * точка)
    def __rmul__(self, scalar):
        return self.__mul__(scalar)
    
    # Нормализация вектора
    def normalize(self):
        length = math.sqrt(self.x**2 + self.y**2 + self.z**2)
        if length == 0:
            return Point3D(0, 0, 0)
        return Point3D(
            self.x / length,
            self.y / length,
            self.z / length,
            self.w
        )
    
    # Векторное произведение
    def cross(self, other):
        return Point3D(
            self.y * other.z - self.z * other.y,
            self.z * other.x - self.x * other.z,
            self.x * other.y - self.y * other.x
        )

class Matrix:
    def __init__(self, data):
        self.data = data
        self.rows = len(data)
        self.cols = len(data[0]) if self.rows > 0 else 0
    
    def __mul__(self, other):
        if isinstance(other, Matrix):
            if self.cols != other.rows:
                raise ValueError("Несовместимые размеры матриц")
            result = [[0]*other.cols for _ in range(self.rows)]
            for i in range(self.rows):
                for j in range(other.cols):
                    for k in range(self.cols):
                        result[i][j] += self.data[i][k] * other.data[k][j]
            return Matrix(result)
        
        elif isinstance(other, (list, tuple)):
            if self.cols != len(other):
                raise ValueError("Несовместимые размеры")
            result = [0] * self.rows
            for i in range(self.rows):
                for j in range(self.cols):
                    result[i] += self.data[i][j] * other[j]
            return result
        
        elif isinstance(other, (int, float)):
            return Matrix([[self.data[i][j] * other 
                           for j in range(self.cols)] 
                           for i in range(self.rows)])
        
        raise TypeError("Неподдерживаемый тип операнда")

    @staticmethod
    def identity(size):
        return Matrix([[1 if i == j else 0 for j in range(size)] 
                       for i in range(size)])

def translation_matrix(dx, dy, dz):
    return Matrix([
        [1, 0, 0, dx],
        [0, 1, 0, dy],
        [0, 0, 1, dz],
        [0, 0, 0, 1]
    ])

def scaling_matrix(sx, sy, sz):
    return Matrix([
        [sx, 0, 0, 0],
        [0, sy, 0, 0],
        [0, 0, sz, 0],
        [0, 0, 0, 1]
    ])

def rotation_x_matrix(angle_deg):
    rad = math.radians(angle_deg)
    cos = math.cos(rad)
    sin = math.sin(rad)
    return Matrix([
        [1, 0, 0, 0],
        [0, cos, -sin, 0],
        [0, sin, cos, 0],
        [0, 0, 0, 1]
    ])

def rotation_y_matrix(angle_deg):
    rad = math.radians(angle_deg)
    cos = math.cos(rad)
    sin = math.sin(rad)
    return Matrix([
        [cos, 0, sin, 0],
        [0, 1, 0, 0],
        [-sin, 0, cos, 0],
        [0, 0, 0, 1]
    ])

def rotation_z_matrix(angle_deg):
    rad = math.radians(angle_deg)
    cos = math.cos(rad)
    sin = math.sin(rad)
    return Matrix([
        [cos, -sin, 0, 0],
        [sin, cos, 0, 0],
        [0, 0, 1, 0],
        [0, 0, 0, 1]
    ])

def reflection_matrix(axis):
    if axis == 'x':
        return Matrix([
            [-1, 0, 0, 0],
            [0, 1, 0, 0],
            [0, 0, 1, 0],
            [0, 0, 0, 1]
        ])
    elif axis == 'y':
        return Matrix([
            [1, 0, 0, 0],
            [0, -1, 0, 0],
            [0, 0, 1, 0],
            [0, 0, 0, 1]
        ])
    elif axis == 'z':
        return Matrix([
            [1, 0, 0, 0],
            [0, 1, 0, 0],
            [0, 0, -1, 0],
            [0, 0, 0, 1]
        ])

def perspective_matrix(fov_y, aspect, near, far):
    f = 1.0 / math.tan(math.radians(fov_y)/2)
    return Matrix([
        [f/aspect, 0, 0, 0],
        [0, f, 0, 0],
        [0, 0, (far + near)/(near - far), (2 * far * near)/(near - far)],
        [0, 0, -1, 0]
    ])