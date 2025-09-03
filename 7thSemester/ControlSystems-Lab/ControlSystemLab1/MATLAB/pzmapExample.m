C1 = [4, -1, -3]; %co-efficient of 4x^2 - x - 3
C2 = [2, 1, -2]; %co-efficient of 2x^2 + x - 2
trFun = tf(C1, C2);
pzmap(trFun)