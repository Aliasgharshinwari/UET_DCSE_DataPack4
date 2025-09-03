C1 = [10];
C2 = [1, 2, 20];

G = tf(C1, C2);
t = 0:1/100:20;
f = 1;

y = sin(2*pi*f*t);
lsim(G, y, t)
