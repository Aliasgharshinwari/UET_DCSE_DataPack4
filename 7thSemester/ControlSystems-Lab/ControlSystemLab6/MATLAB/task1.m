syms s

f = ilaplace(3/(s*(s^2 + 2*s + 5)));
pretty(f)
