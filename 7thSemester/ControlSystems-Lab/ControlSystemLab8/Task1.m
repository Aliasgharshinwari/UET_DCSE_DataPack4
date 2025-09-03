%stable
den = poly([-1+3i,-1-3i]);
sys1 = tf([1], den)
figure(1);
pzmap(sys1);
figure(2);
step(sys1);

%marginally stable
den = poly([3i,-3i]);
sys2 = tf([1], den)
t = 0:0.1:100;
figure(3);
pzmap(sys2);
figure(4);
step(t,sys2)

%unstable
den = poly([1+3i,1-3i]);
sys3 = tf([1], den)
figure(5);
pzmap(sys3);
figure(6);
step(t,sys3)