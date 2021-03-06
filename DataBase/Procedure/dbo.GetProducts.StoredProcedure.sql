USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetProducts]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetProducts]
AS
BEGIN
	SET NOCOUNT ON;

			SELECT       
			    dbo.Product.Id,
				dbo.Product.Name,
				c.Id as CategoryId,
				c.Name as CategoryName,
				c.ParentId as ParentId,
				s.Id as SeasonsId,
				s.Name as SeasonsName,
				dbo.Product.Picture, 
				dbo.Product.Description,
				dbo.Product.Count,
				dbo.Product.Price

			FROM   
	            dbo.Product 
				INNER JOIN  dbo.Category as c ON dbo.Product.CategoryId = c.Id 
				INNER JOIN  dbo.Season as s ON dbo.Product.SeasonsId = s.Id
			END


GO
