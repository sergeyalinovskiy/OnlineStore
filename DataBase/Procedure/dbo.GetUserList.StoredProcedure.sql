USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetUserList]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GetUserList]
	--@Id INT
AS
BEGIN
	SET NOCOUNT ON;

			SELECT    
			    dbo.[User].Id,
				dbo.[User].UserLogin,
				dbo.[User].Password, 
				dbo.[User].Name, 
				dbo.[User].LastName, 
				dbo.UserRole.RoleId,
				dbo.Role.RoleName, 
				dbo.Phone.Id AS PhoneId, 
				dbo.Phone.Phone,
				dbo.Email.Id AS EmailId, 
                dbo.Email.Email
FROM			         dbo.UserRole INNER JOIN
                         dbo.Role ON dbo.UserRole.RoleId = dbo.Role.Id INNER JOIN
                         dbo.Email INNER JOIN
                         dbo.[User] ON dbo.Email.UserId = dbo.[User].Id INNER JOIN
                         dbo.Phone ON dbo.[User].Id = dbo.Phone.UserId ON dbo.UserRole.UserLoginId = dbo.[User].Id

END


GO
