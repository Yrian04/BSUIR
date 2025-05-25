import itertools

import cv2
import numpy as np


def square(size):
    form = np.arange(size) - 1
    return np.asarray([*itertools.product(form, form)])


def median_filter(image: cv2.Mat, aperture=square(3)) -> cv2.Mat:
    for i, j in itertools.product(range(x_r := image.shape[0]), range(y_r := image.shape[1])):
        neighbors = []
        for x, y in aperture + np.asarray((i, j)):
            if 0 <= x < x_r and 0 <= y < y_r:
                neighbors.append(image[x, y])
        image[i, j] = np.median(neighbors, axis=0)
    return image


if __name__ == '__main__':
    print(np.median(
        [
            (15, 20, 30),
            (5, 2, 4),
            (10, 30, 20)
        ],
        axis=0)
    )
