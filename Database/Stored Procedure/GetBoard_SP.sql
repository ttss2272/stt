/****** Object:  StoredProcedure [dbo].[GetBoard_SP]    Script Date: 12/16/2015 15:20:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 10 Dec 2015
-- Description:	Get Board Name to Bind Dorpdown
-- =============================================
ALTER PROCEDURE [dbo].[GetBoard_SP] 
	
AS
BEGIN
	Select 0 AS BoardID,'SELECT' AS BoardName
	UNION
	SELECT BoardID,BoardName FROM Board
	WHERE IsActive='True' AND IsDeleted<>'True'
	ORDER BY BoardName
END
