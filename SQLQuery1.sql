CREATE DATABASE PMDB;
GO

USE PMDB;
GO

CREATE SCHEMA PM;
GO

CREATE TABLE PM.Companies
(
	CRNNO INT PRIMARY KEY,
	CompanyName	nvarchar(50) not null,

)
GO 

CREATE TABLE PM.Managers
(
	Id int primary key not null,
	Email varchar(100) not null,
)
GO

CREATE TABLE PM.Projects
(
	PRJNO int primary key not null,
	Title varchar(100) not null,
	ManagerId int foreign key references PM.Managers(Id) not null,
	StartDate datetime2 not null,
	InitialCost decimal(18,2) not null ,
	Parked bit not null,
	CRNNO int not null,
	foreign key (CRNNO) references PM.Companies(CRNNO)
)
GO

CREATE TABLE PM.Technology
(
	Id int primary key not null,
	Name varchar(60) not null,
)
GO

CREATE TABLE PM.ProjectTechnology
(
	PRJNO int foreign key references PM.Projects(PRJNO) not null,
	TechnologyId int foreign key references PM.Technology(Id) not null,
	Primary key(PRJNO, TechnologyId) -- composite key
)


-- Add Unique Constarins 
Alter Table PM.Managers
 Add constraint  UN_Email UNIQUE(Email)

 -- insert:
 USE PMDB;
 GO

 INSERT INTO PM.Companies VALUES 
		(100, N'Company A'),
		(101, N'Company B'),
		(102, N'Company C'),
		(104, N'Company D'),
		(105, N'Company E'),
		(106, N'Company F');

GO

INSERT INTO PM.Managers (Id ,Email) VALUES (201, 'peter@fake.com');
INSERT INTO PM.Managers (Id ,Email) VALUES (202, 'mike@fake.com');
INSERT INTO PM.Managers (Id ,Email) VALUES (203, 'reem@fake.com');
INSERT INTO PM.Managers (Id ,Email) VALUES (204, 'salah@fake.com'); 

GO
INSERT INTO PM.Technology(Id , Name) VALUES (301, 'SQL SERVER');
INSERT INTO PM.Technology(Id , Name) VALUES (302, 'ASP NET CORE');
INSERT INTO PM.Technology(Id , Name) VALUES (303, 'ANGULAR');
INSERT INTO PM.Technology(Id , Name) VALUES (304, 'REACT');
INSERT INTO PM.Technology(Id , Name) VALUES (305, 'WPF');
INSERT INTO PM.Technology(Id , Name) VALUES (306, 'ANDROID');
INSERT INTO PM.Technology(Id , Name) VALUES (307, 'ORACLE');
INSERT INTO PM.Technology(Id , Name) VALUES (308, 'PHP'); 

GO

INSERT INTO PM.Projects ( PRJNO, Title, ManagerId, StartDate, InitialCost, Parked, CRNNO)
     VALUES ( 401, 'CMS', 201, '2022-01-01', 15000000, 0, 101),
            ( 402, 'ERP', 202, '2022-02-01', 20000000, 0, 102),
            ( 403, 'CMS', 203, '2022-03-01', 15000000, 0, 105),
            ( 404, 'Authenticator', 204, '2022-04-01', 150000, 0, 101),
            ( 405, 'CRM-DESKTOP', 203, '2022-05-01', 20000000, 0, 104),
            ( 406, 'ERP', 204, '2022-06-01', 20000000, 0, 105),
            ( 407, 'HUB', 204, '2022-06-01', 20000000, 1, 104);

GO

INSERT INTO PM.ProjectTechnology VALUES 
        ( 401, 301), 
        ( 401, 302),
		( 401, 303),
		( 402, 301), 
        ( 402, 302),
		( 402, 304),
		( 403, 301), 
        ( 403, 302),
		( 403, 308),
		( 404, 306),
		( 405, 307),
		( 405, 305),
		( 406, 307),
		( 406, 308);
GO

SELECT PRJNO, Title, ManagerId, StartDate, InitialCost, Parked, CRNNO
FROM PM.Projects 

SELECT *
FROM PM.Projects 

SELECT PRJNO, Title
FROM PM.Projects

-- TO MAKE FILTERATION WE SHOULD USE WHERE :

SELECT * 
FROM PM.Projects WHERE InitialCost >= 1000000

SELECT * 
FROM PM.Projects WHERE NOT InitialCost >= 1000000

SELECT * 
FROM PM.Projects WHERE InitialCost >= 1000000 AND StartDate	>= '2022-03-01'

SELECT * 
FROM PM.Projects WHERE InitialCost >= 1000000 OR StartDate	>= '2022-03-01'

-- LIKE: USE FOR EXPRESIONS AND SIMILARITY!:
   -- XX% START WITH XX 
   SELECT * FROM PM.Projects WHERE Title like 'C%'

   -- %XX END  WITH XX 
   SELECT * FROM PM.Projects WHERE Title like '%P'

   -- %XX% CONTAINS XX ! :
   SELECT * FROM PM.Projects WHERE Title like '%DESK%'
	
      -- LIKE _R%
    SELECT * FROM PM.Projects WHERE Title like '_R_';
    SELECT * FROM PM.Projects WHERE InitialCost like '_5%';



-- TOP:
SELECT TOP 3 * FROM PM.Projects
SELECT TOP 2 PERCENT * FROM PM.Projects

-- ORDER BY:
SELECT * FROM PM.Projects ORDER BY StartDate;

SELECT * FROM PM.Projects ORDER BY StartDate DESC;

SELECT * FROM PM.Projects ORDER BY InitialCost, StartDate DESC;

-- GROUP BY: WE USE IT WHRN WE WANT TO GROUP DATA IN THE SAME TABLE DEPNDEING ON A COLUMNN
-- WE SHOULD USE AGGREGATES FUNCTIONS WHEN USING GORUP BY: 

SELECT Title FROM PM.Projects GROUP BY Title; -- HERE WITHOUT AGGREGATNIO SO IT WILL JUST  GET ALL TITLES WTHOUT DUBLICATES!

SELECT Title , COUNT(*) FROM PM.Projects  GROUP BY Title;

SELECT ManagerId, COUNT(*) FROM PM.Projects GROUP BY ManagerId;

SELECT ManagerId, COUNT(*) FROM PM.Projects
	WHERE Parked = 0 
	GROUP BY ManagerId 
	HAVING COUNT(*) > 1;

-- HAVING : MAKDE FILTARATION AFTER THE GROUB BY!

-- DISTINT : TO REMOVE THE DUPLICATES

SELECT DISTINCT Title FROM PM.Projects;

SELECT DISTINCT InitialCost FROM PM.Projects;

-- JONIS! :  
-- INNER JOIN :

SELECT PRJNO, Title, Email AS N'Manager Email For This Project' FROM 
PM.Projects AS P
INNER JOIN 
PM.Managers AS M 
ON P.ManagerId = M.Id; 

-- LEFT JOIN (ALL ROWS FORM LEFT TABLE EVEN NO MATCH ! ): 
SELECT  * FROM PM.Companies;
SELECT  * FROM PM.Projects;

SELECT PRJNO, Title,CompanyName FROM PM.Companies AS C LEFT JOIN PM.Projects AS P ON P.CRNNO = C.CRNNO;


SELECT PRJNO, Title,CompanyName FROM PM.Projects AS P LEFT JOIN PM.Companies AS C  ON P.CRNNO = C.CRNNO;


SELECT PRJNO, Title,CompanyName FROM PM.Companies AS C RIGHT JOIN PM.Projects AS P ON P.CRNNO = C.CRNNO;

SELECT PRJNO, Title,CompanyName FROM PM.Projects AS P RIGHT JOIN PM.Companies AS C  ON P.CRNNO = C.CRNNO;

-- FULL JOIN LEFT AND RIGTH AT SAME TIME !! 
SELECT PRJNO, Title,CompanyName FROM PM.Projects AS P FULL JOIN PM.Companies AS C  ON P.CRNNO = C.CRNNO;

-- SUBQUERY:
SELECT  * FROM PM.Projects;
SELECT  * FROM PM.ProjectTechnology;
SELECT  * FROM PM.Technology;


UPDATE PM.Projects SET InitialCost = InitialCost * 1.05
WHERE PRJNO IN(SELECT PRJNO FROM PM.ProjectTechnology 
WHERE TechnologyId = (SELECT Id FROM PM.Technology WHERE NAME = 'ORACLE'));