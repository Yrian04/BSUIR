import time

def rasterize_polygon(polygon, canvas, debug=False):
    print('rasterize')
    edges = []
    min_y = min(p[1] for p in polygon)
    max_y = max(p[1] for p in polygon)
    
    for i in range(len(polygon)):
        x0, y0 = polygon[i]
        x1, y1 = polygon[(i+1)%len(polygon)]
        if y1 != y0:
            edge = {
                'ymin': min(y0, y1),
                'ymax': max(y0, y1),
                'x': x0 if y0 < y1 else x1,
                'dx': (x1 - x0) / (y1 - y0) if (y1 - y0) != 0 else 0
            }
            edges.append(edge)
    
    edges.sort(key=lambda e: e['ymin'])
    active_edges = []
    
    for scanline_y in range(min_y, max_y + 1):
        while edges and edges[0]['ymin'] == scanline_y:
            active_edges.append(edges.pop(0))
        
        active_edges = [e for e in active_edges if e['ymax'] > scanline_y]
        active_edges.sort(key=lambda e: e['x'])
        
        for i in range(0, len(active_edges), 2):
            x_start = active_edges[i]['x']
            x_end = active_edges[i+1]['x']
            for x in range(int(x_start), int(x_end)+1):
                canvas.set_pixel(x, scanline_y, 'red')
        
        for e in active_edges:
            e['x'] += e['dx']
        
        if debug:
            canvas.update()
            time.sleep(0.1)