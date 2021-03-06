USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetProductsInBasketsByBasketId]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[GetProductsInBasketsByBasketId]
@Id INT
AS
BEGIN
	SET NOCOUNT ON;

			SELECT           dbo.Basket.Id,
							dbo.[Order].Id as OrderId,
							dbo.[Order].UserId, 
							dbo.[Order].Address,
							dbo.[Order].StatusId, 
							dbo.[Order].DateOrder,
							dbo.Product.Id as ProductId,
							dbo.Product.Name,
							
							dbo.Category.Id as CategoryId,
							dbo.Category.Name as CategoryName,
							dbo.Product.SeasonsId, 
							dbo.Product.Picture,
							dbo.Product.Description,
							dbo.Product.Price,
							dbo.Basket.Count
FROM					 dbo.Basket INNER JOIN
                         dbo.[Order] ON dbo.Basket.OrderId = dbo.[Order].Id INNER JOIN
                         dbo.Product ON dbo.Basket.ProductId = dbo.Product.Id INNER JOIN
						 dbo.Category ON dbo.Product.CategoryId= dbo.Category.Id
WHERE dbo.Basket.Id=@Id

END


GO
