import cv2
import numpy as np
import matplotlib.pyplot as plt
image = cv2.imread('Lenna_(test_image).png', cv2.IMREAD_GRAYSCALE)
L = 256  # For 8-bit images
negative = (L - 1) - image
plt.figure(figsize=(12, 6))
plt.subplot(2, 2, 1)
plt.imshow(image, cmap='gray')
plt.title('Original Image')
plt.axis('off')
plt.subplot(2, 2, 2)
plt.imshow(negative, cmap='gray')
plt.title('Negative Image')
plt.axis('off')
plt.subplot(2, 2, 3)
plt.hist(image.ravel(), bins=256, range=(0, 255), color='gray')
plt.title('Histogram - Original Image')
plt.xlabel('Pixel Intensity')
plt.ylabel('Frequency')
plt.subplot(2, 2, 4)
plt.hist(negative.ravel(), bins=256, range=(0, 255), color='gray')
plt.title('Histogram - Negative Image')
plt.xlabel('Pixel Intensity')
plt.ylabel('Frequency')
plt.tight_layout()
plt.show()
