G1 = tf([1], ...
    [1,1]);
G2 = tf([1], ...
    [1,4]);
G3 = tf([1,3], ...
    [1,5]);

%Connect in series
G_mid_series = series(G1,G2);
series_out = series(G_mid_series, G3);
figure(1)
step(series_out)

%Connect in parallel
G_mid_parallel = parallel(G1,G2);
parallel_out = parallel(G_mid_parallel, G3)

figure(2)
step(parallel_out)

%feedback

feedback_out = feedback(G_mid_series, G3);
figure(3)
step(feedback_out)


