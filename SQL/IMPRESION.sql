USE [SWYRA]
GO

/****** Object:  Table [dbo].[IMPRESION]    Script Date: 29/05/2018 01:25:38 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[IMPRESION](
	[ID] [int] NOT NULL,
	[FECHA] [date] NULL,
	[CVE_DOC] [varchar](20) NULL,
	[CVE_IMP] [int] NULL,
	[IMPRESION] [varchar](250) NULL,
	[REALIZADO] [bit] NULL
) ON [PRIMARY]
GO


