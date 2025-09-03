den = poly([-1+3i,-1-3i]);
sys = tf([1], den)
pzmap(sys);
step(sys)