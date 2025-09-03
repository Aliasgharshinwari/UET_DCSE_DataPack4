num3=[0 0 0 0 8 10];
denum3=[1 5 1 5 13];
[A3,B3,C3,D3] = tf2ss(num3,denum3);
display(A3)
display(B3)
display(C3)
display(D3)