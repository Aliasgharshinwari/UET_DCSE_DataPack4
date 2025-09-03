den = poly([3i,-3i]);
sys = tf([1], den)
t = 0:0.1:100;
%zplane(func)
pzmap(sys);
step(t,sys)