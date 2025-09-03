import numpy as np
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D  # Required for 3D plotting
from matplotlib.animation import FuncAnimation

# Define the function f(x, y) = x² + y² and its gradient ∇f = (2x, 2y)
def f(x, y):
    return x**2 + y**2

def grad_f(x, y):
    return 2 * x, 2 * y

# Set parameters for gradient descent
learning_rate = 0.1
num_iterations = 30

# Initialize starting point (you may adjust these values)
x, y = -4.0, 4.0

# Store the points of the gradient descent path
path = [(x, y, f(x, y))]
for i in range(num_iterations):
    g_x, g_y = grad_f(x, y)
    x = x - learning_rate * g_x
    y = y - learning_rate * g_y
    path.append((x, y, f(x, y)))
path = np.array(path)

# Create a grid for the 3D surface plot
X = np.linspace(-5, 5, 100)
Y = np.linspace(-5, 5, 100)
X, Y = np.meshgrid(X, Y)
Z = f(X, Y)

# Set up the figure and a 3D axis
fig = plt.figure(figsize=(10, 8))
ax = fig.add_subplot(111, projection='3d')
ax.plot_surface(X, Y, Z, alpha=0.5, cmap='viridis', edgecolor='none')
ax.set_xlabel('X')
ax.set_ylabel('Y')
ax.set_zlabel('f(x, y)')
ax.set_title('Gradient Descent on f(x,y)=x²+y²')

# Use a scatter plot for the current point and a line for the descent path.
# Using scatter ensures that the point is clearly visible in 3D.
scatter = ax.scatter(path[0, 0], path[0, 1], path[0, 2], color='red', s=100)
line, = ax.plot(path[0:1, 0], path[0:1, 1], path[0:1, 2], 'r-', linewidth=2)

def update(num):
    # Update current point using scatter (3D scatter requires setting offsets)
    current_point = path[num]
    scatter._offsets3d = ([current_point[0]], [current_point[1]], [current_point[2]])
    
    # Update the trajectory line
    line.set_data(path[:num+1, 0], path[:num+1, 1])
    line.set_3d_properties(path[:num+1, 2])
    
    # Optionally, rotate the view to reveal the path from different angles
    ax.view_init(elev=30, azim=30 + num * 4)
    return scatter, line

# Create the animation
ani = FuncAnimation(fig, update, frames=len(path), interval=500, blit=False, repeat=False)
plt.show()
