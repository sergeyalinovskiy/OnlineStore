USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetSeasonList]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[GetSeasonList]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Name FROM [dbo].[vSeason]

END



GO
