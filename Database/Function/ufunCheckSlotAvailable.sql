--	=====================================================
--		Author : PriTesh D. Sortee
--		Created Date : 07 Dec 2015
--		Purpose : To Check Time slot is availble or not
--	=====================================================

CREATE FUNCTION ufunCheckSlotAvailable (@BranchID int,@Day NVARCHAR(50),@SlotStartTime NVARCHAR(50),@SlotEndTime NVARCHAR(50))
RETURNS int
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
	RETURN @ret;
END;
