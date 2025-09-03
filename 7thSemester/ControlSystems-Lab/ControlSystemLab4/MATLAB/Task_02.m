function dy  = Task_02(t,y);  
    dy=zeros(2,1);  
    dy(1)=y(1);  
    dy(2)=-1*y(1)*y(1)*y(2)-y(1)+y(2);
end