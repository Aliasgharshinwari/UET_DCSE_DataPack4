import cv2
import numpy as np
import matplotlib.pyplot as plt
image = cv2.imread('Lenna_(test_image).png', cv2.IMREAD_GRAYSCALE)

lower = 100
upper = 150

sliced_retained = np.where((image >= lower) & (image <= upper), 255, image)
sliced_suppressed = np.where((image >= lower) & (image <= upper), 255, 0)

plt.figure(figsize=(15, 6))

plt.subplot(2, 3, 1)
plt.imshow(image, cmap='gray')
plt.title('Original Image')
plt.axis('off')

plt.subplot(2, 3, 2)
plt.imshow(sliced_retained, cmap='gray')
plt.title('Sliced (Background Retained)')
plt.axis('off')

plt.subplot(2, 3, 3)
plt.imshow(sliced_suppressed, cmap='gray')
plt.title('Sliced (Background Suppressed)')
plt.axis('off')

# Plot function for background retained
x = np.arange(0, 256)
y_retained = np.where((x >= lower) & (x <= upper), 255, x)
plt.subplot(2, 3, 5)
plt.plot(x, y_retained, label='Retain Background', color='blue')
plt.title('Pixel Mapping (Retained)')
plt.xlabel('Original Intensity')
plt.ylabel('Transformed Intensity')
plt.grid(True)

# Plot function for background suppressed
y_suppressed = np.where((x >= lower) & (x <= upper), 255, 0)
plt.subplot(2, 3, 6)
plt.plot(x, y_suppressed, label='Suppress Background', color='red')
plt.title('Pixel Mapping (Suppressed)')
plt.xlabel('Original Intensity')
plt.ylabel('Transformed Intensity')
plt.grid(True)

plt.tight_layout()
plt.show()
