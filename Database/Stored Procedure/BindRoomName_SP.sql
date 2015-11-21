USE [NewTimeTableDB]
GO
/****** Object:  StoredProcedure [dbo].[BindRoomName_SP]    Script Date: 11/20/2015 11:15:31 ******/
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
	@RoomID int
 	)
AS
BEGIN
	
	SELECT 0 AS RoomID,'Select' AS RoomName 
UNION
 SELECT RoomID,RoomName FROM BranchesRooms WHERE 
 RoomID LIKE CASE WHEN @RoomID<>0 Then @RoomID ELSE CONVERT(NVARCHAR(50),RoomID) END
AND IsActive='True' AND IsDeleted='False'	
    
END