USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetEmailsList]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetEmailsList]
	AS
	SELECT Id,UserId, Email FROM [dbo].[Email]

GO
