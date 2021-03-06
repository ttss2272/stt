/****** Object:  StoredProcedure [dbo].[GetBranchClassCount_SP]    Script Date: 12/16/2015 11:25:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Pranjali S. Vidhate
-- Create date: 27/11/2015
-- Description:	To Get No of Classes for Branch
-- =============================================
ALTER PROCEDURE [dbo].[GetBranchClassCount_SP]

AS
BEGIN
   select br.BranchName, count(cs.ClassID) as 'NoOfClass', br.BranchID from Class cs
   inner join Branch br
   on cs.BranchID = br.BranchID
   where cs.IsDeleted = 0  AND br.IsActive=1
   group by br.BranchName, br.BranchID 	
	
END
