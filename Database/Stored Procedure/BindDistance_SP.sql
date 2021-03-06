/****** Object:  StoredProcedure [dbo].[BindDistance_SP]    Script Date: 12/16/2015 10:23:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Pranjali S Vidhate
-- Create date: 25/11/2015
-- Description:	To Bind disatance In Branch 
-- =============================================
ALTER PROCEDURE [dbo].[BindDistance_SP] --15,21,18
(
  @BranchDistanceID int,
  @FromBranchID int,
  @ToBranchID int
)

AS
BEGIN
if Exists(SELECT BranchDistanceID FROM BranchDistance where From_BranchID=@FromBranchID AND To_BranchID=@ToBranchID AND IsDeleted=0)
BEGIN
	 select bd.BranchDistanceID ,br.BranchName as FromBranch,br2.BranchName as ToBranch,bd.DistanceTime,bd.From_BranchID,bd.To_BranchID,
	 case WHEN bd.IsActive ='True' AND bd.IsDeleted='False' Then 'Active' 
	 WHEN bd.IsActive='False' AND bd.IsDeleted='False' THEN 'InActive'
	  END AS 'Status',
	 bd.IsActive,bd.IsDeleted
	 
	  from BranchDistance bd
     inner join Branch br 
     on br.BranchID = bd.From_BranchID	
     inner join Branch br2
     on br2.BranchID =bd.To_BranchID	
	 where bd.BranchDistanceID LIKE CASE WHEN @BranchDistanceID <>0 THEN @BranchDistanceID ELSE CONVERT (NVARCHAR(50),bd.BranchDistanceID) END
     AND bd.From_BranchID LIKE CASE WHEN @FromBranchID <>0 THEN @FromBranchID ELSE CONVERT (NVARCHAR(50),bd.From_BranchID) END
     AND bd.To_BranchID LIKE CASE WHEN @ToBranchId <>0 THEN @ToBranchId ELSE CONVERT (NVARCHAR(50),bd.To_BranchID) END
     and bd.IsDeleted =0 AND br.IsActive=1 AND br2.IsActive=1
 END
 ELSE  IF EXISTS(SELECT BranchDistanceID FROM BranchDistance where From_BranchID= @ToBranchId AND To_BranchID= @FromBranchId AND IsDeleted=0)
	BEGIN
	select bd.BranchDistanceID ,br2.BranchName as FromBranch,br.BranchName as ToBranch,bd.DistanceTime,bd.From_BranchID,bd.To_BranchID,
	 case WHEN bd.IsActive ='True' AND bd.IsDeleted='False' Then 'Active' 
	 WHEN bd.IsActive='False' AND bd.IsDeleted='False' THEN 'InActive'
	  END AS 'Status',
	 bd.IsActive, bd.IsDeleted
	 
	  from BranchDistance bd
     inner join Branch br 
     on br.BranchID = bd.To_BranchID
     inner join Branch br2
     on br2.BranchID =	bd.From_BranchID	
	 where bd.BranchDistanceID LIKE CASE WHEN @BranchDistanceID <>0 THEN @BranchDistanceID ELSE CONVERT (NVARCHAR(50),bd.BranchDistanceID) END
	 AND bd.From_BranchID LIKE CASE WHEN @ToBranchID <>0 THEN @ToBranchID ELSE CONVERT (NVARCHAR(50),bd.From_BranchID) END
     AND bd.To_BranchID LIKE CASE WHEN @FromBranchID <>0 THEN @FromBranchID  ELSE CONVERT (NVARCHAR(50),bd.To_BranchID) END
     and bd.IsDeleted =0 AND br.IsActive=1 AND br2.IsActive=1	
	END
	
	
	ELSE
	BEGIN
	 select bd.BranchDistanceID ,br.BranchName as FromBranch,br2.BranchName as ToBranch,bd.DistanceTime,bd.From_BranchID,bd.To_BranchID,
	 case WHEN bd.IsActive ='True' AND bd.IsDeleted='False' Then 'Active' 
	 WHEN bd.IsActive='False' AND bd.IsDeleted='False' THEN 'InActive'
	  END AS 'Status',
	 bd.IsActive,bd.IsDeleted
	 
	  from BranchDistance bd
     inner join Branch br 
     on br.BranchID = bd.From_BranchID	
     inner join Branch br2
     on br2.BranchID =bd.To_BranchID	
	 where bd.BranchDistanceID LIKE CASE WHEN @BranchDistanceID <>0 THEN @BranchDistanceID ELSE CONVERT (NVARCHAR(50),bd.BranchDistanceID) END
     AND bd.From_BranchID LIKE CASE WHEN @FromBranchID <>0 THEN @FromBranchID ELSE CONVERT (NVARCHAR(50),bd.From_BranchID) END
     AND bd.To_BranchID LIKE CASE WHEN @ToBranchId <>0 THEN @ToBranchId ELSE CONVERT (NVARCHAR(50),bd.To_BranchID) END
     and bd.IsDeleted =0 AND br.IsActive=1 AND br2.IsActive=1
   END
   
END
