import cv2
import numpy as np
import matplotlib.pyplot as plt

img = cv2.imread('input.jpg', cv2.IMREAD_GRAYSCALE)
neg_img = 255 - img
plt.subplot(2, 2, 1)
plt.title('Original Image')
plt.imshow(img, cmap='gray')
plt.axis('off')
plt.subplot(2, 2, 2)
plt.title('Negative Image')
plt.imshow(neg_img, cmap='gray')
plt.axis('off')
plt.subplot(2, 2, 3)
plt.title('Histogram (Original)')
plt.hist(img.ravel(), 256, [0, 256])
plt.subplot(2, 2, 4)
plt.title('Histogram (Negative)')
plt.hist(neg_img.ravel(), 256, [0, 256])
plt.show()
