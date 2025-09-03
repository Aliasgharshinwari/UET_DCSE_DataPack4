import cv2
import numpy as np
import matplotlib.pyplot as plt
img = cv2.imread('input.jpg', cv2.IMREAD_GRAYSCALE)
lower, upper = 100, 200
sliced = np.where((img >= lower) & (img <= upper), 255, 0)

plt.subplot(1, 2, 1)
plt.title('Original')
plt.imshow(img, cmap='gray')
plt.axis('off')
plt.subplot(1, 2, 2)
plt.title('Gray Level Sliced')
plt.imshow(sliced, cmap='gray')
plt.axis('off')
plt.show()
