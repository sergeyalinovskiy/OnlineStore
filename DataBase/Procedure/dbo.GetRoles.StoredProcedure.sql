USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetRoles]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[GetRoles]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, RoleName FROM [dbo].[Role]

END



GO
