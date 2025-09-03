clear;
clc;


%Q2
A=[-4 -1.5;
    4 0];
B=[2;0];
C=[1.5 0.625];
D=0;
T=ss2tf(A,B,C,D);
display(T)
%% Q3
num3=[0 0 0 0 8 10];
denum3=[1 5 1 5 13];
[A3,B3,C3,D3] = tf2ss(num3,denum3);
display(A3)
display(B3)
display(C3)
display(D3)
%% Q4
num4=[0 1 2 12 7 6];
denum4=[1 9 13 8 0 0];
[A4,B4,C4,D4] = tf2ss(num4,denum4);
display(A4)
display(B4)
display(C4)
display(D4)
%% Q5
A5 = [0 1 5 0;
      0 0 1 0;
      0 0 0 1;
      -7 -9 -2 -3];
B5 = [0; 5; 8; 2];
C5 = [1 3 6 6];
D5 = 0;
T5=ss2tf(A5,B5,C5,D5);
display(T5)
%% Q6
A6 = [3 1 0 4 -2;
      -3 5 -5 2 -1;
      0 1 -1 2 8;
      -7 6 -3 -4 0;
      -6 0 4 -3 1];
B6 = [2 7 8 5 4]';
C6 = [1 -2 -9 7 6];
D6 = 0;
T6=ss2tf(A6,B6,C6,D6);
display(T6)