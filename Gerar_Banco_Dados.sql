USE [TesteWipro]
GO
/****** Object:  Table [dbo].[tb_Andamento]    Script Date: 17/01/2021 22:38:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Andamento](
	[idAndamento] [int] NOT NULL,
	[IdProcesso] [int] NOT NULL,
	[dtAndamento] [date] NULL,
	[dsMovimento] [varchar](2000) NULL,
 CONSTRAINT [PK_tb_Andamento] PRIMARY KEY CLUSTERED 
(
	[idAndamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Processo]    Script Date: 17/01/2021 22:38:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Processo](
	[IdProcesso] [int] NOT NULL,
	[nroProcesso] [bigint] NOT NULL,
	[Autor] [varchar](90) NULL,
	[DtEntrada] [date] NULL,
	[DtEncerramento] [date] NULL,
	[IdStatus] [int] NULL,
 CONSTRAINT [PK_tb_Processo] PRIMARY KEY CLUSTERED 
(
	[IdProcesso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Status]    Script Date: 17/01/2021 22:38:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Status](
	[IdStatus] [int] NOT NULL,
	[dsStatus] [varchar](50) NULL,
 CONSTRAINT [PK_tb_Status] PRIMARY KEY CLUSTERED 
(
	[IdStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tb_Processo] ([IdProcesso], [nroProcesso], [Autor], [DtEntrada], [DtEncerramento], [IdStatus]) VALUES (1, 2, N'teste1', CAST(N'1900-01-01' AS Date), CAST(N'1900-01-01' AS Date), 1)
INSERT [dbo].[tb_Processo] ([IdProcesso], [nroProcesso], [Autor], [DtEntrada], [DtEncerramento], [IdStatus]) VALUES (2, 1, N'teste2', CAST(N'1900-01-01' AS Date), CAST(N'1900-01-01' AS Date), 2)
INSERT [dbo].[tb_Processo] ([IdProcesso], [nroProcesso], [Autor], [DtEntrada], [DtEncerramento], [IdStatus]) VALUES (3, 2, N'teste2', CAST(N'1900-01-01' AS Date), CAST(N'1900-01-01' AS Date), 3)
INSERT [dbo].[tb_Processo] ([IdProcesso], [nroProcesso], [Autor], [DtEntrada], [DtEncerramento], [IdStatus]) VALUES (4, 1, N'teste2', CAST(N'1900-01-01' AS Date), CAST(N'1900-01-01' AS Date), 1)
INSERT [dbo].[tb_Processo] ([IdProcesso], [nroProcesso], [Autor], [DtEntrada], [DtEncerramento], [IdStatus]) VALUES (5, 3, N'teste2', CAST(N'1900-01-01' AS Date), CAST(N'1900-01-01' AS Date), 2)
GO
INSERT [dbo].[tb_Status] ([IdStatus], [dsStatus]) VALUES (1, N'Juridico')
INSERT [dbo].[tb_Status] ([IdStatus], [dsStatus]) VALUES (2, N'Tributario')
INSERT [dbo].[tb_Status] ([IdStatus], [dsStatus]) VALUES (3, N'Trabalhista')
GO
ALTER TABLE [dbo].[tb_Andamento]  WITH CHECK ADD  CONSTRAINT [FK_tb_Andamento_tb_Processo] FOREIGN KEY([IdProcesso])
REFERENCES [dbo].[tb_Processo] ([IdProcesso])
GO
ALTER TABLE [dbo].[tb_Andamento] CHECK CONSTRAINT [FK_tb_Andamento_tb_Processo]
GO
ALTER TABLE [dbo].[tb_Processo]  WITH CHECK ADD  CONSTRAINT [FK_tb_Processo_tb_Status] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[tb_Status] ([IdStatus])
GO
ALTER TABLE [dbo].[tb_Processo] CHECK CONSTRAINT [FK_tb_Processo_tb_Status]
GO
