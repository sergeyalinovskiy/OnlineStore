USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategoryByCategoryId]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[DeleteCategoryByCategoryId]
	@Id INT
	
AS
BEGIN
	SET NOCOUNT ON;


		DELETE FROM [dbo].[Category] WHERE Id = @Id
END


GO
