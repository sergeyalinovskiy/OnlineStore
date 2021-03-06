USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetOrdersList]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GetOrdersList]
AS
BEGIN
	SET NOCOUNT ON;
	
	    SELECT      dbo.[Order].Id, 
					dbo.[User].Id as UserId,
					dbo.[User].Name as UserName, 
					dbo.[User].LastName,
					dbo.[Order].Address,
					dbo.[Order].StatusId,
					dbo.StatusOrder.Name AS OrderStatusName, 
					dbo.[Order].DateOrder

		FROM dbo.[Order]
			 INNER JOIN  dbo.StatusOrder ON dbo.[Order].StatusId = dbo.StatusOrder.Id 
			 INNER JOIN  dbo.[User] ON dbo.[Order].UserId = dbo.[User].Id
			
			END


GO
