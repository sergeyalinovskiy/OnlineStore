USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetOrders]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOrders]
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id] 
      ,[UserId]
      ,[Address]
      ,[StatusId]
      ,[DateOrder]
      
	  
  FROM [dbo].[Order] WITH(NOLOCK)

END



GO
