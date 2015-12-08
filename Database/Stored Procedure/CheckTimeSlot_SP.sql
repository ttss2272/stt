-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 8 Dec 2015
-- Description:	To Check Time slot is already Aloctted or Free
-- =============================================
CREATE PROCEDURE CheckTimeSlot_SP 
	(@BranchID int,
	@Day NVARCHAR(50),
	@SlotStartTime NVARCHAR(50),
	@SlotEndTime NVARCHAR(50))
AS
BEGIN
	DECLARE @ret int;
	--Duplicate Time Entry for same day Same Slot time Start time and End Time
	IF EXISTS (SELECT BranchLectureDetailID FROM BranchLectureDetail where BranchID=@BranchID AND [DayName]=@Day AND LectureStartTime=@SlotStartTime AND LectureEndTime=@SlotEndTime)
		BEGIN 
			SET @ret =1
		END
	--Check Whether entered time is in between existing time slot
	ELSE IF EXISTS (SELECT BranchLectureDetailID FROM BranchLectureDetail where [DayName] =@Day AND BranchID=@BranchID AND (CAST (@SlotStartTime AS TIME)  BETWEEN CAST (LectureStartTime AS TIME) and CAST (LectureEndTime AS TIME)OR CAST (@SlotEndTime AS TIME) BETWEEN CAST (LectureStartTime AS TIME) and CAST (LectureEndTime AS TIME)))
	
		BEGIN
			SET @ret=2
		END 
	--no duplication or in between of time
	ELSE
		BEGIN
			SET @ret=0
		END
	SELECT @ret
END
GO
