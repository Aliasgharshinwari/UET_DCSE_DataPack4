import cv2
import numpy as np
import matplotlib.pyplot as plt

image = cv2.imread('Lenna_(test_image).png', cv2.IMREAD_GRAYSCALE)
bit_planes = []

for i in range(8):
    plane = (image >> i) & 1       # Get the i-th bit
    plane_img = (plane * 255).astype(np.uint8)  # Scale to 0–255 for display
    bit_planes.append(plane_img)

plt.figure(figsize=(12, 8))
plt.subplot(3, 3, 1)
plt.imshow(image, cmap='gray')
plt.title('Original Image')
plt.axis('off')

for i in range(8):
    plt.subplot(3, 3, i + 2)
    plt.imshow(bit_planes[7 - i], cmap='gray')
    plt.title(f'Bit Plane {7 - i}')
    plt.axis('off')

plt.tight_layout()
plt.show()
