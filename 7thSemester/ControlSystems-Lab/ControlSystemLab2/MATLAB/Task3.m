C1 = [10];
C2 = [1, 2, 20];

G = tf (C1, C2); 

t = 0:1/100:10;
f = 1;
u = sin(2*pi*f*t);
y1=lsim (G, u, t); 
y2=step (G, 0:0.01:10); 
y3=step (G, 5:0.01:10); 
temp=zeros(500, 1); 
y3= [temp; y3]; 
y=y1+y2+2*y3; 
plot (t,y) 