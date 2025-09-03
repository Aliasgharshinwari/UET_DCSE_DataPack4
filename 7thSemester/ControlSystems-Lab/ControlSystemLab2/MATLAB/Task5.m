% Define the time vector
t = 0:0.01:10;  % time from 0 to 10 with a step of 0.01

% Step input 1: Step function at time = 0
step1 = ones(size(t));  % unit step input

% Step input 2: Step function with step time of 5 and gain of 2
step2 = 2 * (t >= 5);  % step at t = 5 with gain 2

% Sine function with frequency of 2*pi (1 Hz sine wave)
sine_wave = sin(2*pi*t);

% Pulse generator with period of 10 and duty cycle of 50%
pulse_generator = square(2*pi*(1/10)*t, 50);  % period = 10, duty cycle = 50%

% Sum the signals
combined_signal = step1 + step2 + sine_wave + pulse_generator;

% Plot the signals
figure;

% Plot Step Input 1
subplot(6,1,1);
plot(t, step1, 'LineWidth', 2);
title('Step Input 1 (Unit Step)');
axis([0 10 -0.5 2]);

% Plot Step Input 2
subplot(6,1,2);
plot(t, step2, 'LineWidth', 2);
title('Step Input 2 (Step at t = 5, Gain = 2)');
axis([0 10 -0.5 2.5]);

% Plot Sine Wave
subplot(6,1,3);
plot(t, sine_wave, 'LineWidth', 2);
title('Sine Wave (Frequency = 2*pi)');
axis([0 10 -1.5 1.5]);

% Plot Pulse Generator
subplot(6,1,4);
plot(t, pulse_generator, 'LineWidth', 2);
title('Pulse Generator (Period = 10, Duty Cycle = 50%)');
axis([0 10 -1.5 1.5]);

% Plot combined signal
subplot(6,1,5);
plot(t, combined_signal, 'LineWidth', 2);
title('Combined Signal');
axis([0 10 -3 6]);

% Label the axes
xlabel('Time (s)');
ylabel('Amplitude');
