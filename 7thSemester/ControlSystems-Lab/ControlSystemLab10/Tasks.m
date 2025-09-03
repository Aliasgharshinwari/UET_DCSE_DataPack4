clear;
clc;
%Lab Example
num=[1  -2];  
denum=[1  2  4  8];  
sys = tf(num,denum);
rlocus(sys)
title("Root locus of G(S)H(S) = K(s-2)/(s^3 + 2s^2 + 4s + 8") 
%%
num = [1  -2];  
denum = [1  2  4  8];  
sys = tf(num,denum);  
k = [0:1:10]; 
rlocus(sys,k);
title("Root Locus Plot of G(S)H(S)=K(S-2)/(S+2)(S+2j)(S-2j) for K=0 to 10")