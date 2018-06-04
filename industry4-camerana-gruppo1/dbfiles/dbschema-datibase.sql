USE [Industry4-gruppo1]
GO
/****** Object:  Table [dbo].[Lavorazioni]    Script Date: 27/03/2014 20:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lavorazioni](
	[idlavorazione] [int] IDENTITY(1,1) NOT NULL,
	[fkordine] [int] NOT NULL,
	[fk_opzione] [int] NULL,
	[note] [varchar](255) NULL,
	[inizio] [datetime] NULL,
	[fine] [datetime] NULL,
	[stato] [int] NULL,
	[fk_postazione] [int] NULL,
 CONSTRAINT [PK_LAVORAZIONI] PRIMARY KEY CLUSTERED 
(
	[idlavorazione] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OpzioniLavorazione]    Script Date: 27/03/2014 20:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpzioniLavorazione](
	[idopz] [int] IDENTITY(1,1) NOT NULL,
	[opzione] [varchar](255) NULL,
	[fk_idtipolavorazione] [int] NULL,
 CONSTRAINT [PK_OPZIONILAVORAZIONE] PRIMARY KEY CLUSTERED 
(
	[idopz] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ordini]    Script Date: 27/03/2014 20:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ordini](
	[idordine] [int] IDENTITY(1,1) NOT NULL,
	[data] [datetime] NULL,
	[note] [varchar](255) NULL,
	[fk_utente] [int] NULL,
 CONSTRAINT [PK_ORDINI] PRIMARY KEY CLUSTERED 
(
	[idordine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Postazioni]    Script Date: 27/03/2014 20:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Postazioni](
	[idpostazione] [int] IDENTITY(1,1) NOT NULL,
	[password] [varchar](255) NULL,
	[tag] [varchar](55) NULL,
	[fk_tipo] [int] NULL,
 CONSTRAINT [PK_POSTAZIONI] PRIMARY KEY CLUSTERED 
(
	[idpostazione] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoLavorazione]    Script Date: 27/03/2014 20:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoLavorazione](
	[idtipolav] [int] IDENTITY(1,1) NOT NULL,
	[descrizione] [varchar](255) NULL,
 CONSTRAINT [PK_TIPOLAVORAZIONE] PRIMARY KEY CLUSTERED 
(
	[idtipolav] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPostazione]    Script Date: 27/03/2014 20:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPostazione](
	[idtipopost] [int] IDENTITY(1,1) NOT NULL,
	[descrizione] [varchar](255) NULL,
 CONSTRAINT [PK_TIPOPOSTAZIONE] PRIMARY KEY CLUSTERED 
(
	[idtipopost] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoRuolo]    Script Date: 27/03/2014 20:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoRuolo](
	[idruolo] [int] IDENTITY(1,1) NOT NULL,
	[descrizione] [varchar](120) NULL,
	[priorità] [int] NULL,
 CONSTRAINT [PK_TIPORUOLO] PRIMARY KEY CLUSTERED 
(
	[idruolo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utenti]    Script Date: 27/03/2014 20:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti](
	[idutente] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](120) NULL,
	[password] [varchar](255) NULL,
	[fk_ruolo] [int] NULL,
 CONSTRAINT [PK_UTENTI] PRIMARY KEY CLUSTERED 
(
	[idutente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utenti_postazioni]    Script Date: 27/03/2014 20:52:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti_postazioni](
	[idUtentipostazioni] [int] IDENTITY(1,1) NOT NULL,
	[fk_utente] [int] NULL,
	[fk_postazione] [int] NULL,
 CONSTRAINT [PK_UTENTI_POSTAZIONI] PRIMARY KEY CLUSTERED 
(
	[idUtentipostazioni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[OpzioniLavorazione] ON 

INSERT [dbo].[OpzioniLavorazione] ([idopz], [opzione], [fk_idtipolavorazione]) VALUES (1, N'piccolo', 1)
INSERT [dbo].[OpzioniLavorazione] ([idopz], [opzione], [fk_idtipolavorazione]) VALUES (2, N'grande', 1)
INSERT [dbo].[OpzioniLavorazione] ([idopz], [opzione], [fk_idtipolavorazione]) VALUES (3, N'rosso', 3)
INSERT [dbo].[OpzioniLavorazione] ([idopz], [opzione], [fk_idtipolavorazione]) VALUES (4, N'oro', 3)
INSERT [dbo].[OpzioniLavorazione] ([idopz], [opzione], [fk_idtipolavorazione]) VALUES (5, N'plastica', 4)
INSERT [dbo].[OpzioniLavorazione] ([idopz], [opzione], [fk_idtipolavorazione]) VALUES (6, N'acciaio', 4)
SET IDENTITY_INSERT [dbo].[OpzioniLavorazione] OFF

SET IDENTITY_INSERT [dbo].[Postazioni] ON 

INSERT [dbo].[Postazioni] ([idpostazione], [password], [tag], [fk_tipo]) VALUES (1, NULL, N'FRT1', 1)
INSERT [dbo].[Postazioni] ([idpostazione], [password], [tag], [fk_tipo]) VALUES (3, NULL, N'ETC1', 2)
INSERT [dbo].[Postazioni] ([idpostazione], [password], [tag], [fk_tipo]) VALUES (4, NULL, N'CLR1', 3)
INSERT [dbo].[Postazioni] ([idpostazione], [password], [tag], [fk_tipo]) VALUES (5, NULL, N'MAT1', 4)
SET IDENTITY_INSERT [dbo].[Postazioni] OFF
SET IDENTITY_INSERT [dbo].[TipoLavorazione] ON 

INSERT [dbo].[TipoLavorazione] ([idtipolav], [descrizione]) VALUES (1, N'foratura')
INSERT [dbo].[TipoLavorazione] ([idtipolav], [descrizione]) VALUES (2, N'etichettatura')
INSERT [dbo].[TipoLavorazione] ([idtipolav], [descrizione]) VALUES (3, N'colore')
INSERT [dbo].[TipoLavorazione] ([idtipolav], [descrizione]) VALUES (4, N'materiale')
SET IDENTITY_INSERT [dbo].[TipoLavorazione] OFF
SET IDENTITY_INSERT [dbo].[TipoPostazione] ON 

INSERT [dbo].[TipoPostazione] ([idtipopost], [descrizione]) VALUES (1, N'foratura')
INSERT [dbo].[TipoPostazione] ([idtipopost], [descrizione]) VALUES (2, N'etichettatura')
INSERT [dbo].[TipoPostazione] ([idtipopost], [descrizione]) VALUES (3, N'colore')
INSERT [dbo].[TipoPostazione] ([idtipopost], [descrizione]) VALUES (4, N'materiale')
SET IDENTITY_INSERT [dbo].[TipoPostazione] OFF
SET IDENTITY_INSERT [dbo].[TipoRuolo] ON 

INSERT [dbo].[TipoRuolo] ([idruolo], [descrizione], [priorità]) VALUES (1, N'macchinista', NULL)
INSERT [dbo].[TipoRuolo] ([idruolo], [descrizione], [priorità]) VALUES (2, N'commerciale', NULL)
INSERT [dbo].[TipoRuolo] ([idruolo], [descrizione], [priorità]) VALUES (3, N'amministratore', NULL)
SET IDENTITY_INSERT [dbo].[TipoRuolo] OFF
SET IDENTITY_INSERT [dbo].[Utenti] ON 

INSERT [dbo].[Utenti] ([idutente], [username], [password], [fk_ruolo]) VALUES (1, N'Admin', N'pw', 3)
INSERT [dbo].[Utenti] ([idutente], [username], [password], [fk_ruolo]) VALUES (2, N'Foratore', N'pw', 1)
INSERT [dbo].[Utenti] ([idutente], [username], [password], [fk_ruolo]) VALUES (3, N'Etichettatore', N'pw', 1)
INSERT [dbo].[Utenti] ([idutente], [username], [password], [fk_ruolo]) VALUES (4, N'Colore', N'pw', 1)
INSERT [dbo].[Utenti] ([idutente], [username], [password], [fk_ruolo]) VALUES (6, N'Materiale', N'pw', 1)
INSERT [dbo].[Utenti] ([idutente], [username], [password], [fk_ruolo]) VALUES (7, N'Commerciale', N'pw', 2)
SET IDENTITY_INSERT [dbo].[Utenti] OFF
SET IDENTITY_INSERT [dbo].[Utenti_postazioni] ON 

INSERT [dbo].[Utenti_postazioni] ([idUtentipostazioni], [fk_utente], [fk_postazione]) VALUES (1, 2, 1)
INSERT [dbo].[Utenti_postazioni] ([idUtentipostazioni], [fk_utente], [fk_postazione]) VALUES (2, 3, 3)
INSERT [dbo].[Utenti_postazioni] ([idUtentipostazioni], [fk_utente], [fk_postazione]) VALUES (3, 4, 4)
INSERT [dbo].[Utenti_postazioni] ([idUtentipostazioni], [fk_utente], [fk_postazione]) VALUES (4, 6, 5)
SET IDENTITY_INSERT [dbo].[Utenti_postazioni] OFF
ALTER TABLE [dbo].[Lavorazioni]  WITH CHECK ADD  CONSTRAINT [Lavorazioni_fk0] FOREIGN KEY([fkordine])
REFERENCES [dbo].[Ordini] ([idordine])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lavorazioni] CHECK CONSTRAINT [Lavorazioni_fk0]
GO
ALTER TABLE [dbo].[Lavorazioni]  WITH CHECK ADD  CONSTRAINT [Lavorazioni_fk1] FOREIGN KEY([fk_opzione])
REFERENCES [dbo].[OpzioniLavorazione] ([idopz])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Lavorazioni] CHECK CONSTRAINT [Lavorazioni_fk1]
GO
ALTER TABLE [dbo].[Lavorazioni]  WITH CHECK ADD  CONSTRAINT [Lavorazioni_fk2] FOREIGN KEY([fk_postazione])
REFERENCES [dbo].[Postazioni] ([idpostazione])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Lavorazioni] CHECK CONSTRAINT [Lavorazioni_fk2]
GO
ALTER TABLE [dbo].[OpzioniLavorazione]  WITH CHECK ADD  CONSTRAINT [OpzioniLavorazione_fk0] FOREIGN KEY([fk_idtipolavorazione])
REFERENCES [dbo].[TipoLavorazione] ([idtipolav])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[OpzioniLavorazione] CHECK CONSTRAINT [OpzioniLavorazione_fk0]
GO
ALTER TABLE [dbo].[Ordini]  WITH CHECK ADD  CONSTRAINT [Ordini_fk0] FOREIGN KEY([fk_utente])
REFERENCES [dbo].[Utenti] ([idutente])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Ordini] CHECK CONSTRAINT [Ordini_fk0]
GO
ALTER TABLE [dbo].[Postazioni]  WITH CHECK ADD  CONSTRAINT [Postazioni_fk0] FOREIGN KEY([fk_tipo])
REFERENCES [dbo].[TipoPostazione] ([idtipopost])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Postazioni] CHECK CONSTRAINT [Postazioni_fk0]
GO
ALTER TABLE [dbo].[Utenti]  WITH CHECK ADD  CONSTRAINT [Utenti_fk0] FOREIGN KEY([fk_ruolo])
REFERENCES [dbo].[TipoRuolo] ([idruolo])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Utenti] CHECK CONSTRAINT [Utenti_fk0]
GO
ALTER TABLE [dbo].[Utenti_postazioni]  WITH CHECK ADD  CONSTRAINT [Utenti_postazioni_fk0] FOREIGN KEY([fk_utente])
REFERENCES [dbo].[Utenti] ([idutente])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Utenti_postazioni] CHECK CONSTRAINT [Utenti_postazioni_fk0]
GO
ALTER TABLE [dbo].[Utenti_postazioni]  WITH CHECK ADD  CONSTRAINT [Utenti_postazioni_fk1] FOREIGN KEY([fk_postazione])
REFERENCES [dbo].[Postazioni] ([idpostazione])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Utenti_postazioni] CHECK CONSTRAINT [Utenti_postazioni_fk1]
GO
