numf=3;
denf=[1 2 5 0];
[k,p,k] = residue(numf,denf);

syms s

f = ilaplace((3/5)/s - 3/20*((2+1j) / (s+1+2j) + (2-2j) / (s+1-2j) ));
pretty(f)