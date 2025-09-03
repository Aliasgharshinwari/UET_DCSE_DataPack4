function dy1 =Task_01(t,y);  
    dy1=zeros(5,1);  
    dy1(1)=y(2);  
    dy1(2)=y(3);  
    dy1(3)=y(4);  
    dy1(4)=y(5);  
    dy1(5)=-2*y(5)-24*y(4)-48*y(3)-24*y(2)-20*y(1)-10; 
end