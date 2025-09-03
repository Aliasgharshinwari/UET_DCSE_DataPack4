import cv2
import numpy as np
import matplotlib.pyplot as plt

img = cv2.imread('input.jpg', cv2.IMREAD_GRAYSCALE)

c = 255 / np.log(1 + np.max(img))
log_img = c * (np.log(1 + img))
log_img = np.array(log_img, dtype=np.uint8)

plt.subplot(1, 2, 1)
plt.title('Original Image')
plt.imshow(img, cmap='gray')
plt.axis('off')

plt.subplot(1, 2, 2)
plt.title('Log Transformed Image')
plt.imshow(log_img, cmap='gray')
plt.axis('off')

plt.show()
