USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveUser229]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[SaveUser229]
	@Id INT ,
	@UserLogin NVARCHAR(50),
	@Password NVARCHAR(50),
	@UserName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@RoleId INT,
	@Phone NVARCHAR(50),
	@Email NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[User] WHERE Id = @Id),0) = 0
	BEGIN

		INSERT INTO [dbo].[User]
		       (
			   [UserLogin] 
		       ,[Password]
		       ,[Name]
			   ,[LastName])
		VALUES
           (
		   	@UserLogin,
		   	@Password ,
		   	@UserName ,
		   	@LastName)

			 SET @Id = SCOPE_IDENTITY();

		   INSERT INTO [dbo].[UserRole]
		       ([UserLoginId],
			   [RoleId] )
		   VALUES
           (@Id,
		   @RoleId )

		   INSERT INTO [dbo].[Phone]
		       ([UserId],
			   [Phone] )
		   VALUES
           (@Id,
		   @Phone )

		   INSERT INTO [dbo].[Email]
		       ([UserId],
			   [Email] )
		   VALUES
           (@Id,
		    @Email )
			
	END
	ELSE
	BEGIN
			UPDATE [dbo].[User]
			SET [UserLogin]=@UserLogin,
				[Password]=@Password, 
				[Name]=@UserName,
				[LastName]=@LastName

			WHERE Id = @Id

			UPDATE [dbo].[UserRole]
			SET [RoleId]=@RoleId

			Where UserLoginId=@Id

			UPDATE [dbo].[Phone]
			SET [Phone]=@Phone

			Where UserId=@Id

			UPDATE [dbo].[Email]
			SET [Email]=@Email
			Where UserId=@Id
END
END

GO
