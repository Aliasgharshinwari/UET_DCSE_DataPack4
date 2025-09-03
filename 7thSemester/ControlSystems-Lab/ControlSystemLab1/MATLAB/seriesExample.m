C1 = [4, -1, -3]; %co-efficient of 4x^2 - x - 3
C2 = [2, 1, -2]; %co-efficient of 2x^2 + x - 2

C3 = [1, -3]; %co-efficient of x - 3
C4 = [1, 1, 1]; %co-efficient of x^2 + x + 1

S1 = tf(C1, C2);
S2 = tf(C3,C4);

series(S1,S2)