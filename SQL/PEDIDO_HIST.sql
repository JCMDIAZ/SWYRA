USE [SWYRA]
GO

/****** Object:  Table [dbo].[PEDIDO_HIST]    Script Date: 22/02/2018 05:02:01 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PEDIDO_HIST](
	[CVE_DOC] [varchar](20) NOT NULL,
	[ESTATUSPEDIDO] [varchar](20) NOT NULL,
	[FECHAMOV] [datetime] NOT NULL,
	[USUARIO] [nchar](4) NULL
) ON [PRIMARY]
GO


