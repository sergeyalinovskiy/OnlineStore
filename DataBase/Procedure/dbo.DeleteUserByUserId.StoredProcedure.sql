USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserByUserId]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[DeleteUserByUserId]
	@Id INT
AS
BEGIN
	
	BEGIN
		DELETE FROM [dbo].Email WHERE UserId=@Id
		DELETE FROM [dbo].Phone WHERE UserId=@Id
		DELETE FROM [dbo].UserRole WHERE UserLoginId=@Id
		DELETE FROM [dbo].[User] WHERE Id = @Id
	END
END


GO
