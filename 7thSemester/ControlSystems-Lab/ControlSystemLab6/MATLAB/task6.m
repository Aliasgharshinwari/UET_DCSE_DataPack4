syms a
syms t

f = cos(a*t);

l = laplace(f);
pretty(l)