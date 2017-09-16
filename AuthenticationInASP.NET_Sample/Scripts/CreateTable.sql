CREATE TABLE tblUsers(
   Id [int] IDENTITY(1,1) NOT NULL,
   Username VARCHAR(max) NOT NULL,
   Password VARCHAR(max) NOT NULL,
   PRIMARY KEY (Id)
);