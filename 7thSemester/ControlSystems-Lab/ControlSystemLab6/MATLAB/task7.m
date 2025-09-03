syms a
syms t

f = 1 + 2*exp(-t) + 3*exp(-2*t); 

l = laplace(f);
pretty(l)