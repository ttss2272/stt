
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		pranjali Vidhate
-- Create date: 20-11-2015
-- Description:	To get no. of room available
-- =============================================
ALTER PROCEDURE [dbo].[GetNoOfDaysRoomAvailable_SP]  
	
AS
BEGIN
	Select br.RoomID,br.RoomName, COUNT (RoomAvailableID) AS 'NoOfDaysAvailaible' From RoomAvailable RoomAvail
	INNER JOIN BranchesRooms br
	ON br.RoomID=RoomAvail.RoomID
	Where RoomAvail.RoomID=RoomAvail.RoomID AND RoomAvail.IsActive ='True' AND RoomAvail.IsDeleted='False'
	GROUP BY br.RoomID,br.RoomName
END