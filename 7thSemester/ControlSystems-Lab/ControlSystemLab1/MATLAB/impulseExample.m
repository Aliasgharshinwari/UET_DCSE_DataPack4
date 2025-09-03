C1 = [1, 0, -6]; %co-efficient of x^2 - 6
C2 = [1, 1, -2]; %co-efficient of x^2 + x - 2
transferFunction = tf(C1, C2);
[ImpResp,t] = impulse(transferFunction);

% Plot the step response
figure;
plot(t, ImpResp);
title('Impulse Response of the Transfer Function');
xlabel('Time (seconds)');
ylabel('Amplitude');
grid on;