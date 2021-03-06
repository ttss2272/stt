/****** Object:  StoredProcedure [dbo].[CheckTimeSlot_SP]    Script Date: 12/08/2015 18:38:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 8 Dec 2015
-- Description:	To Check Time slot is already Aloctted or Free
-- =============================================
ALTER PROCEDURE [dbo].[CheckTimeSlot_SP] 
	(@BranchID int,
	@Day NVARCHAR(50),
	@SlotStartTime NVARCHAR(50),
	@SlotEndTime NVARCHAR(50))
AS
BEGIN
	DECLARE @ret int;
	--Duplicate Time Entry for same day Same Slot time Start time and End Time
	IF EXISTS (SELECT bld.BranchLectureDetailID FROM BranchLectureDetail bld INNER JOIN BranchLecture bl ON bl.BranchLectureID=bld.BranchLectureID where bl.BranchID=@BranchID AND bl.[DayName]=@Day AND LectureStartTime=@SlotStartTime AND LectureEndTime=@SlotEndTime)
		BEGIN 
			SET @ret =1
		END
	--Check Whether entered time is in between existing time slot
	ELSE IF EXISTS (SELECT BranchLectureDetailID FROM BranchLectureDetail bld INNER JOIN BranchLecture bl ON bl.BranchLectureID=bld.BranchLectureID where bl.[DayName] =@Day AND bl.BranchID=@BranchID AND (CAST (@SlotStartTime AS TIME)  BETWEEN CAST (LectureStartTime AS TIME) and CAST (LectureEndTime AS TIME)OR CAST (@SlotEndTime AS TIME) BETWEEN CAST (LectureStartTime AS TIME) and CAST (LectureEndTime AS TIME)))
	
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
