USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveCategory]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaveCategory]
	@Id INT null,
	@Name NVARCHAR(50),
	@ParentId INT
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[vCategory] WHERE Id = @Id),0) = 0
	BEGIN

		INSERT INTO [dbo].[Category]
		       ([Name]
			   ,[ParentId]) 
		VALUES
           (@Name,
			@ParentId )
	END
	ELSE
	BEGIN
			UPDATE [dbo].[Category]
			SET [Name]=@Name,
				[ParentId]=@ParentId 
				

			WHERE Id = @Id
	END
END


GO
