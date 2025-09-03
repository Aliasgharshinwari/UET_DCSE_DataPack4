import cv2
import numpy as np
import matplotlib.pyplot as plt
img = cv2.imread('input.jpg', cv2.IMREAD_GRAYSCALE)
laplacian = cv2.Laplacian(img, cv2.CV_64F)
laplacian = np.uint8(np.absolute(laplacian))
plt.imshow(laplacian, cmap='gray'); plt.title('Laplacian Sharpening'); plt.axis('off'); plt.show()
