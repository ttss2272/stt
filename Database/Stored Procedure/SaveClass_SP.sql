USE [NewTimeTableDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveClass_SP]    Script Date: 11/06/2015 19:51:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 04-11-2015
-- Description:	Class form save and update code
-- =============================================
ALTER PROCEDURE [dbo].[SaveClass_SP]
(
@ClassID int,
@ClassName nvarchar(50),
@ClassShortName nvarchar(50),
@Board nvarchar(20),
@Color nvarchar(20),
@BranchID int,
@UpdatedByUserID int,
@UpdatedDate nvarchar(50),
@IsActive int,
@IsDeleted int

 )	
	AS
	DECLARE @msg nvarchar(MAX)
	BEGIN
	if(@ClassID=0)--Check for Edit Or Update 0 for new entry and onther no update
		BEGIN
			IF NOT EXISTS (select ClassID FROM [Class] Where ClassName=@ClassName)--Check Whether given name Already exist or not
				BEGIN
					IF NOT EXISTS (select ClassID FROM [Class] Where ClassShortName=@ClassShortName) --Check Whether Short Neame already Exists Or Not
						BEGIN-- Insert into Data into Class Table
							INSERT INTO [Class](ClassName,ClassShortName,Board,Color,BranchID,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,IsActive,IsDeleted)
							Values (@ClassName,@ClassShortName,@Board,@Color,@BranchID,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@UpdatedDate,@IsActive,@IsDeleted)
							IF (@@ROWCOUNT=1)--Check Row effected Or not
								BEGIN
									exec SaveLog_SP 'Class Inserted Successfully',@UpdatedDate,'Class',@ClassID
									IF (@@ROWCOUNT=1)--Check Row Effected or Not
										BEGIN
											set @msg=(select[Message]from [Messages]WHERE MessageID=1)--Set Message To Return	
										END
								END
							ELSE
								BEGIN
									exec SaveLog_SP 'Error To Save Details.',@UpdatedDate,'Class',@ClassID --Enter in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected Or Not
										BEGIN
											SET @msg=(SELECT [Message]	FROM [Messages] WHERE MessageID=2)--Set Message To Return
										END
								END
						END
					ELSE--error for Duplicate Short Name
						BEGIN
						EXEC SaveLog_SP 'Class Short Name Duplication',@UpdatedDate,'Class',@ClassID--Enter in Log Table
							IF (@@ROWCOUNT=1)
								BEGIN
									SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=4)--Set Message To Return
								END
						END
				END
			ELSE--Error for Duplicate Class Name
				BEGIN
					EXEC SaveLog_SP 'Class Name Duplication',@UpdatedDate,'Class',@ClassID--Enter in Log Table
					IF (@@ROWCOUNT=1)
						BEGIN
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=9)--Set Message To Return
						END
				END
		END
	ELSE
		BEGIN
			IF NOT EXISTS (SELECT @ClassID FROM [Class] Where ClassName=@ClassName AND ClassID <> @ClassID)--Check Whether Subject Name Exist other Than SubjectID
				BEGIN
					IF NOT EXISTS (SELECT ClassID FROM [Class] Where ClassShortName=@ClassShortName AND ClassID <> @ClassID )--Check Subject Short Name Available for other Than that subject ID
						BEGIN--UPDATE SP
							UPDATE [Class] SET ClassName=@ClassName,ClassShortName=@ClassShortName,Board=@Board,Color=@Color,BranchID=@BranchID,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate
							WHERE ClassID=@ClassID
							IF(@@ROWCOUNT=1)--Check Row Effected or Not
								BEGIN
									EXEC SaveLog_SP 'Class Updated Sucessfully',@UpdatedDate,'Class',@ClassID--Entry in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected Or Not
										BEGIN
											SET @msg =(SELECT [Message] FROM [Messages] Where MessageID=5)--Set message
										END
								END
					
						END
					ELSE--Short Name Duplicateion
						BEGIN
							EXEC SaveLog_SP 'Class Short Name Duplication',@UpdatedDate,'Subject',@ClassID--Entry in Log Table
							IF (@@ROWCOUNT=1)
								BEGIN
									SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=4)--Set Message
								END		
						END
				END
			ELSE
				BEGIN
					EXEC SaveLog_SP 'Class Name Duplication',@UpdatedDate,'Class',@ClassID--Entery In Log Table
					IF (@@ROWCOUNT=1)--Check row Effected
						BEGIN
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=11)--set Message
						END
				END
			
			
		END
		
	SELECT @msg
	
END
