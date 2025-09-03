G1 = tf([1], ...
    [1,1]);
G2 = tf([1], ...
    [1,4]);
G3 = tf([1,3], ...
    [1,5]);
G_mid_series = series(G1,G2);
A = parallel(G_mid_series, G3);
B = series(A,G_mid_series);
C=parallel(G1, G2);
D = series(C,G3);
out = feedback(B,D)
step(out)