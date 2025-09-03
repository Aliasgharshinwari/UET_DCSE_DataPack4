A = [0 1 5 0;
      0 0 1 0;
      0 0 0 1;
      -7 -9 -2 -3];
B = [0; 5; 8; 2];
C = [1 3 6 6];
D = 0;
[Num, Den]=ss2tf(A,B,C,D);
display(Num)
display(Den)