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
	
	IF EXISTS (SELECT BranchLectureDetailID FROM BranchLectureDetail where BranchID=@BranchID AND [DayName]=@Day AND LectureStartTime=@SlotStartTime AND LectureEndTime=@SlotEndTime)
		BEGIN 
			SET @ret =1
		END
	ELSE IF EXISTS (SELECT BranchLectureDetailID FROM BranchLectureDetail where BranchID=@BranchID AND [DayName]=@Day AND LectureStartTime=@SlotStartTime AND LectureEndTime=@SlotEndTime)
		BEGIN
			SET @ret=2
		END 
	
	ELSE
		BEGIN
			SET @ret=0
		END
	RETURN @ret;
END;
