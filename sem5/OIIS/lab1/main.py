import numpy as np
import matplotlib.pyplot as plt

from src.fourier_transform import fft

TIME = 16
FREQ = 8
N = TIME * FREQ


def main(func):
    x = np.linspace(0, TIME, FREQ * TIME)
    y = func(x)

    plt.plot(x, y)
    plt.grid(True)
    plt.show()

    plt.grid(True)
    plt.plot(np.arange(N) / TIME, npy :=abs(np.fft.fft(y)))
    plt.show()

    y = abs(fft(y))
    print(f"{all(np.isclose(y, npy)) = }")
    plt.grid(True)
    plt.plot(np.arange(N) / TIME, y)
    plt.show()

    y = np.log10(y) / 10
    plt.grid(True)
    plt.plot(np.arange(N) / TIME, y)
    plt.show()


if __name__ == "__main__":
    main(lambda x: np.sin(x * 4 * np.pi / TIME + 1))
    # main(lambda x: np.asarray([10 if i * 10 / TIME % 2 > 1 else 0 for i in x]))
