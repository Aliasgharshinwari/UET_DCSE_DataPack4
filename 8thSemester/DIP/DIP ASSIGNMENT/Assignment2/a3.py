import cv2
import numpy as np
import matplotlib.pyplot as plt
img = cv2.imread('input.jpg', cv2.IMREAD_GRAYSCALE)
fig, axs = plt.subplots(2, 4, figsize=(12, 6))
for i in range(8):
    bit_plane = ((img >> i) & 1) * 255
    axs[i//4, i%4].imshow(bit_plane, cmap='gray')
    axs[i//4, i%4].set_title(f'Bit Plane {i}')
    axs[i//4, i%4].axis('off')
plt.show()
