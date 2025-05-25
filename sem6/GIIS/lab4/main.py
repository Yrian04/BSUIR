import pygame
import sys
from matrix import *

WIDTH = 800
HEIGHT = 600
FOV = 45
NEAR = 0.1
FAR = 1000

class Renderer:
    def __init__(self):
        
        pygame.init()
        self.screen = pygame.display.set_mode((WIDTH, HEIGHT))
        self.clock = pygame.time.Clock()
        self.running = True
        self.objects = []
        self.font = pygame.font.SysFont('Arial', 14)

        self.camera_pos = Point3D(0, 0, 5)
        self.camera_target = Point3D(0, 0, 0)
        self.camera_up = Point3D(0, 1, 0)
        self.camera_yaw = 0  
        self.camera_pitch = 0  

        self.transform = Matrix.identity(4)  
        
        self.show_axes = True
        self.show_labels = True
        self.show_hidden_lines = True
        
        self.move_speed = 0.1
        self.rotate_speed = 1.0
        
        self.update_camera()
        self.projection = perspective_matrix(FOV, WIDTH/HEIGHT, NEAR, FAR)

    def update_camera(self):
        self.camera = self.look_at(
            eye=self.camera_pos,
            target=self.camera_target,
            up=self.camera_up
        )
        
    def look_at(self, eye, target, up):
        z = (eye - target).normalize()
        x = up.cross(z).normalize()
        y = z.cross(x).normalize()
        rotation = Matrix([
            [x.x, x.y, x.z, 0],
            [y.x, y.y, y.z, 0],
            [z.x, z.y, z.z, 0],
            [0, 0, 0, 1]
        ])
        translation = translation_matrix(-eye.x, -eye.y, -eye.z)
        return rotation * translation
        
    def load_object(self, filename):
        vertices = []
        faces = []
        with open(filename, 'r') as f:
            for line in f:
                line = line.strip()
                if not line or line.startswith('#'):
                    continue
                parts = line.split()
                if parts[0] == 'v':
                    x, y, z = map(float, parts[1:4])
                    vertices.append(Point3D(x, y, z))
                elif parts[0] == 'f':
                    indices = list(map(lambda x: int(x.split('/')[0])-1, parts[1:]))
                    faces.append(indices)
        self.objects.append({'vertices': vertices, 'faces': faces})
        
    def project_point(self, point):
        transformed = self.camera * self.transform * point.to_homogeneous()
        projected = self.projection * transformed
        return Point3D.from_homogeneous(projected)
    
    def world_to_screen(self, point):
        screen_x = int((point.x * 0.5 + 0.5) * WIDTH)
        screen_y = int((1 - (point.y * 0.5 + 0.5)) * HEIGHT)
        return (screen_x, screen_y)
    
    def handle_events(self):
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                self.running = False
            elif event.type == pygame.KEYDOWN:
                if event.key == pygame.K_F5:
                    self.show_axes = not self.show_axes
                elif event.key == pygame.K_F6:
                    self.show_labels = not self.show_labels
                elif event.key == pygame.K_F7:
                    self.show_hidden_lines = not self.show_hidden_lines

        keys = pygame.key.get_pressed()
        
        move_speed = 0.1
        if keys[pygame.K_i]:
            self.transform = translation_matrix(0, 0, move_speed) * self.transform
        if keys[pygame.K_k]:
            self.transform = translation_matrix(0, 0, -move_speed) * self.transform
        if keys[pygame.K_j]:
            self.transform = translation_matrix(-move_speed, 0, 0) * self.transform
        if keys[pygame.K_l]:
            self.transform = translation_matrix(move_speed, 0, 0) * self.transform
        if keys[pygame.K_u]:
            self.transform = translation_matrix(0, move_speed, 0) * self.transform
        if keys[pygame.K_o]:
            self.transform = translation_matrix(0, -move_speed, 0) * self.transform
            
        rotate_speed = 1
        if keys[pygame.K_UP]:
            self.transform = rotation_x_matrix(-rotate_speed) * self.transform
        if keys[pygame.K_DOWN]:
            self.transform = rotation_x_matrix(rotate_speed) * self.transform
        if keys[pygame.K_LEFT]:
            self.transform = rotation_y_matrix(rotate_speed) * self.transform
        if keys[pygame.K_RIGHT]:
            self.transform = rotation_y_matrix(-rotate_speed) * self.transform
        if keys[pygame.K_LESS]:
            self.transform = rotation_z_matrix(rotate_speed) * self.transform
        if keys[pygame.K_GREATER]:
            self.transform = rotation_z_matrix(-rotate_speed) * self.transform
            
        scale_speed = 1.05
        if keys[pygame.K_PLUS] or keys[pygame.K_KP_PLUS]:
            self.transform = scaling_matrix(scale_speed, scale_speed, scale_speed) * self.transform
        if keys[pygame.K_MINUS] or keys[pygame.K_KP_MINUS]:
            self.transform = scaling_matrix(1/scale_speed, 1/scale_speed, 1/scale_speed) * self.transform
            
        if keys[pygame.K_F1]:
            self.transform = reflection_matrix('x') * self.transform
        if keys[pygame.K_F2]:
            self.transform = reflection_matrix('y') * self.transform
        if keys[pygame.K_F3]:
            self.transform = reflection_matrix('z') * self.transform

        if keys[pygame.K_z]:
            self.camera_pitch += self.rotate_speed
        if keys[pygame.K_x]:
            self.camera_pitch -= self.rotate_speed
        if keys[pygame.K_q]:
            self.camera_yaw += self.rotate_speed
        if keys[pygame.K_e]:
            self.camera_yaw -= self.rotate_speed
            
        move_dir = Point3D(
            math.sin(math.radians(self.camera_yaw)),
            0,
            math.cos(math.radians(self.camera_yaw))
        ).normalize()
        
        if keys[pygame.K_w]:
            self.camera_pos += move_dir * self.move_speed
            self.camera_target += move_dir * self.move_speed
        if keys[pygame.K_s]:
            self.camera_pos -= move_dir * self.move_speed
            self.camera_target -= move_dir * self.move_speed
        if keys[pygame.K_a]:
            right = move_dir.cross(self.camera_up).normalize()
            self.camera_pos -= right * self.move_speed
            self.camera_target -= right * self.move_speed
        if keys[pygame.K_d]:
            right = move_dir.cross(self.camera_up).normalize()
            self.camera_pos += right * self.move_speed
            self.camera_target += right * self.move_speed
        
        self.update_camera()

            
    def draw_axes(self):
        axes_length = 5  
        tick_length = 0.2  
        ticks_step = 1  

        x_axis = [Point3D(0, 0, 0), Point3D(axes_length, 0, 0)]
        y_axis = [Point3D(0, 0, 0), Point3D(0, axes_length, 0)]
        z_axis = [Point3D(0, 0, 0), Point3D(0, 0, axes_length)]
        
        x_ticks = []
        for i in range(1, axes_length+1, ticks_step):
            x_ticks.extend([
                Point3D(i, 0, 0), Point3D(i, tick_length, 0),
                Point3D(i, 0, 0), Point3D(i, -tick_length, 0)
            ])
            
        y_ticks = []
        for i in range(1, axes_length+1, ticks_step):
            y_ticks.extend([
                Point3D(0, i, 0), Point3D(tick_length, i, 0),
                Point3D(0, i, 0), Point3D(-tick_length, i, 0)
            ])
            
        z_ticks = []
        for i in range(1, axes_length+1, ticks_step):
            z_ticks.extend([
                Point3D(0, 0, i), Point3D(tick_length, 0, i),
                Point3D(0, 0, i), Point3D(-tick_length, 0, i)
            ])

        elements = [
            (x_axis, (255, 0, 0)),
            (y_axis, (0, 255, 0)),
            (z_axis, (0, 0, 255)),
            (x_ticks, (255, 0, 0)),
            (y_ticks, (0, 255, 0)),
            (z_ticks, (0, 0, 255))
        ]

        for points, color in elements:
            transformed = []
            for p in points:
                transformed_point = self.camera * p.to_homogeneous()
                projected = self.projection * transformed_point
                proj = Point3D.from_homogeneous(projected)
                if proj.w <= 0:
                    transformed.append(None)
                else:
                    transformed.append(self.world_to_screen(proj))
            
            for i in range(0, len(transformed), 2):
                if transformed[i] and transformed[i+1]:
                    pygame.draw.line(self.screen, color, 
                                    transformed[i], transformed[i+1], 1)

        def draw_label(text, position, color):
            label = self.font.render(text, True, color)
            self.screen.blit(label, position)
            
        x_end = self.camera * Point3D(axes_length, 0, 0).to_homogeneous()
        x_proj = self.projection * x_end
        x_screen = self.world_to_screen(Point3D.from_homogeneous(x_proj))
        if x_proj[3] > 0:
            draw_label("X", (x_screen[0]+10, x_screen[1]), (255,0,0))
            
        y_end = self.camera * Point3D(0, axes_length, 0).to_homogeneous()
        y_proj = self.projection * y_end
        y_screen = self.world_to_screen(Point3D.from_homogeneous(y_proj))
        if y_proj[3] > 0:
            draw_label("Y", (y_screen[0], y_screen[1]-20), (0,255,0))

        z_end = self.camera * Point3D(0, 0, axes_length).to_homogeneous()
        z_proj = self.projection * z_end
        z_screen = self.world_to_screen(Point3D.from_homogeneous(z_proj))
        if z_proj[3] > 0:
            draw_label("Z", (z_screen[0], z_screen[1]-10), (0,0,255))
    
    def draw_help(self):
        help_text ="Управление:\nПеремещение объекта: I/K (вперед/назад), J/L (влево/вправо), U/O (вверх/вниз)\nПоворот объекта: ←/→ (Y), ↑/↓ (X)\nМасштаб: +/= / -\nОтражение: F1 (X), F2 (Y), F3 (Z)\nКамера:\n  Движение: W/S (вперед/назад), A/D (вбок)\nОтображение:\n  F5 - оси, F6 - метки"
        lines = help_text.split('\n')
        for i, line in enumerate(lines):
            text = self.font.render(line, True, (255, 255, 255))
            self.screen.blit(text, (10, 10 + i*16))

    def render(self):
        self.screen.fill((0, 0, 0))
        
        for obj in self.objects:
            transformed = []
            for point in obj['vertices']:
                proj = self.project_point(point)
                if proj.w <= 0:
                    transformed.append(None)
                else:
                    transformed.append(self.world_to_screen(proj))
            
            if self.show_labels:
                for idx, coords in enumerate(transformed):
                    if coords:
                        pygame.draw.circle(self.screen, (255,255,255), coords, 3)
                        text = self.font.render(str(idx+1), True, (200,200,200))
                        self.screen.blit(text, (coords[0]+8, coords[1]-8))
            else:
                for coords in transformed:
                    if coords:
                        pygame.draw.circle(self.screen, (255,255,255), coords, 3)
            
            for face in obj['faces']:
                points = []
                valid = True
                for idx in face:
                    if idx >= len(transformed) or not transformed[idx]:
                        valid = False
                        break
                    points.append(transformed[idx])
                
                if valid and len(points) >= 2:
                    color = (100,100,255)
                    if self.show_hidden_lines:
                        pygame.draw.lines(self.screen, color, False, points, 1)
                    else:
                        if all(p.z > 0 for p in [Point3D.from_homogeneous(
                            self.camera * self.transform * obj['vertices'][i].to_homogeneous()
                        ) for i in face]):
                            pygame.draw.lines(self.screen, color, False, points, 1)
        
        if self.show_axes:
            self.draw_axes()
        
        self.draw_help()
        
        pygame.display.flip()
        self.clock.tick(60)
    
    def run(self):
        self.load_object('object.txt')
        while self.running:
            self.handle_events()
            self.render()
        pygame.quit()

if __name__ == "__main__":
    renderer = Renderer()
    renderer.run()
