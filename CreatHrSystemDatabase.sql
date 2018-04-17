CREATE DATABASE HRSystem
go
use HRSystem
go


CREATE TABLE Department (
	DepartmentId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	[Description] VARCHAR(200) NOT NULL,
)

CREATE TABLE Project (
	ProjectId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	[Description] VARCHAR(200) NOT NULL,
)

CREATE TABLE Place (
	PlaceId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	PostalCode INT NOT NULL,
	Place VARCHAR(200) NOT NULL,
)

CREATE TABLE Employee (
	EmployeeId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Firstname VARCHAR(100) NOT NULL,
	Lastname VARCHAR(100) NOT NULL,
	Birthday date NOT NULL,
	Salary INT NULL,
	[Address] VARCHAR(200) NULL,
	FkDepartment INT FOREIGN KEY REFERENCES Department(DepartmentId) NOT NULL,
	FkPlace INT FOREIGN KEY REFERENCES PLACE(PlaceId) NOT NULL,
	FkBoss INT FOREIGN KEY REFERENCES Employee(EmployeeId) NULL,
)

CREATE TABLE EmployeeProject (
	ProjectId INT FOREIGN KEY REFERENCES Project(ProjectId) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employee(EmployeeId)  NOT NULL,
	CONSTRAINT primaryKey PRIMARY KEY (ProjectId, EmployeeId),
)

INSERT INTO Department (Name, Description)
	VALUES 
		('Informatik','Fachbereich Informatik, Entwicklung & Systemtechnik'),
		('Personalwesen', 'Fachbereich Personalwesen, Koordination & Unterhalt'),
		('Finanzenwesen', 'Fachbereich Finanzwesen, Lohn & Zahlungen');

INSERT INTO Project(Name, Description)
	VALUES 
		('NCC2018', 'New Client Computer 2018'),
		('Evaluation Citrix', 'Neuanschaffung der Citrix Software'),
		('GLAP', 'Globale Lohn Anpassung'),
		('NfNeu', 'Neueintrittformular neu erstellen');

INSERT INTO Place (PostalCode, Place)
	VALUES 
		(6376, 'Emmetten'),
		(6375, 'Beckenried'),
		(6030, 'Ebikon'),
		(6000, 'Luzern');

INSERT INTO Employee(Firstname, Lastname, Birthday, FkBoss, Salary, Address, FkDepartment, FkPlace)
	VALUES 
		('Timon', 'Kurmann', '2000-03-01', NULL, 5500, 'Sonnhaldenstr. 78', 1, 3),
		('Steven', 'Würsch', '2000-06-30', '1', 6500, 'Weidli 3', 1, 1),
		('Peter', 'Knusprig', '1999-07-11', '2', 4500, 'Himmelgasse 3', 2, 4),
		('Tamara', 'Beinlos', '1998-11-25', '2', 4500, 'Ockerweg 29', 3, 2);

INSERT INTO EmployeeProject (ProjectId, EmployeeId)
	VALUES 
		(1, 2),
		(2, 2),
		(2, 3),
		(3, 4);