USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryByCategoryId]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCategoryByCategoryId]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [Name], [ParentId]
      
  FROM [dbo].[vCategory] WITH(NOLOCK) WHERE [Id] = @Id

END


GO
