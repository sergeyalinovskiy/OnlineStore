USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateProductCountInBasket]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateProductCountInBasket]
	@Id INT null,
	@ProductId INT ,
	@OrderId INT null,
	@Count INT null
AS
BEGIN
	SET NOCOUNT ON;

			UPDATE [dbo].[Basket]
			SET [ProductId]=@ProductId,
			[OrderId]=@OrderId,
			[Count]=@Count
			WHERE ProductId = @ProductId and OrderId=@OrderId
	END


GO
