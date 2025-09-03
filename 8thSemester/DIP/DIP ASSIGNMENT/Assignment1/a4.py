import cv2
import numpy as np
import matplotlib.pyplot as plt
img = cv2.imread('input.jpg', cv2.IMREAD_GRAYSCALE)
gamma_values = [0.5, 1.0, 2.0]
plt.figure(figsize=(10, 4))

for i, gamma in enumerate(gamma_values):
    gamma_img = np.array(255 * (img / 255) ** gamma, dtype='uint8')
    plt.subplot(1, len(gamma_values), i+1)
    plt.title(f'Gamma = {gamma}')
    plt.imshow(gamma_img, cmap='gray')
    plt.axis('off')
plt.show()
