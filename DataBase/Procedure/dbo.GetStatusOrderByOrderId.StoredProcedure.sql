USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetStatusOrderByOrderId]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================



CREATE PROCEDURE [dbo].[GetStatusOrderByOrderId]
@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	
	    SELECT  
				dbo.StatusOrder.Name AS OrderStatusName

		FROM dbo.[Order]
			 INNER JOIN  dbo.StatusOrder ON dbo.[Order].StatusId = dbo.StatusOrder.Id 
			 INNER JOIN  dbo.[User] ON dbo.[Order].UserId = dbo.[User].Id
				WHERE  dbo.[Order].Id = @Id
			END


GO
