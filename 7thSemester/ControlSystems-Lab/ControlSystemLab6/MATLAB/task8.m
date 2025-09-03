syms a
syms t

f = 2*exp(-t) - 2*t*exp(-2*t)- 2*exp(-2*t); 

l = laplace(f);
pretty(l)
