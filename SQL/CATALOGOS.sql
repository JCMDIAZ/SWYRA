USE [SWYRA]
GO

/****** Object:  Table [dbo].[CATALOGOS]    Script Date: 20/04/2018 05:32:24 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CATALOGOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Catalogo] [varchar](50) NOT NULL,
	[Valor] [varchar](50) NOT NULL,
	[ValorTexto] [varchar](50) NOT NULL
) ON [PRIMARY]
GO


