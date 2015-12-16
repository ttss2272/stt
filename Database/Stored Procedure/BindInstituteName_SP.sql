
/****** Object:  StoredProcedure [dbo].[BindInstituteName_SP]    Script Date: 12/16/2015 10:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sameer Shinde
-- Create date: 6 Nov 2015
-- Description:	search Branch
-- Updated BY : Pritesh D. sortee
-- Updated Date: 16 Dec 2015
-- Pupose : select Institute Name remove Branch ID
-- =============================================
ALTER PROCEDURE [dbo].[BindInstituteName_SP] 
AS
BEGIN
Select 'Select' As InstituteName
Union 
	SELECT Distinct(InstituteName) FROM Branch where IsActive=1
END
