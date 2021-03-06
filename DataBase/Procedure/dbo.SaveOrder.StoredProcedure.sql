USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveOrder]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[SaveOrder]
	@Id INT null,
	@UserId INT,
	@Address NVARCHAR(max),
	@StatusId INT,
	@DateOrder DateTime
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[Order] WHERE Id = @Id),0) = 0
	BEGIN
		INSERT INTO [dbo].[Order]
		       ([UserId]
			   ,[Address] 
		       ,[StatusId]
		       ,[DateOrder])
		VALUES
           (@UserId,
			@Address ,
			@StatusId ,
			@DateOrder)
	END
	ELSE
	BEGIN
			UPDATE [dbo].[Order]
			SET [UserId]=@UserId,
				[Address]=@Address, 
				[StatusId]=@StatusId,
				[DateOrder]=@DateOrder

			WHERE Id = @Id
	END
END


GO
