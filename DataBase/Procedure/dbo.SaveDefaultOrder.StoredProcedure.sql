USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveDefaultOrder]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[SaveDefaultOrder]
	
	@UserId INT,
	@DateOrder date
	
	
AS
BEGIN
	
	BEGIN
		INSERT INTO [dbo].[Order]
		       ([UserId]
			   ,[Address] 
		       ,[StatusId]
		       ,[DateOrder])

		VALUES
           (@UserId,
			' не указан ',
			1,
			@DateOrder)

	END
	--SELECT CAST(SCOPE_IDENTITY() as int)
END


GO
