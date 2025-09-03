import numpy as np
import cv2
import matplotlib.pyplot as plt

# Load the image in grayscale
image = cv2.imread('img.png', cv2.IMREAD_GRAYSCALE)

# Perform DFT (Discrete Fourier Transform)
dft = np.fft.fft2(image)

# Shift the zero-frequency component to the center of the spectrum
#dft_shift = np.fft.fftshift(dft)

# Calculate magnitude spectrum (log scale for better visibility)
magnitude_spectrum = np.log(np.abs(dft) + 1)

# Plot the magnitude spectrum
plt.imshow(magnitude_spectrum, cmap='gray')
plt.title("Magnitude Spectrum")
plt.show()
