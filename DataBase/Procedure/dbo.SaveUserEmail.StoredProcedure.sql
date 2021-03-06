USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveUserEmail]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaveUserEmail]
	@Id INT null,
	@UserId INT,
	@Email NVARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[Email] WHERE UserId = @UserId),0) = 0
	BEGIN

		INSERT INTO [dbo].[Email]
		       (
			   [UserId] 
		       ,[Email])
		VALUES
           (
		   	@UserId,
		   	@Email )

		   
	END
	ELSE
	BEGIN
			UPDATE [dbo].[Email]
			SET [UserId]=@UserId,
				[Email]=@Email

			WHERE UserId = @UserId
END
END

GO
