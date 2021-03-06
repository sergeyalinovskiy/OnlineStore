USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveUserRole]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[SaveUserRole]
	@Id INT ,
	@RoleId INT
	
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[UserRole] WHERE UserLoginId = @Id),0) = 0
	BEGIN

		INSERT INTO [dbo].[UserRole]
		       (
			   [UserLoginId] 
		       ,[RoleId]
		       )
		VALUES
           (
		   	@Id,
		   	@RoleId)
		   
	END
	ELSE
	BEGIN
			UPDATE [dbo].[UserRole]
			SET [UserLoginId]=@Id,
				[RoleId]=@RoleId

			WHERE UserLoginId = @Id

	
END
END

GO
