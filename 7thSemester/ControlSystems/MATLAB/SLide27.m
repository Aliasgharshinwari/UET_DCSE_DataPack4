A=[2 3; 0 5 ];
B=[1; 2];
C=[1 0;
    0 1]
P=[B A*B]
rank(P)
desiredegn=[-3 -5];
K=place(A,B,desiredegn)