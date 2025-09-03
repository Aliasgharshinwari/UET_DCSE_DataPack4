import cv2
import numpy as np
import matplotlib.pyplot as plt

image = cv2.imread('Lenna_(test_image).png', cv2.IMREAD_GRAYSCALE)

threshold_values = [50, 100, 127, 150, 200]
max_value = 255

plt.figure(figsize=(15, 8))
plt.subplot(2, 3, 1)
plt.imshow(image, cmap='gray')
plt.title('Original Grayscale')
plt.axis('off')

for i, t in enumerate(threshold_values):
    thresholded = np.where(image > t, max_value, 0).astype(np.uint8)
    plt.subplot(2, 3, i+2)
    plt.imshow(thresholded, cmap='gray')
    plt.title(f'Threshold = {t}')
    plt.axis('off')

plt.tight_layout()
plt.show()