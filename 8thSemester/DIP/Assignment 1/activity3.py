import cv2
import numpy as np
import matplotlib.pyplot as plt
image = cv2.imread('Lenna_(test_image).png', cv2.IMREAD_GRAYSCALE)
image_normalized = image / 255.0
c_values = [0.5, 1, 2, 5]
plt.figure(figsize=(15, 6))
plt.subplot(1, len(c_values)+1, 1)
plt.imshow(image, cmap='gray')
plt.title('Original Image')
plt.axis('off')

for i, c in enumerate(c_values):
    log_transformed = c * np.log1p(image_normalized)
    log_transformed = cv2.normalize(log_transformed, None, 0, 255, cv2.NORM_MINMAX)
    log_transformed = log_transformed.astype(np.uint8)
    
    plt.subplot(1, len(c_values)+1, i+2)
    plt.imshow(log_transformed, cmap='gray')
    plt.title(f'c = {c}')
    plt.axis('off')

plt.tight_layout()
plt.show()
