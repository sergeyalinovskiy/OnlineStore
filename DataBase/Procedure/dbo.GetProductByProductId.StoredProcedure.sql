USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetProductByProductId]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductByProductId]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [Name], [CategoryId],[SeasonsId],[Picture],[Description],[Count],[Price]
      
  FROM [dbo].[vProduct] WITH(NOLOCK) WHERE [Id] = @Id

END


GO
