import cv2
import numpy as np
import matplotlib.pyplot as plt
img = cv2.imread('input.jpg', cv2.IMREAD_GRAYSCALE)
smoothed = cv2.blur(img, (3, 3))
plt.imshow(smoothed, cmap='gray'); plt.title('Moving Average'); plt.axis('off'); plt.show()
