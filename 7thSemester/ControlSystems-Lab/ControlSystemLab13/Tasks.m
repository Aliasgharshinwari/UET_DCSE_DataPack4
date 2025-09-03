num = 1;
denum = [1 3 1];
g = tf(num,denum);
sys = feedback(g,1);
step(sys)
info = stepinfo(sys);
disp(info);
hold on

%Kp = 1;
%Ki = 1;
%Kd = 0;
%p = pid(Kp,Ki,Kd);
p = pidtune(g, 'pid');
sys_new = feedback(p*g,1);
step(sys_new)
info1 = stepinfo(sys_new);
disp(info1)