USE [NewTimeTableDB]
GO
/****** Object:  StoredProcedure [dbo].[BindClass_SP]    Script Date: 11/07/2015 10:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 05-11-2015
-- Description:	Get Details To bind Drop Down
-- =============================================
ALTER PROCEDURE [dbo].[BindClass_SP]
(
	@ClassID int,
	@ClassName nvarchar(50)
)
AS
BEGIN
Select ClassName,ClassShortName,Board,Color,c.BranchID,b.BranchName from [Class] c
inner join Branch b
on b.BranchID=c.BranchID
where c.ClassID like case when @ClassID<>0 then @ClassID else CONVERT (NVARCHAR(50),ClassID)END
AND c.ClassName LIKE CASE WHEN @ClassName<>'' THEN '%'+@ClassName+'%' ELSE CONVERT(NVARCHAR(50),c.ClassName)END
AND c.IsDeleted<>'True' AND c.IsActive=1
order by ClassName
END
