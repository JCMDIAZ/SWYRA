USE [SWYRA]
GO

/****** Object:  View [dbo].[vw_codigosBarras]    Script Date: 25/01/2018 02:22:02 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vw_codigosBarras]
AS
select * from (
select CVE_ART, CANT_PIEZAS_1 CANT_PIEZAS, CODIGO_BARRA_1 CODIGO_BARRA
from INVENTARIOPRESENT union
select CVE_ART, CANT_PIEZAS_2, CODIGO_BARRA_2 
from INVENTARIOPRESENT union
select CVE_ART, CANT_PIEZAS_3, CODIGO_BARRA_3 
from INVENTARIOPRESENT union
select CVE_ART, CANT_PIEZAS_4, CODIGO_BARRA_4 
from INVENTARIOPRESENT union
select CVE_ART, CANT_PIEZAS_5, CODIGO_BARRA_5 
from INVENTARIOPRESENT union
select CVE_ART, CANT_PIEZAS_6, CODIGO_BARRA_6 
from INVENTARIOPRESENT union
select CVE_ART, CANT_PIEZAS_7, CODIGO_BARRA_7 
from INVENTARIOPRESENT union
select CVE_ART, CANT_PIEZAS_8, CODIGO_BARRA_8
from INVENTARIOPRESENT union
select CVE_ART, CANT_PIEZAS_9, CODIGO_BARRA_9 
from INVENTARIOPRESENT) as a
where CANT_PIEZAS > 0
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_codigosBarras'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_codigosBarras'
GO


