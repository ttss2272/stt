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
-- Author:		Pravin
-- Create date: 05-11-2015
-- Description:	Get Details To bind Drop Down
-- =============================================
CREATE PROCEDURE [dbo].[BindClass_SP]
(
	@ClassID int
)
AS
BEGIN
Select ClassID,ClassName,ClassShortName,Board,Color from [Class]
where ClassID like case when @ClassID<>0 then @ClassID else CONVERT (NVARCHAR(50),ClassID)END
	
END
