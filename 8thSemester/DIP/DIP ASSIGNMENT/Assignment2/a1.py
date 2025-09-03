import cv2
import numpy as np
import matplotlib.pyplot as plt

img = cv2.imread('input.jpg', cv2.IMREAD_GRAYSCALE)
min_val = np.min(img)
max_val = np.max(img)
stretched = ((img - min_val) / (max_val - min_val)) * 255
stretched = stretched.astype(np.uint8)

plt.subplot(1, 2, 1)
plt.title('Original')
plt.imshow(img, cmap='gray')
plt.axis('off')
plt.subplot(1, 2, 2)
plt.title('Contrast Stretched')
plt.imshow(stretched, cmap='gray')
plt.axis('off')
plt.show()
