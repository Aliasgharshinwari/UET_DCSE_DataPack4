C1 = [1, 0, -6]; %co-efficient of x^2 - 6
C2 = [1, 1, -2]; %co-efficient of x^2 + x - 2
transferFunction = tf(C1, C2);

% Compute the step response
[StepResp, t] = step(transferFunction);
% Plot the step response
figure;
plot(t, StepResp);
title('Step Response of the Transfer Function');
xlabel('Time (seconds)');
ylabel('Amplitude');
grid on;