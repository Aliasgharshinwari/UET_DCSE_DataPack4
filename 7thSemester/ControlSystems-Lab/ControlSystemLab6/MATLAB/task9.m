syms s
num = [0 0 4 4 4];
denum = [1 3 2 0 0];

[r, p, k ] = residue(num, denum);

F1 = r(1)/(s-p(1));
F2 = r(2)/(s-p(2));
F3 = r(3)/(s-p(3));
F4 = r(4)/(s-p(4));

pretty(F1);
pretty(F2);
pretty(F3);
pretty(F4);

l1 = ilaplace(F1);
l2 = ilaplace(F2);
l3 = ilaplace(F3);
l4 = ilaplace(F4);

pretty(l1)
pretty(l2)
pretty(l3)
pretty(l4)