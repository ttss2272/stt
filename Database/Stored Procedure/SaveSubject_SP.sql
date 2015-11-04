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
-- Create date: 11 Nov 2015
-- Description:	Save AND Update Subject
-- =============================================
ALTER PROCEDURE SaveSubject_SP 
	(
	@SubjectID int,
	@SubjectName nvarchar(50),
	@SubjectShortName nvarchar(50),
	@UpdatedByUserID int,
	@UpdatedDate nvarchar(50),
	@IsActive nvarchar(50)
	)
AS
DECLARE @msg nvarchar(MAX)
BEGIN
	IF(@SubjectID=0)--Check for Edit Or Update 0 for new entry and onther no update
		BEGIN
			IF NOT EXISTS (SELECT SubjectID FROM [Subject] Where SubjectName=@SubjectName)--Check Whether given name Already exist or not
				BEGIN
					IF NOT EXISTS (SELECT SubjectID FROM [Subject] Where SubjectShortName=@SubjectShortName) --Check Whether Short Neame already Exists Or Not
						BEGIN-- Insert into Data into Subject Table
							INSERT INTO [Subject] (SubjectName,SubjectShortName,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,IsActive)
							VALUES (@SubjectName,@SubjectShortName,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@UpdatedDate,@IsActive)
							IF (@@ROWCOUNT=1)--Check Row effected Or not
								BEGIN
									EXEC SaveLog_SP 'Subject Inserted Sucessfully.',@UpdatedDate,'Subject',@SubjectID --Enter in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected or Not
										BEGIN
											SET @msg=(SELECT [Message]	FROM [Messages] WHERE MessageID=1)--Set Message to return
										END
								END
							ELSE
								BEGIN
									EXEC SaveLog_SP 'Error To Save Details.',@UpdatedDate,'Subject',@SubjectID --Enter in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected Or Not
										BEGIN
											SET @msg=(SELECT [Message]	FROM [Messages] WHERE MessageID=2)--Set Message To Return
										END
								END
						END
					ELSE--error for Duplicate Short Name
						BEGIN
						EXEC SaveLog_SP 'Subject Short Name Duplication',@UpdatedDate,'Subject',@SubjectID--Enter in Log Table
							IF (@@ROWCOUNT=1)
								BEGIN
									SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=4)--Set Message To Return
								END
						END
				END
			ELSE--Error for Duplicate Subject Name
				BEGIN
					EXEC SaveLog_SP 'Subject Name Duplication',@UpdatedDate,'Subject',@SubjectID--Enter in Log Table
					IF (@@ROWCOUNT=1)
						BEGIN
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=3)--Set Message To Return
						END
				END
		END
	ELSE
		BEGIN
			IF NOT EXISTS (SELECT SubjectID FROM [Subject] Where SubjectName=@SubjectName AND SubjectID <> @SubjectID)--Check Whether Subject Name Exist other Than SubjectID
				BEGIN
					IF NOT EXISTS (SELECT SubjectID FROM [Subject] Where SubjectShortName=@SubjectShortName AND SubjectID <> @SubjectID )--Check Subject Short Name Available for other Than that subject ID
						BEGIN--UPDATE SP
							UPDATE [Subject] SET SubjectName=@SubjectName,SubjectShortName=@SubjectShortName,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate
							WHERE SubjectID=@SubjectID
							IF(@@ROWCOUNT=1)--Check Row Effected or Not
								BEGIN
									EXEC SaveLog_SP 'Subject Updated Sucessfully',@UpdatedDate,'Subject',@SubjectID--Entry in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected Or Not
										BEGIN
											SET @msg =(SELECT [Message] FROM [Messages] Where MessageID=5)--Set message
										END
								END
					
						END
					ELSE--Short Name Duplicateion
						BEGIN
							EXEC SaveLog_SP 'Short Name Duplication',@UpdatedDate,'Subject',@SubjectID--Entry in Log Table
							IF (@@ROWCOUNT=1)
								BEGIN
									SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=4)--Set Message
								END		
						END
				END
			ELSE
				BEGIN
					EXEC SaveLog_SP 'Subject Name Duplication',@UpdatedDate,'Subject',@SubjectID--Entery In Log Table
					IF (@@ROWCOUNT=1)--Check row Effected
						BEGIN
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=3)--set Message
						END
				END
			
			
		END
		
	SELECT @msg
	
END
GO
