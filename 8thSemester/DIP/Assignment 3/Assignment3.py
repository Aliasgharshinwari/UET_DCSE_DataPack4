import numpy as np
import matplotlib.pyplot as plt
from skimage import data

# Load image and perform FFT
image = data.camera()
dft = np.fft.fft2(image)
dft_shift = np.fft.fftshift(dft)
magnitude_spectrum = 20 * np.log(np.abs(dft_shift) + 1)

# Create distance matrix
M, N = image.shape
u = np.arange(M)
v = np.arange(N)
U, V = np.meshgrid(u, v, indexing='ij')
D = np.sqrt((U - M//2)**2 + (V - N//2)**2)

# Filter settings
D0 = 50
n = 2

# Define Filters
H_ideal = np.zeros((M, N))
H_ideal[D <= D0] = 1
H_butter = 1 / (1 + (D / D0)**(2 * n))
H_gauss = np.exp(-(D**2) / (2 * D0**2))

# Apply filters
filtered_dft_ideal = dft_shift * H_ideal
filtered_dft_butter = dft_shift * H_butter
filtered_dft_gauss = dft_shift * H_gauss

# Inverse FFTs
filtered_ideal = np.abs(np.fft.ifft2(np.fft.ifftshift(filtered_dft_ideal)))
filtered_butter = np.abs(np.fft.ifft2(np.fft.ifftshift(filtered_dft_butter)))
filtered_gauss = np.abs(np.fft.ifft2(np.fft.ifftshift(filtered_dft_gauss)))

# Filtered spectra
magnitude_ideal = 20 * np.log(np.abs(filtered_dft_ideal) + 1)
magnitude_butter = 20 * np.log(np.abs(filtered_dft_butter) + 1)
magnitude_gauss = 20 * np.log(np.abs(filtered_dft_gauss) + 1)

# ============================
# Figure 1: Original Image + Spectrum
# ============================
plt.figure(figsize=(10, 5))

plt.subplot(1, 2, 1)
plt.imshow(image, cmap='gray')
plt.title('Original Image')
plt.axis('off')

plt.subplot(1, 2, 2)
plt.imshow(magnitude_spectrum, cmap='viridis')
plt.title('Original Spectrum')
plt.axis('off')

plt.tight_layout()


# ============================
# Figure 2: ILPF Image + Spectrum
# ============================
plt.figure(figsize=(10, 5))

plt.subplot(1, 2, 1)
plt.imshow(filtered_ideal, cmap='gray')
plt.title('ILPF Filtered')
plt.axis('off')

plt.subplot(1, 2, 2)
plt.imshow(magnitude_ideal, cmap='viridis')
plt.title('ILPF Spectrum')
plt.axis('off')

plt.tight_layout()

# =============================
# Figure 3: BLPF Image + Spectrum
# =============================
plt.figure(figsize=(10, 5))

plt.subplot(1, 2, 1)
plt.imshow(filtered_butter, cmap='gray')
plt.title('BLPF Filtered (n=2)')
plt.axis('off')

plt.subplot(1, 2, 2)
plt.imshow(magnitude_butter, cmap='viridis')
plt.title('BLPF Spectrum')
plt.axis('off')

plt.tight_layout()

# =============================
# Figure 4: GLPF Image + Spectrum
# =============================
plt.figure(figsize=(10, 5))

plt.subplot(1, 2, 1)
plt.imshow(filtered_gauss, cmap='gray')
plt.title('GLPF Filtered')
plt.axis('off')

plt.subplot(1, 2, 2)
plt.imshow(magnitude_gauss, cmap='viridis')
plt.title('GLPF Spectrum')
plt.axis('off')

plt.tight_layout()

# Show all figures
plt.show()
