clc;
clear all;
A=[-4 -1.5;
    4 0];
B=[2;0];
C=[1.5 0.625];
D=0;
[Num, Den]=ss2tf(A,B,C,D);
display(Num)
display(Den)