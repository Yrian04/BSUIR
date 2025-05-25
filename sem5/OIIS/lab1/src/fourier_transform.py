import math

import numpy as np


def dft(function) -> np.ndarray:
    function = np.asarray(function, dtype=float)
    N = function.shape[0]
    n = np.arange(N)
    k = n.reshape((N, 1))
    M = np.exp(-2j * np.pi * n * k / N)
    return np.dot(M, function)


def fft(function) -> np.ndarray:
    function = np.asarray(function, dtype=float)
    N = function.shape[0]

    if N & (N - 1):
        raise ValueError(f"{len(function) = } must be power of 2")

    if N <= 32:
        return dft(function)
    else:
        evens = fft(function[::2])
        odds = fft(function[1::2])
        factor = np.exp(-2j * np.pi * np.arange(N) / N)
        return np.concatenate([evens + factor[:N // 2] * odds,
                               evens + factor[N // 2:] * odds])

