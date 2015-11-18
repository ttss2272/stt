
/****** Object:  StoredProcedure [dbo].[GetNoOfDaysTeacherAvailable_SP]    Script Date: 11/18/2015 14:40:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 07 Nov 2015
-- Description:	Get NO of Days Teacher Available
-- =============================================
ALTER PROCEDURE [dbo].[GetNoOfDaysTeacherAvailable_SP] 
	
	
	
AS
BEGIN
	Select Tea.TeacherID,tea.TeacherName, COUNT (TeacherAvailableID) AS 'NoOfDaysAvailaible' From TeacherAvailable TeaAvail
	INNER JOIN Teacher tea
	ON Tea.TeacherID=TeaAvail.TeacherID
	Where TeaAvail.TeacherID=TeaAvail.TeacherID AND TeaAvail.IsActive ='True' AND TeaAvail.IsDeleted='False'
	GROUP BY Tea.TeacherID,tea.TeacherName
END
