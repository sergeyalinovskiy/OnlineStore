USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteSeasonBySeasonId]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[DeleteSeasonBySeasonId]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[vSeason] WHERE Id = @Id),0) <> 0
	BEGIN

		DELETE FROM [dbo].[Season] WHERE Id = @Id
	END
END


GO
