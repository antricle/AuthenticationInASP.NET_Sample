CREATE PROCEDURE [dbo].[uspInsertUser]
	@username varchar(max),
	@password varchar(max)
AS
BEGIN
	INSERT INTO tblUsers values(@username, @password)
END