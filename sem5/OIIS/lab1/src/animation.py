import matplotlib.animation
import numpy as np
import matplotlib.pyplot as plt

from fourier_transform import dft, fft

TIME = 64
FREQ = 16
N = TIME * FREQ
# y = np.concat(
#     (
#         np.zeros((fraq // 4,)),
#         np.ones((fraq // 2,)),
#         np.zeros((fraq // 4,)),
#     )
# )
# y = np.cos(x * 2 * np.pi)


fig = plt.figure()


# x = np.linspace(0, time, fraq * time)
# y = func(x)

# plt.plot(x, y)
# plt.grid(True)
# plt.show()
#
# y = abs(fft(y))
# plt.grid(True)
# plt.plot(np.arange(fraq // 2) / time, y[:fraq // 2])
# plt.show()
#
# y = np.log10(y) / 10
# plt.grid(True)
# plt.plot(np.arange(fraq // 2) / time, y[:fraq // 2])
# plt.show()

ax = plt.axes(xlim=(0, TIME), ylim=(-2, 2))
line, = ax.plot([], [], lw=3)
func_line, = ax.plot([], [], lw=3)


def func(x):
    # return np.sin(x * 2 * np.pi)
    return np.asarray([1 if int(i) % 2 == 0 else 0 for i in x / 2])


def init():
    line.set_data([], [])
    func_line.set_data([], [])
    return line, func_line


def animation(t):
    x = np.arange(t) / FREQ
    y = func(x)
    func_line.set_data(x, y)

    x = np.arange(t)
    y = abs(dft(y)) / t * 1.5
    line.set_data(x, y)

    return line, func_line


anim = matplotlib.animation.FuncAnimation(
    fig,
    animation,
    init_func=init,
    frames=np.arange(1, N),
    interval=10,
    blit=True,
    repeat=False
)

plt.grid(True)
plt.show()
