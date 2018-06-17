USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetOrderByUserId]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[GetOrderByUserId]
	@UserId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id] 
      ,[UserId]
      ,[Address]
      ,[StatusId]
      ,[DateOrder]
      
	  
  FROM [dbo].[Order] WITH(NOLOCK) WHERE [UserId] = @UserId

END



GO
