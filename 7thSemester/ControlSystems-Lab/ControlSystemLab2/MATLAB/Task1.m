C1 = [10];
C2 = [1, 2, 20];
transferFunction = tf(C1, C2);

figure(1)
step(transferFunction)

figure(2)
plot (diff(step(transferFunction))) 
title("Impulse Response")
xlabel("Time(Seconds)")
ylabel("Amplitude")