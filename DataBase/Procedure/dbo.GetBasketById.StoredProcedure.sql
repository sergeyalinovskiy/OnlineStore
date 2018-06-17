USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetBasketById]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[GetBasketById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id]
      ,[Name]
      ,[OrderId]
      ,[ProductId]
      ,[Picture]
      ,[Count]
      ,[Price]
      
	  
  FROM [dbo].[vBasket] WITH(NOLOCK) WHERE [Id] = @Id

END

GO
