USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetStatusOrder]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[GetStatusOrder]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Name FROM [dbo].[StatusOrder]

END



GO
