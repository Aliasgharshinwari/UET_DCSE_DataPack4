syms s
syms a

f = ilaplace(1/(s-a)^2);
pretty(f)
