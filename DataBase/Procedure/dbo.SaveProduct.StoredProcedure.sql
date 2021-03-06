USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveProduct]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[SaveProduct]
	@Id INT null,
	@Name NVARCHAR(50),
	@CategoryId INT,
	@SeasonsId INT,
	@Picture NVARCHAR(50),
	@Description NVARCHAR(50),
	@Count INT,
	@Price INT
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[vProduct] WHERE Id = @Id),0) = 0
	BEGIN

		INSERT INTO [dbo].[Product]
		       ([Name]
			   ,[CategoryId] 
		       ,[SeasonsId]
		       ,[Picture]
			   ,[Description]
			   ,[Count]
			   ,[Price])

		VALUES
           (@Name,
			@CategoryId ,
			@SeasonsId ,
			@Picture ,
			@Description,
			@Count ,
			@Price )
	END
	ELSE
	BEGIN
			UPDATE [dbo].[Product]
			SET [Name]=@Name,
				[CategoryId]=@CategoryId, 
				[SeasonsId]=@SeasonsId,
				[Picture]=@Picture,
				[Description]=@Description,
				[Count]=@Count,
				[Price]=@Price

			WHERE Id = @Id
	END
END


GO
