import numpy as np
import matplotlib.pyplot as plt
from skimage import data

# Load grayscale image
image = data.cell()

# Step 1: Fourier Transform
dft = np.fft.fft2(image)
dft_shift = np.fft.fftshift(dft)
magnitude_spectrum = 20 * np.log(np.abs(dft_shift) + 1)

# Step 2: Prepare Distance Matrix
M, N = image.shape
u = np.arange(M)
v = np.arange(N)
U, V = np.meshgrid(u, v, indexing='ij')
D = np.sqrt((U - M//2)**2 + (V - N//2)**2)

# Step 3: Define Highpass Filters
D0 = 50
n = 2  # Butterworth order

# Ideal Highpass Filter
H_ihpf = np.ones((M, N))
H_ihpf[D <= D0] = 0

# Butterworth Highpass Filter
H_bhpf = 1 / (1 + (D0 / (D + 1e-5))**(2 * n))  # Add small epsilon to avoid div/0

# Gaussian Highpass Filter
H_ghpf = 1 - np.exp(-(D**2) / (2 * D0**2))

# Step 4: Apply Filters in Frequency Domain
filtered_ihpf = dft_shift * H_ihpf
filtered_bhpf = dft_shift * H_bhpf
filtered_ghpf = dft_shift * H_ghpf

# Step 5: Compute magnitude spectra of filtered images
mag_ihpf = 20 * np.log(np.abs(filtered_ihpf) + 1)
mag_bhpf = 20 * np.log(np.abs(filtered_bhpf) + 1)
mag_ghpf = 20 * np.log(np.abs(filtered_ghpf) + 1)

# Step 6: Inverse FFT to get sharpened images
sharpened_ihpf = np.abs(np.fft.ifft2(np.fft.ifftshift(filtered_ihpf)))
sharpened_bhpf = np.abs(np.fft.ifft2(np.fft.ifftshift(filtered_bhpf)))
sharpened_ghpf = np.abs(np.fft.ifft2(np.fft.ifftshift(filtered_ghpf)))

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
# Figure 2: IHPF Image + Spectrum
# ============================
plt.figure(figsize=(10, 5))

plt.subplot(1, 2, 1)
plt.imshow(sharpened_ihpf, cmap='gray')
plt.title('ILPF Filtered')
plt.axis('off')

plt.subplot(1, 2, 2)
plt.imshow(mag_ihpf, cmap='viridis')
plt.title('ILPF Spectrum')
plt.axis('off')

plt.tight_layout()

# =============================
# Figure 3: BHPF Image + Spectrum
# =============================
plt.figure(figsize=(10, 5))

plt.subplot(1, 2, 1)
plt.imshow(sharpened_bhpf, cmap='gray')
plt.title('BLPF Filtered (n=2)')
plt.axis('off')

plt.subplot(1, 2, 2)
plt.imshow(mag_bhpf, cmap='viridis')
plt.title('BLPF Spectrum')
plt.axis('off')

plt.tight_layout()

# =============================
# Figure 4: GHPF Image + Spectrum
# =============================
plt.figure(figsize=(10, 5))

plt.subplot(1, 2, 1)
plt.imshow(sharpened_ghpf, cmap='gray')
plt.title('GLPF Filtered')
plt.axis('off')

plt.subplot(1, 2, 2)
plt.imshow(mag_ghpf, cmap='viridis')
plt.title('GLPF Spectrum')
plt.axis('off')

plt.tight_layout()

# Show all figures
plt.show()
