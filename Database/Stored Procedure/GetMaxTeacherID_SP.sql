USE [NewTimeTableDB]
GO
/****** Object:  StoredProcedure [dbo].[GetMaxBatchID_SP]    Script Date: 12/12/2015 13:04:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Sameer Shinde
-- Create date: 12 Dec 2015
-- Description:	Get Max Teacher ID
-- =============================================
ALTER PROCEDURE [dbo].[GetMaxTeacherID_SP]
	
AS
BEGIN
   
	SELECT MAX(TeacherID) from Teacher
END
