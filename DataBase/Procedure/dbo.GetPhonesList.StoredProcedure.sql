USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GetPhonesList]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPhonesList]
	AS
	SELECT Id,UserId, Phone FROM [dbo].[Phone]

GO
