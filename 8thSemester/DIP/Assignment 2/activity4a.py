import cv2
import numpy as np
import matplotlib.pyplot as plt

# Load grayscale image
image = cv2.imread('Lenna_(test_image).png', cv2.IMREAD_GRAYSCALE)

# Add salt-and-pepper noise
noisy = image.copy()
noise_density = 0.05
num_salt = int(noise_density * image.size * 0.5)
num_pepper = int(noise_density * image.size * 0.5)

# Add salt (white pixels)
coords = [np.random.randint(0, i - 1, num_salt) for i in image.shape]
noisy[tuple(coords)] = 255

# Add pepper (black pixels)
coords = [np.random.randint(0, i - 1, num_pepper) for i in image.shape]
noisy[tuple(coords)] = 0

# Apply filters on the NOISY image
mean_filtered = cv2.blur(noisy, (3, 3))
median_filtered = cv2.medianBlur(noisy, 3)
min_filtered = cv2.erode(noisy, np.ones((3, 3), np.uint8))
max_filtered = cv2.dilate(min_filtered, np.ones((3, 3), np.uint8))

# Display results
plt.figure(figsize=(12, 8))

plt.subplot(2, 3, 1)
plt.imshow(noisy, cmap='gray')
plt.title('Noisy Image (Salt & Pepper)')
plt.axis('off')

plt.subplot(2, 3, 2)
plt.imshow(mean_filtered, cmap='gray')
plt.title('3x3 Mean Filter')
plt.axis('off')

plt.subplot(2, 3, 3)
plt.imshow(median_filtered, cmap='gray')
plt.title('Median Filter')
plt.axis('off')

plt.subplot(2, 3, 5)
plt.imshow(min_filtered, cmap='gray')
plt.title('Min Filter (Erosion)')
plt.axis('off')

plt.subplot(2, 3, 6)
plt.imshow(max_filtered, cmap='gray')
plt.title('Max Filter (Dilation)')
plt.axis('off')

plt.tight_layout()
plt.show()
