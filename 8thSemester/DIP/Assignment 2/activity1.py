import cv2
import numpy as np
import matplotlib.pyplot as plt

# Load grayscale image
image = cv2.imread('Lenna_(test_image)LC.png', cv2.IMREAD_GRAYSCALE)

# Contrast Stretching Function
def contrast_stretch(img, r1, r2, s1, s2):
    result = np.zeros_like(img)
    for i in range(img.shape[0]):
        for j in range(img.shape[1]):
            r = img[i, j]
            if r < r1:
                result[i, j] = int((s1 / r1) * r)
            elif r <= r2:
                result[i, j] = int(((s2 - s1) / (r2 - r1)) * (r - r1) + s1)
            else:
                result[i, j] = int(((255 - s2) / (255 - r2)) * (r - r2) + s2)
    return result

# Parameters
r1, r2 = 100, 170
s1, s2 = 0, 255

# Apply contrast stretching
stretched = contrast_stretch(image, r1, r2, s1, s2)

# Plot Images and Histograms
plt.figure(figsize=(12, 6))

# Original Image
plt.subplot(2, 2, 1)
plt.imshow(image, cmap='gray')
plt.title('Original Image')
plt.axis('off')

# Stretched Image
plt.subplot(2, 2, 2)
plt.imshow(stretched, cmap='gray')
plt.title('Contrast-Stretched Image')
plt.axis('off')

# Histogram - Original
plt.subplot(2, 2, 3)
plt.hist(image.ravel(), bins=256, range=(0, 255), color='gray')
plt.title('Histogram - Original')
plt.xlabel('Pixel Intensity')
plt.ylabel('Frequency')

# Histogram - Stretched
plt.subplot(2, 2, 4)
plt.hist(stretched.ravel(), bins=256, range=(0, 255), color='gray')
plt.title('Histogram - Contrast-Stretched')
plt.xlabel('Pixel Intensity')
plt.ylabel('Frequency')

plt.tight_layout()
plt.show()
