A=[0 3 1; 
   2 8 1;
   -10 -5 -2];
B=[10; 0; 0];
C=[1 0 0]
D=[0]
%checking  stability
%method 01
%Analyzing Step Response
figure
step(A,B,C,D);

%method 02
%Displaying A matrix and its eigenvalues
disp('Matrix A = ')
disp(A)
disp('The eigenvalues of matrix A are:-')
eigen_values = eig(A)

%method 03
%Poles of Transfer function
[num1 , denum1] = ss2tf(A,B,C,D);
disp('The transfer function of input 1 is:-')
Sys1=tf(num1,denum1)
disp('The poles for input 1 are:')
Poles_of_input_1 = roots(denum1)
%%%
%method4 RH Method 
% Method 5: Pole-Zero Map
%disp('--- Method 5: pzmap ---');
figure;
pzmap(Sys1);
title('Pole-Zero Map');
grid on;


% Method 6: Root Locus
%disp('--- Method 6: Root Locus ---');
figure;
rlocus(Sys1);
title('Root Locus');
grid on;

