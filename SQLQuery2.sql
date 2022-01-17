Create Database PHONEREntities
USE PHONEREntities




create table Roles(
Rol_ID INT identity primary key,
Rol nvarchar (50)
);

create table Empl_RegisterModel(
c_Reg_ID INT IDENTITY PRIMARY KEY ,
Rol_ID INT FOREIGN KEY (Rol_ID) REFERENCES Roles(Rol_ID),
FtName nvarchar(50),
LastName nvarchar (50),
Phone nvarchar (15),
Email nvarchar (100),
Emp_Rate decimal (9,2),
Emp_Hours decimal (9,2),
Emp_Wage decimal(9,2),
Pass nvarchar (50)
);
insert into Roles values('Admin')
insert into Roles values('Admin','Lindelani','Langa','0550555054','qwerty@gmail.com','50','4','200','Pass123')

create table Cust_RegisterModel(
c_Reg_ID INT IDENTITY PRIMARY KEY ,
Rol_ID INT FOREIGN KEY (Rol_ID) REFERENCES Roles(Rol_ID),
FtName nvarchar(50),
LastName nvarchar (50),
Phone nvarchar (15),
Email nvarchar (100),
Pass nvarchar (50),
);

create table Province(
Prov_ID INT IDENTITY PRIMARY KEY ,
Province nvarchar (50),
Del_Price decimal (9,2),
);


create table Color(
Col_ID INT identity primary key,
C_Name  nvarchar (50),
);

create table storage(
Storg_ID int identity primary key ,
Storg_Name nvarchar (50),
Storg_Rate decimal (9,2)
);
create table ProblemDesc(
Problem_ID int identity primary key,
Problem_Name nvarchar(50),
Problem_BscCost decimal
);
create table Device(
Brand_ID int  identity primary key,
Brand_Name nvarchar(50),
Brand_Rate decimal(9,2)
);
create table Operating_Sy(
OS_Id int identity primary key,
Device_os nvarchar (50),
OS_Rate decimal (9,2)
);


create table Cust_Request(
CustReq_Id int identity primary key,
Home_Adress nvarchar (100),
Pick_Date Date ,
pick_Time DateTime,
Brand_ID int foreign key (Brand_ID) REFERENCES Device(Brand_ID),
Problem_ID int foreign key (Problem_ID) REFERENCES ProblemDesc(Problem_ID), 
Storg_ID int foreign key (Storg_ID) REFERENCES storage(Storg_ID),
OS_Id int foreign key  (OS_Id) references Operating_Sy(OS_Id),
Col_ID INT FOREIGN KEY (Col_ID) REFERENCES Color(Col_ID),
IMEI_Num nvarchar(10),
Prov_ID INT FOREIGN KEY (Prov_ID) REFERENCES Province(Prov_ID),
B_Price decimal (9,2),
P_Price decimal(9,2) ,
T_Price decimal (9,2),
Dev_Status nvarchar (50)
);



create table Cust_WalkIn(
Walk_Id int identity primary key,
Walkin_Date Date ,
Walkin_Time DateTime,
Brand_ID int foreign key (Brand_ID) REFERENCES Device(Brand_ID),
Problem_ID int foreign key (Problem_ID) REFERENCES ProblemDesc(Problem_ID), 
Storg_ID int foreign key (Storg_ID) REFERENCES storage(Storg_ID),
OS_Id int foreign key  (OS_Id) references Operating_Sy(OS_Id),
Col_ID INT FOREIGN KEY (Col_ID) REFERENCES Color(Col_ID),
IMEI_Num nvarchar(50),
B_Price decimal(9,2) ,
);

