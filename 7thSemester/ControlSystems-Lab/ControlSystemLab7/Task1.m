A=[0 1 0; 
   0 0 1;
  -24 -26 -9];

B = [0; 0; 1];
C = [2 7 1];
D = 0;
[Num, Den]=ss2tf(A,B,C,D);
display(Num)
display(Den)