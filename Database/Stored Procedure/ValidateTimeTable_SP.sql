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
-- Create date: 09 Dec 2015
-- Description:	Applying rules to the Timetable
-- =============================================
CREATE PROCEDURE ValidateTimeTable_SP 
(
	@TeacherShortName nvarchar(20),
	@ClassRoomID int,
	@LectStartTime NVARCHAR(50),
	@LectEndTime NVARCHAR(50),
	@Day NVARCHAR(50),
	@BatchID int
)
AS
DECLARE @msg NVARCHAR(MAX)
BEGIN
	-- CHECK IF time slot for perticular time is already allocted to any room
	IF EXISTS (Select ttd.TimeTableDetailID FROM TimeTableDetail ttd INNER JOIN TimeTable tt ON tt.TimeTableID=ttd.TimeTableID WHERE ttd.[Day]=@Day AND ttd.LectStartTime=@LectStartTime AND ttd.LectEndTime=@LectEndTime AND ttd.RoomID =@ClassRoomID)
		BEGIN
			SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=21)
		END
	-- CHECK IF time slot for perticular time is already allocted to any Batch
	ELSE IF EXISTS (Select ttd.TimeTableDetailID FROM TimeTableDetail ttd INNER JOIN TimeTable tt ON tt.TimeTableID=ttd.TimeTableID WHERE ttd.[Day]=@Day AND ttd.LectStartTime=@LectStartTime AND ttd.LectEndTime=@LectEndTime AND tt.BatchID=@BatchID)
		BEGIN
			SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=23)
		END
	--check Teahcer overlap timing
	
	ELSE IF EXISTS(SELECT t.TeacherID, t.TeacherName FROM TimeTableDetail ttd
INNER JOIN  TeacherSubject ts
ON ts.TeacherSubjectID=ttd.TeacherSubjectID
INNER JOIN Teacher t
ON t.TeacherID=ts.TeacherID
INNER JOIN TimeTable tt
ON tt.TimeTableID =ttd.TimeTableID
WHERE ttd.[Day]=@Day AND ttd.LectStartTime=@LectStartTime AND ttd.LectEndTime=@LectEndTime
and BINARY_CHECKSUM(t.TeacherShortName)=BINARY_CHECKSUM(@TeacherShortName))
		BEGIN
			SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=23)
		END
	-- All things are ok to save Details
	ELSE 
		BEGIN
			SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=24)
		END
	SELECT @msg
END
GO
