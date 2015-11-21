
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Pranjali Vidhate
-- Create date: 20-11-2015
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetRoomAvailableDetail_SP] 
	(
	   @RoomID int 
	)
AS
BEGIN
	SELECT RoomAvailableID,RoomID,[DAY],StartTime,EndTime FROM RoomAvailable
	WHERE RoomID LIKE CASE WHEN @RoomID<>0 THEN @RoomID ELSE CONVERT (NVARCHAR(50),RoomID) END
	AND IsActive='True' AND IsDeleted='False'
END