num4=[0 1 2 12 7 6];
denum4=[1 9 13 8 0 0];
[A4,B4,C4,D4] = tf2ss(num4,denum4);
display(A4)
display(B4)
display(C4)
display(D4)