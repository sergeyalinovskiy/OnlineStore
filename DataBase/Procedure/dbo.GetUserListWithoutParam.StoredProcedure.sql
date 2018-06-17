USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetUserListWithoutParam]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[GetUserListWithoutParam]
	--@Id INT
AS
BEGIN
	SET NOCOUNT ON;

			SELECT    
			    dbo.[User].Id,
				dbo.[User].UserLogin,
				dbo.[User].Password, 
				dbo.[User].Name, 
				dbo.[User].LastName
				
			FROM  dbo.[User]
END


GO
