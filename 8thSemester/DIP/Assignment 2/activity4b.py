# sharpening_filter.py

import cv2
import numpy as np
import matplotlib.pyplot as plt

image = cv2.imread('Lenna_(test_image).png', cv2.IMREAD_GRAYSCALE)

# Apply Laplacian Filter
laplacian = cv2.Laplacian(image, cv2.CV_64F, ksize=3)
laplacian_abs = cv2.convertScaleAbs(laplacian)
sharpened = cv2.add(image, laplacian_abs)

# Display results
plt.figure(figsize=(10, 4))

plt.subplot(1, 3, 1)
plt.imshow(image, cmap='gray')
plt.title('Original Image')
plt.axis('off')

plt.subplot(1, 3, 2)
plt.imshow(laplacian_abs, cmap='gray')
plt.title('Laplacian (Edges)')
plt.axis('off')

plt.subplot(1, 3, 3)
plt.imshow(sharpened, cmap='gray')
plt.title('Sharpened Image')
plt.axis('off')

plt.tight_layout()
plt.show()
