USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveNewProductInBasket4]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SaveNewProductInBasket4]
	@Id INT null,
	@ProductId INT ,
	@OrderId INT null,
	@Count INT null
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[Basket] WHERE ProductId = @ProductId and OrderId=@OrderId ),0) = 0
	BEGIN

		INSERT INTO [dbo].[Basket]
		    ([ProductId],
			[OrderId] ,
			[Count])
		       
		VALUES
         (@ProductId,
		 @OrderId,
		 @Count)
	END
	--ELSE
	--BEGIN
	--		UPDATE [dbo].[Basket]
	--		SET [ProductId]=@ProductId,
	--		[OrderId]=@OrderId,
	--		[Count]=@Count
	--		WHERE ProductId = @ProductId
	--END
END

GO
