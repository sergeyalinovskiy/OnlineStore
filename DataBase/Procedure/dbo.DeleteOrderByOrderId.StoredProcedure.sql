USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteOrderByOrderId]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[DeleteOrderByOrderId]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[Order] WHERE Id = @Id),0) <> 0
	BEGIN

		--EXEC [dbo].[DeleteBaseByProductListId] @Id, OUTPUT

		DELETE FROM [dbo].[Order] WHERE Id = @Id
	END
END

GO
