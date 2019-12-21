# EmployeeDepartmentDB
Требуется придумать структуру для базы данных из двух таблиц: Персонал и отделы компании.
У каждого отдела должен быть руководитель(который числится сотрудником компании и должен быть записан 
в соответствующей таблице по сотрудникам).
1.Написать SQL запрос для создания этой базы данных.
2.Забить таблицы тестовыми данными.
3.Написать запрос, который выведет 10 фамилий и инициалов(через точку) сотрудников, их полное количество лет, название отдела 
и фамилия руководителя отдела, где работает сотрудник. 


# MS SQL

CREATE DATABASE EmployeeDepartmentDB          
COLLATE Cyrillic_General_CI_AS
GO

USE EmployeeDepartmentDB
GO

CREATE TABLE Employee
(
    ID int IDENTITY,
    LName nvarchar(20),
	FName nvarchar(20),
	MName nvarchar(20),
	Age int NULL,
	HeadDepartmentID int,          
	DepartmentID int NULL   
);

CREATE TABLE Department
(
    ID int IDENTITY,             
    DepartmentName nvarchar(20)
);

ALTER TABLE Employee
ADD CONSTRAINT PK_Employee PRIMARY KEY(ID) 
GO

ALTER TABLE Department
ADD CONSTRAINT PK_Department PRIMARY KEY(ID) 
GO

ALTER TABLE Employee
ADD CONSTRAINT HeadDepartmentID FOREIGN KEY (HeadDepartmentID) REFERENCES Employee(ID)
GO

ALTER TABLE Employee
ADD CONSTRAINT FK_Employee_Department FOREIGN KEY(DepartmentID) REFERENCES Department(ID)
ON DELETE SET NULL
GO
--IF OBJECT_ID('Employees') IS NOT NULL
--DROP TABLE Employees
--GO

INSERT Department 
(DepartmentName)
	VALUES
		(N'Закупка'),
		(N'Продажа'),
		(N'Логистика'),
		(N'Бухгалтерия')
GO

INSERT Employee 
(LName, FName, MName, Age, HeadDepartmentID, DepartmentID)
	VALUES
		(N'Белозерцев', N'Александр', N'Сергеевич' ,25, null, 4),
		(N'Богородицкая', N'Елена', N'Константиновна',37, 1, 4),
		(N'Нишнев', N'Владимир', N'Иванович',48, null, 3),
		(N'Кузнецов', N'Николай', N'Николаевич', 55, 5, 1),
		(N'Власова', N'Алла', N'Анатольевна', 21, 1, 4),
		(N'Гребенников', N'Павел', N'Васильевич',40, null, 1),
		(N'Захаров', N'Максим', N'Михайлович', 29, 5, 1),
		(N'Менкин', N'Антон', N'Алексеевич', 38, 9, 2),
		(N'Калинкин', N'Андрей', N'Николаевич', 25, 5, 1),
	    (N'Русанова', N'Татьяна', N'Олеговна',50, 12, 3),
		(N'Куприенко', N'Нина', N'Алексеевна', 28, null, 2),
		(N'Лаврова', N'Людмила', N'Владимировна', 35, 9, 2),
		(N'Великанова', N'Алена', N'Николаевна',41, 1, 4),
		(N'Федоров', N'Виктор', N'Борисович',39, 12, 3)
GO


Select TOP 10 e.ID, (e.LName+' '+SUBSTRING(e.FName, 1, 1)+'. '+ SUBSTRING(e.MName, 1, 1)+'.') as FullNAME,
       e.Age, d.DepartmentName, (m.LName) as DepartmentChief 
	   FROM Employee e
       JOIN Employee m ON e.HeadDepartmentID = m.ID
       JOIN Department d ON e.DepartmentID = d.ID
	   ORDER BY d.DepartmentName 

Select TOP 14 e.ID, (e.LName+' '+SUBSTRING(e.FName, 1, 1)+'. '+ SUBSTRING(e.MName, 1, 1)+'.') as FullNAME,
       e.Age, d.DepartmentName, (m.LName) as DepartmentChief 
	        FROM Employee e
       LEFT JOIN Employee m ON e.HeadDepartmentID = m.ID
       LEFT JOIN Department d ON e.DepartmentID = d.ID
	   ORDER BY d.DepartmentName

		
