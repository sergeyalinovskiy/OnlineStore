USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateOrder]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[UpdateOrder]
	@Id INT null,
	@Address NVARCHAR(max) null,
	@StatusId INT,
	@DateOrder DateTime null
AS
BEGIN
	
	BEGIN
			UPDATE [dbo].[Order]
			SET 
				[Address]=@Address, 
				[StatusId]=@StatusId,
				[DateOrder]=@DateOrder

			WHERE Id = @Id
	END
END


GO
