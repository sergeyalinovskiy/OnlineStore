USE [OnlineStoreDB]
GO
/****** Object:  View [dbo].[vProduct]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vProduct]
AS
SELECT        dbo.Product.Id, dbo.Product.Name, dbo.Product.CategoryId, dbo.Product.SeasonsId, dbo.Product.Picture, dbo.Product.Description, dbo.Product.Count, dbo.Product.Price
FROM            dbo.Product INNER JOIN
                         dbo.Category ON dbo.Product.CategoryId = dbo.Category.Id INNER JOIN
                         dbo.Season ON dbo.Product.SeasonsId = dbo.Season.Id

GO
