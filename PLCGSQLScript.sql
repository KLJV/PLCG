Use Master;
Go
Create
Database PLCGInformation
Go
Use PLCGInformation;
Go

Create
Table Locations
(LocationID int Not Null Constraint pkLocations Primary Key Identity(1,1)
,LocationCity nvarchar(100) Not Null
,LocationZip nvarchar(100) Not Null
,LocationState nvarchar(100) Not Null
,LocationCountry nvarchar(100) Not Null
,LocationRadius int Not Null
)

Create
Table Technologies
(TechnologyID int Not Null Constraint pkTechnologies Primary Key Identity(1,1)
,TechnologyName nvarchar(100) Not Null
,TechnologyType nvarchar(100) Not Null)

Create
Table Companies
(CompanyID int Not Null Constraint pkCompanies Primary Key Identity(1,1)
,CompanyName nvarchar(100) Not Null
,CompanyAddress nvarchar(100) Not Null
,CompanyLocationID int Not Null Constraint fkCompanyIDToLocationID Foreign Key References Locations(LocationID)
,CompanyTechnologyID int Not Null Constraint fkCompanyIDToTechnologyID Foreign Key References Technologies(TechnologyID))