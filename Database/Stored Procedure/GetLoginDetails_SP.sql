
/****** Object:  StoredProcedure [dbo].[GetLoginDetails_SP]    Script Date: 12/07/2015 10:35:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Updated By: PriTesh D. Sortee
-- Create date: <Create Date,,>
-- Updated Date : 07 Dec 2015
-- Description:	<Description,,>
-- Description: Check Login Details
-- =============================================
ALTER PROCEDURE [dbo].[GetLoginDetails_SP]
@UserName NVARCHAR(MAX),
@Pass NVARCHAR(MAX),
@CurrentDate NVARCHAR(MAX)
AS
DECLARE @msg NVARCHAR(MAX)
DECLARE @ExpDate NVARCHAR(MAX)
BEGIN

IF (EXISTS (SELECT LoginuserId FROM [Login] WHERE (BINARY_CHECKSUM(LoginUserName)=BINARY_CHECKSUM(@UserName)) AND (BINARY_CHECKSUM([Password])=BINARY_CHECKSUM(@Pass))))	
	BEGIN
		IF(EXISTS (SELECT LoginuserId FROM[Login] WHERE (BINARY_CHECKSUM(LoginUserName)=BINARY_CHECKSUM(@UserName)) AND (BINARY_CHECKSUM([Password])=BINARY_CHECKSUM(@Pass)) AND ExpiryDate>=CONVERT (date,@CurrentDate)))
			BEGIN
				SET @ExpDate= (SELECT CONVERT (date,ExpiryDate) FROM [Login] WHERE (BINARY_CHECKSUM(LoginUserName)=BINARY_CHECKSUM(@UserName)) AND (BINARY_CHECKSUM([Password])=BINARY_CHECKSUM(@Pass)) AND ExpiryDate>=CONVERT (date,@CurrentDate))
				SELECT 'Welcome' AS msg,DATEDIFF(dd,@CurrentDate,@ExpDate)
			END
		ELSE
			BEGIN
				SET @msg= 'Your Application Validity Is Expired'
				SELECT @msg
			END
		
	END
ELSE
	BEGIN
		SET @msg= 'Login Name Or Password Is Invalid'
		SELECT @msg
	END
    

	
END

