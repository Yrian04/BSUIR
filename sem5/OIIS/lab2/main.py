import cv2
import numpy as np

from src.median_filter import median_filter


def main(image):
    image = cv2.imread(image)
    filtered = median_filter(image)
    cv2.imwrite('filtered.png', filtered)


if __name__ == '__main__':
    main('img.png')

