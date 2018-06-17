USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveNewProductInBasket]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SaveNewProductInBasket]
	@Id INT null,
	@ProductId INT ,
	@OrderId INT null,
	@Count INT null
AS
BEGIN
		INSERT INTO [dbo].[Basket]
		    ( 
			 [ProductId],
			[OrderId] ,
			[Count])
		       
		VALUES
         (
		  @ProductId,
		 @OrderId,
		 @Count)
	END


GO
