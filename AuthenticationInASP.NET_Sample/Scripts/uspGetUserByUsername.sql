SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetUserByUsername]
      @Username varchar(max)
AS
BEGIN
      SET NOCOUNT ON;
      SELECT *
      FROM tblUsers WHERE Username=@Username
END