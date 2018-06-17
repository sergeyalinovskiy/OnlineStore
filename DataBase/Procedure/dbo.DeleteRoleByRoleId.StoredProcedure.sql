USE [OnlineStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteRoleByRoleId]    Script Date: 6/17/2018 10:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[DeleteRoleByRoleId]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[vRole] WHERE Id = @Id),0) <> 0
	BEGIN

		DELETE FROM [dbo].[Role] WHERE Id = @Id
	END
END


GO
