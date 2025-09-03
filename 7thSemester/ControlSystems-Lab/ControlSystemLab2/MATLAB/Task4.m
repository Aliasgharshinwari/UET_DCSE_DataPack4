% Parameters
amplitude = 1;  % Amplitude of the square wave
period = 10;    % Time period in seconds
simulation_time = 40;  % Total simulation time in seconds

% Time vector
t = 0:0.01:simulation_time;  % Time from 0 to 40 seconds with step size 0.01 seconds

% Generate square wave
square_wave = amplitude * square(2 * pi * (1/period) * t);

% Plot the square wave
figure;
plot(t, square_wave);
title('Square Wave with Amplitude 1 and Period 10 seconds');
xlabel('Time (s)');
ylabel('Amplitude');
grid on;
