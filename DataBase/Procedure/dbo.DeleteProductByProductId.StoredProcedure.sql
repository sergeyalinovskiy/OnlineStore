USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductByProductId]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteProductByProductId]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[vProduct] WHERE Id = @Id),0) <> 0
	BEGIN

		DELETE FROM [dbo].Product WHERE Id = @Id

	END
END


GO
