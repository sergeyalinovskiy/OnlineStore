USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetProductInBasketIdByOrderId]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductInBasketIdByOrderId]
@OrderId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [ProductId]
      
  FROM [dbo].[Basket] WITH(NOLOCK) WHERE [OrderId]=@OrderId

END


GO
