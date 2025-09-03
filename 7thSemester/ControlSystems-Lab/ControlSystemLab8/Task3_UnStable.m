den = poly([3,3]);
sys = tf([1], den)
t = 0:0.1:100;
%zplane(func)

pzmap(sys);
step(t,sys)