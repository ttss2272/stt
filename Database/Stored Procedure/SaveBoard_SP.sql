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
-- Create date: 10 Dec 2015
-- Description:	Save Board
-- =============================================
ALTER PROCEDURE SaveBoard_SP 
(
@BoardID int,
@BoardName nvarchar(50),
@IsActive int,
@IsDeleted int,
@UpdatedByUserID int,
@UpdatedDate nvarchar(50)
)
AS
DECLARE @msg NVARCHAR(MAX)
DECLARE @MaxID int
BEGIN
	IF (@BoardID=0)-- New Entry
		BEGIN
			IF NOT EXISTS(SELECT BoardID FROM Board WHERE BoardName=@BoardName)--CHeck For Duplicate Entry
				BEGIN
					INSERT INTO Board (BoardName,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,IsActive,IsDeleted)
					VALUES (@BoardName,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@UpdatedDate,@IsActive,@IsDeleted)
					IF (@@ROWCOUNT=1)
						BEGIN
							SET @MaxID= (SELECT MAX(BoardID) FROM Board)
							EXEC SaveLog_SP 'Board Save SucessFully',@UpdatedDate,'Board',@MaxID
							SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=1)
						END
					ELSE
						BEGIN
							SET @MaxID= (SELECT MAX(BoardID) FROM Board)
							EXEC SaveLog_SP 'Error To Save Board',@UpdatedDate,'Board',@MaxID
							SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=2)
						END
				END
			ELSE -- Name ALready EXisists
				BEGIN
					SET @msg= (SELECT [Message] FROM [Messages] WHERE MessageID=25)
				END
		END
	ELSE
		BEGIN
			IF NOT EXISTS(SELECT BoardID FROM Board WHERE BoardName=@BoardName AND BoardID<>@BoardID)--Chekc Duplication Name
				 BEGIN
					UPDATE Board SET BoardName=@BoardName,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate,IsActive=@IsActive,IsDeleted=@IsDeleted
					WHERE BoardID=@BoardID
					IF (@@ROWCOUNT=1)
						BEGIN
							
							EXEC SaveLog_SP 'Board Updated Sucessfully',@UpdatedDate,'Board',@BoardID
							SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=5)
						END
					ELSE
						BEGIN
							SET @MaxID= (SELECT MAX(BoardID) FROM Board)
							EXEC SaveLog_SP 'Error To Update Board',@UpdatedDate,'Board',@MaxID
							SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=2)
						END
				 END
			ELSE
				BEGIN
					SET @msg= (SELECT [Message] FROM [Messages] WHERE MessageID=25)
				END
		END
		SELECT @msg
END
GO
