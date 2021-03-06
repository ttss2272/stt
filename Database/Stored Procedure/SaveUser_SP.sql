USE [NewTimeTableDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveUser_SP]    Script Date: 12/16/2015 10:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kalpesh Katyare
-- Create date: 06 Nov 2015
-- Description:	Save AND Update User
-- =============================================
ALTER PROCEDURE [dbo].[SaveUser_SP] 
	( 
	@UserID int,
	@UserName nvarchar(50),
	@ContactNo nvarchar(50),
	@Address nvarchar(50),
	@MailId nvarchar(50),
	@LoginName nvarchar(50),
	@Password nvarchar(50),
	@UserTypeID int,
	@UpdatedDate nvarchar(50),
	@IsActive int,
	@IsDeleted int
	)
AS
DECLARE @msg nvarchar(MAX)
BEGIN
	IF(@UserID=0)--Check for Edit Or Update 0 for new entry and onther no update
		BEGIN
			IF NOT EXISTS (SELECT UserID FROM [User] Where FullName=@UserName and IsActive =1)--Check Whether given name Already exist or not
				BEGIN
					IF NOT EXISTS (SELECT UserID FROM [User] Where UserName=@LoginName and IsActive =1) --Check Whether Short Neame already Exists Or Not
						BEGIN-- Insert into Data into User Table
							INSERT INTO [User] (FullName,ContactNo,[Address],EmailID,UserName,[Password],CreatedDate,UpdatedDate,UserTypeID,IsActive,IsDeleted)
							VALUES (@UserName,@ContactNo,@Address,@MailId,@LoginName,@Password, @UpdatedDate,@UpdatedDate,@UserTypeID,@IsActive,@IsDeleted)
							IF (@@ROWCOUNT=1)--Check Row effected Or not
								BEGIN
									EXEC SaveLog_SP 'User Inserted Sucessfully.',@UpdatedDate,'User',@UserID --Enter in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected or Not
										BEGIN
											SET @msg=(SELECT [Message]	FROM [Messages] WHERE MessageID=1)--Set Message to return
										END
								END
							ELSE
								BEGIN
									EXEC SaveLog_SP 'Error To Save Details.',@UpdatedDate,'User',@UserID --Enter in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected Or Not
										BEGIN
											SET @msg=(SELECT [Message]	FROM [Messages] WHERE MessageID=16)--Set Message To Return
										END
								END
						END
					ELSE--error for Duplicate Short Name
						BEGIN
						EXEC SaveLog_SP 'User Login Name Duplication',@UpdatedDate,'User',@UserID--Enter in Log Table
							IF (@@ROWCOUNT=1)
								BEGIN
									SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=26)--Set Message To Return
								END
						END
				END
			ELSE--Error for Duplicate User Name
				BEGIN
					EXEC SaveLog_SP 'User Full Name Duplication',@UpdatedDate,'User',@UserID--Enter in Log Table
					IF (@@ROWCOUNT=1)
						BEGIN
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=3)--Set Message To Return
						END
				END
		END
	ELSE
		BEGIN
			IF NOT EXISTS (SELECT UserID FROM [User] Where FullName=@UserName AND UserID <> @UserID)--Check Whether User Name Exist other Than UserID
				BEGIN
					IF NOT EXISTS (SELECT UserID FROM [User] Where UserName=@LoginName AND UserID <> @UserID )--Check User Short Name Available for other Than that User ID
						BEGIN--UPDATE SP
							UPDATE [User] SET FullName=@UserName,ContactNo=@ContactNo,[Address]=@Address,EmailID=@MailId,UserName=@LoginName,[Password]=@Password,UserTypeID=@UserTypeID,UpdatedDate=@UpdatedDate,IsActive=@IsActive,IsDeleted=@IsDeleted
							WHERE UserID=@UserID
							IF(@@ROWCOUNT=1)--Check Row Effected or Not
								BEGIN
									EXEC SaveLog_SP 'User Updated Sucessfully',@UpdatedDate,'User',@UserID--Entry in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected Or Not
										BEGIN
											SET @msg =(SELECT [Message] FROM [Messages] Where MessageID=5)--Set message
										END
								END
						END
					ELSE--Short Name Duplicateion
						BEGIN
							EXEC SaveLog_SP 'UserName Duplication',@UpdatedDate,'User',@UserID--Entry in Log Table
							IF (@@ROWCOUNT=1)
								BEGIN
									SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=26)--Set Message
								END		
						END
				END
			ELSE
				BEGIN
					EXEC SaveLog_SP 'FullName Duplication',@UpdatedDate,'User',@UserID--Entery In Log Table
					IF (@@ROWCOUNT=1)--Check row Effected
						BEGIN
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=3)--set Message
						END
				END
		END
	SELECT @msg
END
