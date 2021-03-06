/****** Object:  StoredProcedure [dbo].[BindRoomName_SP]    Script Date: 12/16/2015 15:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pranjali
-- Create date: 20-11-2015
-- Description:	To bind room name on dropdown
-- =============================================
ALTER PROCEDURE [dbo].[BindRoomName_SP]	
	(
	@BranchID int	
 	)
AS
BEGIN
	
	SELECT 0 AS RoomID,'Select' AS RoomName 
UNION
 SELECT rm.RoomID,rm.RoomName FROM BranchesRooms rm
 INNER JOIN Branch br
 ON br.BranchID=rm.BranchID
 WHERE 
 br.BranchID LIKE CASE WHEN @BranchID<>0 THEN @BranchID ELSE CONVERT(NVARCHAR(50),@BranchID) END 
AND br.IsActive=1 AND br.IsDeleted='False'	
ORDER BY RoomName
    
END
