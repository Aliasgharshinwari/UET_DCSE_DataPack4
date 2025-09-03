import cv2
import numpy as np
import matplotlib.pyplot as plt
image = cv2.imread('Lenna_(test_image).png', cv2.IMREAD_GRAYSCALE)
image = image / 255.0  # Normalize to [0, 1]

gamma_values = [0.4, 1.0, 2.0]
c = 1

plt.figure(figsize=(15, 5))
plt.subplot(1, len(gamma_values) + 1, 1)
plt.imshow(image, cmap='gray')
plt.title('Original Image')
plt.axis('off')

for i, gamma in enumerate(gamma_values):
    gamma_corrected = c * np.power(image, gamma)
    plt.subplot(1, len(gamma_values) + 1, i + 2)
    plt.imshow(gamma_corrected, cmap='gray')
    plt.title(f'Gamma = {gamma}')
    plt.axis('off')

plt.tight_layout()
plt.show()
