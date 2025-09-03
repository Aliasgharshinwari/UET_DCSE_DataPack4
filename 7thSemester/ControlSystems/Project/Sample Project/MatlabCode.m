clear all;
clc;
%%%
A = [-0.435 0.209 0.02;
    0.268 -0.394 0;
    0.227 0 -0.02]
B = [1;
    0;
    0]
C = [0.0003 0 0];
D = [0];

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

%% 
sys = feedback(Sys1,1);
step(sys)
info = stepinfo(sys);
disp(info);
hold on
steady_state_value = info.SettlingMin;  % Approximate steady-state value
reference_value = 1;  % For step input, reference is 1
sse = abs(reference_value - steady_state_value);
disp(['Steady-State Error (Step Input): ', num2str(sse)]);

%% 

%Kp = 249.004887914577;
%Ki = 3.01944271063754;
%Kd = -7758.2518873453;
%p = pid(Kp,Ki,Kd);
p = pidtune(Sys1, 'pid');
sys_new = feedback(p*Sys1,1);
step(sys_new)
info1 = stepinfo(sys_new);
disp(info1);
steady_state_value = info1.SettlingMin;  % Approximate steady-state value
reference_value = 1;  % For step input, reference is 1
sse = abs(reference_value - steady_state_value);
disp(['Steady-State Error (Step Input): ', num2str(sse)]);

%% 
% Ramp and parabolic response
figure;

% Time vector
t = 0:0.01:2000;  % Simulation time (adjust as needed)

% Ramp Input
ramp_input = t;
[response_ramp, t_ramp] = lsim(sys_new, ramp_input, t);
subplot(2,1,1);
plot(t_ramp, response_ramp, 'b', 'LineWidth', 1.5);
hold on;
plot(t_ramp, ramp_input, 'r--', 'LineWidth', 1); % Reference ramp
title('Ramp Response');
xlabel('Time (s)');
ylabel('Output');
legend('System Response', 'Ramp Input');
grid on;

% Parabolic Input
parabolic_input = 0.5 * t.^2;
[response_parabolic, t_parabolic] = lsim(sys_new, parabolic_input, t);
subplot(2,1,2);
plot(t_parabolic, response_parabolic, 'g', 'LineWidth', 1.5);
hold on;
plot(t_parabolic, parabolic_input, 'r--', 'LineWidth', 1); % Reference parabolic
title('Parabolic Response');
xlabel('Time (s)');
ylabel('Output');
legend('System Response', 'Parabolic Input');
grid on;
% Analyzing the steady-state errors for ramp and parabolic inputs
steady_state_error_ramp = abs(ramp_input(end) - response_ramp(end));
disp(['Steady-State Error for Ramp Input: ', num2str(steady_state_error_ramp)]);
steady_state_error_parabolic = abs(parabolic_input(end) - response_parabolic(end));
disp(['Steady-State Error for Parabolic Input: ', num2str(steady_state_error_parabolic)]);
% Order of the polynomial
%check controllability
%P = ctrb(A,B)
%rank_of_ctrbl_matrix = rank(P);
%disp('The rank of controllabilty')
%rank_of_ctrbl_matrix

%check observability
%Q = obsv(A , C)
%rank_of_obsv = rank(Q);
%disp('The rank of observebility');
%rank_of_obsv


%desrired_eignvalues1 = [-20 -50 -90];
%L = place (A',C',desrired_eignvalues1)';
%L


%Design Controlaibility
%desrired_eignvalues2 = [-4 -10 -18];
%K = place (A,B,desrired_eignvalues2);    %for K1, K2, K3
%K

%sisotool(Sys1)
%t=[0:0.1:5.6]'
%stepinfo(simout,t)

