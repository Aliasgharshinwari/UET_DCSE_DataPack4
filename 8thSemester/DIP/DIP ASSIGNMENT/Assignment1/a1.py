import cv2
import numpy as np
import matplotlib.pyplot as plt

img = cv2.imread('input.jpg', cv2.IMREAD_GRAYSCALE)
threshold = 128
_, thresh_img = cv2.threshold(img, threshold, 255, cv2.THRESH_BINARY)

plt.subplot(1, 2, 1)
plt.title('Original Image')
plt.imshow(img, cmap='gray')
plt.axis('off')

plt.subplot(1, 2, 2)
plt.title('Thresholded Image')
plt.imshow(thresh_img, cmap='gray')
plt.axis('off')

plt.show()
