USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveUserPhone]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[SaveUserPhone]
	@Id INT null,
	@UserId INT,
	@Phone NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[Phone] WHERE UserId = @UserId),0) = 0
	BEGIN

		INSERT INTO [dbo].[Phone]
		       (
			   [UserId] 
		       ,[Phone])
		VALUES
           (
		   	@UserId,
		   	@Phone )

		   
	END
	ELSE
	BEGIN
			UPDATE [dbo].[Phone]
			SET [UserId]=@UserId,
				[Phone]=@Phone

			WHERE Id = @Id
END
END

GO
