CREATE TABLE Product(
	`Id` int AUTO_INCREMENT NOT NULL,
	`Name` nvarchar(50) NULL,
	`Cost` Double NULL,
	`CreatedDate` datetime(3) NULL,
 CONSTRAINT `PK_Product` PRIMARY KEY 
(
	`Id` ASC
) 
);
