USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[SearchProducts]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SearchProducts]
	@Name NVARCHAR(max) = '',
	@CategoryId INT,
	@PriceMin INT,
	@PriceMax INT
AS
	SET NOCOUNT ON;
	Select * from dbo.vProduct
	
   WHERE [Name] like @Name + '%'
   and CategoryId=iif (@CategoryId=0,CategoryId,@CategoryId)
   and Price <@PriceMax 
   and [Price]>@PriceMin

GO
