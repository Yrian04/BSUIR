import tkinter as tk

from .app import DelaunayVoronoiApp

def main():
    root = tk.Tk()
    app = DelaunayVoronoiApp(root)
    root.mainloop()

if __name__ == '__main__':
    main()