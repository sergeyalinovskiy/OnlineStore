USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryList]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategoryList]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Name,ParentId  FROM [dbo].[vCategory]

END
GO
