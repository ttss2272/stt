
/****** Object:  StoredProcedure [dbo].[GetUserType_SP]    Script Date: 11/19/2015 12:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kalpesh Katyare
-- Create date: 9 Nov 2015
-- Description:	Get UserType
-- =============================================
ALTER PROCEDURE [dbo].[GetUserType_SP] --0, ''
	@UserTypeID int
AS
BEGIN
SELECT 0 AS 'UserTypeID','Select' AS UserTypeName
UNION
	SELECT [UserTypeID], [UserTypeName] FROM [UserType]
	WHERE [UserTypeID] LIKE CASE WHEN @UserTypeID<>0 THEN @UserTypeID ELSE CONVERT (NVARCHAR(50),UserTypeID) END
	AND IsActive = 'True'
END