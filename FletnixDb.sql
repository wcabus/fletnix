USE [Fletnix]
GO
/****** Object:  Table [dbo].[CastMember]    Script Date: 28/10/2014 14:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CastMember](
	[MediaStreamId] [int] NOT NULL,
	[CelebrityId] [int] NOT NULL,
	[MediaRoleId] [int] NOT NULL,
 CONSTRAINT [PK_CastMember] PRIMARY KEY CLUSTERED 
(
	[MediaStreamId] ASC,
	[CelebrityId] ASC,
	[MediaRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Celebrity]    Script Date: 28/10/2014 14:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Celebrity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](128) NOT NULL,
	[LastName] [nvarchar](128) NOT NULL,
	[ImdbId] [varchar](16) NULL,
 CONSTRAINT [PK_Celebrity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 28/10/2014 14:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MediaRole]    Script Date: 28/10/2014 14:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MediaRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MediaStream]    Script Date: 28/10/2014 14:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaStream](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StreamId] [uniqueidentifier] NOT NULL,
	[TvShowId] [int] NULL,
	[Season] [int] NULL,
	[MediaStreamTypeId] [int] NOT NULL,
	[Length] [time](7) NOT NULL,
	[Title] [nvarchar](256) NOT NULL,
	[Synopsis] [nvarchar](max) NULL,
	[ImageUri] [nvarchar](1024) NULL,
 CONSTRAINT [PK_MediaStream] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MediaStreamGenre]    Script Date: 28/10/2014 14:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaStreamGenre](
	[MediaStreamId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
 CONSTRAINT [PK_MediaStreamGenre] PRIMARY KEY CLUSTERED 
(
	[MediaStreamId] ASC,
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShowSeason]    Script Date: 28/10/2014 14:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShowSeason](
	[TvShowId] [int] NOT NULL,
	[Season] [int] NOT NULL,
 CONSTRAINT [PK_ShowSeason] PRIMARY KEY CLUSTERED 
(
	[TvShowId] ASC,
	[Season] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subscription]    Script Date: 28/10/2014 14:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Subscription](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](40) NOT NULL,
	[SubscriptionModelId] [int] NOT NULL,
	[SubscriptionStartDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Subscription_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SubscriptionModel]    Script Date: 28/10/2014 14:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubscriptionModel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](32) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_SubscriptionModel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubscriptionOption]    Script Date: 28/10/2014 14:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubscriptionOption](
	[SubscriptionModelId] [int] NOT NULL,
	[SubscriptionOptionTemplateId] [int] NOT NULL,
	[Value] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_SubscriptionOption] PRIMARY KEY CLUSTERED 
(
	[SubscriptionModelId] ASC,
	[SubscriptionOptionTemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubscriptionOptionTemplate]    Script Date: 28/10/2014 14:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubscriptionOptionTemplate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OptionTypeId] [int] NOT NULL,
	[Name] [nvarchar](32) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_SubscriptionOptionTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TvShow]    Script Date: 28/10/2014 14:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TvShow](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](256) NOT NULL,
	[ImageUri] [nvarchar](1024) NULL,
 CONSTRAINT [PK_TvShow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TvShowGenre]    Script Date: 28/10/2014 14:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TvShowGenre](
	[TvShowId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
 CONSTRAINT [PK_TvShowGenre] PRIMARY KEY CLUSTERED 
(
	[TvShowId] ASC,
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 28/10/2014 14:37:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [varchar](40) NOT NULL,
	[Email] [nvarchar](512) NOT NULL,
	[FirstName] [nvarchar](128) NOT NULL,
	[LastName] [nvarchar](128) NOT NULL,
	[MemberSince] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (1, 1, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (1, 2, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (1, 3, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (1, 4, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (1, 5, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (1, 6, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (1, 7, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (2, 1, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (2, 2, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (2, 3, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (2, 4, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (2, 5, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (2, 6, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (2, 7, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (3, 1, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (3, 2, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (3, 3, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (3, 4, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (3, 5, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (3, 6, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (3, 7, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (4, 1, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (4, 2, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (4, 3, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (4, 4, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (4, 5, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (4, 6, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (4, 7, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (5, 1, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (5, 2, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (5, 3, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (5, 4, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (5, 5, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (5, 6, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (5, 7, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (6, 1, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (6, 2, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (6, 3, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (6, 4, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (6, 5, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (6, 6, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (6, 7, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (7, 15, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (7, 16, 1)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (7, 16, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (7, 17, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (8, 11, 1)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (8, 12, 1)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (8, 13, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (8, 14, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (8, 15, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (9, 8, 1)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (9, 9, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (9, 10, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (10, 1, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (10, 2, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (10, 3, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (10, 4, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (10, 5, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (10, 6, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (10, 7, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (11, 1, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (11, 2, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (11, 3, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (11, 4, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (11, 5, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (11, 6, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (11, 7, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (12, 1, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (12, 2, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (12, 3, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (12, 4, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (12, 5, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (12, 6, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (12, 7, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (13, 1, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (13, 2, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (13, 3, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (13, 4, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (13, 5, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (13, 6, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (13, 7, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (14, 1, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (14, 2, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (14, 3, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (14, 4, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (14, 5, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (14, 6, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (14, 7, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (15, 1, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (15, 2, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (15, 3, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (15, 4, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (15, 5, 4)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (15, 6, 3)
INSERT [dbo].[CastMember] ([MediaStreamId], [CelebrityId], [MediaRoleId]) VALUES (15, 7, 3)
SET IDENTITY_INSERT [dbo].[Celebrity] ON 

INSERT [dbo].[Celebrity] ([Id], [FirstName], [LastName], [ImdbId]) VALUES (1, N'Johnny', N'Galecki', N'nm0301959')
INSERT [dbo].[Celebrity] ([Id], [FirstName], [LastName], [ImdbId]) VALUES (2, N'Jim', N'Parsons', N'nm1433588')
INSERT [dbo].[Celebrity] ([Id], [FirstName], [LastName], [ImdbId]) VALUES (3, N'Kaley', N'Cuoco-Sweeting', N'nm0192505')
INSERT [dbo].[Celebrity] ([Id], [FirstName], [LastName], [ImdbId]) VALUES (4, N'Simon', N'Helberg', N'nm0374865')
INSERT [dbo].[Celebrity] ([Id], [FirstName], [LastName], [ImdbId]) VALUES (5, N'Kunal', N'Nayyar', N'nm2471798')
INSERT [dbo].[Celebrity] ([Id], [FirstName], [LastName], [ImdbId]) VALUES (6, N'Chuck', N'Lorre', N'nm0521143')
INSERT [dbo].[Celebrity] ([Id], [FirstName], [LastName], [ImdbId]) VALUES (7, N'Bill', N'Prady', N'nm0695080')
INSERT [dbo].[Celebrity] ([Id], [FirstName], [LastName], [ImdbId]) VALUES (8, N'Martin', N'Scorsese', N'nm0000217')
INSERT [dbo].[Celebrity] ([Id], [FirstName], [LastName], [ImdbId]) VALUES (9, N'Leonardo', N'DiCaprio', N'nm0000138')
INSERT [dbo].[Celebrity] ([Id], [FirstName], [LastName], [ImdbId]) VALUES (10, N'Jonah', N'Hill', N'nm1706767')
INSERT [dbo].[Celebrity] ([Id], [FirstName], [LastName], [ImdbId]) VALUES (11, N'Anthony', N'Russo', N'nm0751577')
INSERT [dbo].[Celebrity] ([Id], [FirstName], [LastName], [ImdbId]) VALUES (12, N'Joe', N'Russo', N'nm0751648')
INSERT [dbo].[Celebrity] ([Id], [FirstName], [LastName], [ImdbId]) VALUES (13, N'Chris', N'Evans', N'nm0262635')
INSERT [dbo].[Celebrity] ([Id], [FirstName], [LastName], [ImdbId]) VALUES (14, N'Samuel L.', N'Jackson', N'nm0000168')
INSERT [dbo].[Celebrity] ([Id], [FirstName], [LastName], [ImdbId]) VALUES (15, N'Scarlett', N'Johansson', N'nm0424060')
INSERT [dbo].[Celebrity] ([Id], [FirstName], [LastName], [ImdbId]) VALUES (16, N'Luc', N'Besson', N'nm0000108')
INSERT [dbo].[Celebrity] ([Id], [FirstName], [LastName], [ImdbId]) VALUES (17, N'Morgan', N'Freeman', N'nm0000151')
SET IDENTITY_INSERT [dbo].[Celebrity] OFF
SET IDENTITY_INSERT [dbo].[Genre] ON 

INSERT [dbo].[Genre] ([Id], [Name]) VALUES (1, N'Action')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (2, N'Adventure')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (3, N'Animation')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (4, N'Biography')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (5, N'Comedy')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (6, N'Crime')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (7, N'Documentary')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (8, N'Drama')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (9, N'Family')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (10, N'Fantasy')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (11, N'Film noir')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (12, N'Game show')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (13, N'History')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (14, N'Horror')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (15, N'Music')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (16, N'Musical')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (17, N'Mystery')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (18, N'News')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (19, N'Reality TV')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (20, N'Romance')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (21, N'Sci-fi')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (22, N'Sitcom')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (23, N'Sport')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (24, N'Talkshow')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (25, N'Thriller')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (26, N'War')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (27, N'Western')
SET IDENTITY_INSERT [dbo].[Genre] OFF
SET IDENTITY_INSERT [dbo].[MediaRole] ON 

INSERT [dbo].[MediaRole] ([Id], [Name]) VALUES (1, N'Director')
INSERT [dbo].[MediaRole] ([Id], [Name]) VALUES (2, N'Producer')
INSERT [dbo].[MediaRole] ([Id], [Name]) VALUES (3, N'Writer')
INSERT [dbo].[MediaRole] ([Id], [Name]) VALUES (4, N'Actor')
SET IDENTITY_INSERT [dbo].[MediaRole] OFF
SET IDENTITY_INSERT [dbo].[MediaStream] ON 

INSERT [dbo].[MediaStream] ([Id], [StreamId], [TvShowId], [Season], [MediaStreamTypeId], [Length], [Title], [Synopsis], [ImageUri]) VALUES (1, N'cd3248dc-b071-464e-b610-1deb5ed4a54c', 1, 1, 1, CAST(N'00:23:00' AS Time), N'Pilot', N'A pair of socially awkward theoretical physicists meet their new neighbor Penny, who is their polar opposite.', N'http://ia.media-imdb.com/images/M/MV5BNTU4NjE3NDY3OF5BMl5BanBnXkFtZTYwMDA2MTQ3._V1_SX214_AL_.jpg')
INSERT [dbo].[MediaStream] ([Id], [StreamId], [TvShowId], [Season], [MediaStreamTypeId], [Length], [Title], [Synopsis], [ImageUri]) VALUES (2, N'0f636a35-bb6e-4f49-9f28-fe7ede6256da', 1, 1, 1, CAST(N'00:21:00' AS Time), N'The Big Bran Hypothesis', N'Penny is furious with Leonard and Sheldon when they sneak into her apartment and clean it while she is sleeping.', N'http://ia.media-imdb.com/images/M/MV5BMjAzNDYwMTEwMV5BMl5BanBnXkFtZTgwNjUzMTY1MjE@._V1_SY317_CR104,0,214,317_AL_.jpg')
INSERT [dbo].[MediaStream] ([Id], [StreamId], [TvShowId], [Season], [MediaStreamTypeId], [Length], [Title], [Synopsis], [ImageUri]) VALUES (3, N'b749705b-ba53-4b0f-923e-a7df58d9ce11', 1, 1, 1, CAST(N'00:22:00' AS Time), N'The Fuzzy Boots Corollary', N'Leonard gets upset when he discovers that Penny is seeing a new guy, so he tries to trick her into going on a date with him.', N'http://ia.media-imdb.com/images/M/MV5BODQzMDk3MjkxOV5BMl5BanBnXkFtZTgwNTYzMTY1MjE@._V1_SY317_CR104,0,214,317_AL_.jpg')
INSERT [dbo].[MediaStream] ([Id], [StreamId], [TvShowId], [Season], [MediaStreamTypeId], [Length], [Title], [Synopsis], [ImageUri]) VALUES (4, N'01b7075d-2e31-45c9-939a-7f3483c273de', 1, 1, 1, CAST(N'00:21:00' AS Time), N'The Luminous Fish Effect', N'Sheldon''s mother is called to intervene when he delves into numerous obsessions after being fired for being disrespectful to his new boss.', N'http://ia.media-imdb.com/images/M/MV5BMTQyODI1MzM4MF5BMl5BanBnXkFtZTgwOTUzMTY1MjE@._V1_SY317_CR104,0,214,317_AL_.jpg')
INSERT [dbo].[MediaStream] ([Id], [StreamId], [TvShowId], [Season], [MediaStreamTypeId], [Length], [Title], [Synopsis], [ImageUri]) VALUES (5, N'1ecba017-eadc-4212-87b4-4cc755660b41', 1, 1, 1, CAST(N'00:21:00' AS Time), N'The Hamburger Postulate', N'Leslie seduces Leonard, but afterwards tells him that she is only interested in a one-night stand.', N'http://ia.media-imdb.com/images/M/MV5BMTY3NDk3MzYyNF5BMl5BanBnXkFtZTgwMTYzMTY1MjE@._V1_SY317_CR104,0,214,317_AL_.jpg')
INSERT [dbo].[MediaStream] ([Id], [StreamId], [TvShowId], [Season], [MediaStreamTypeId], [Length], [Title], [Synopsis], [ImageUri]) VALUES (6, N'42d6beb3-a336-424e-852d-55bf2eac7498', 1, 1, 1, CAST(N'00:21:00' AS Time), N'The Middle Earth Paradigm', N'The guys are invited to Penny''s Halloween party, where Leonard has yet another run-in with Penny''s ex-boyfriend Kurt.', N'http://ia.media-imdb.com/images/M/MV5BMTQzODgxMTM5M15BMl5BanBnXkFtZTgwMDYzMTY1MjE@._V1_SY317_CR104,0,214,317_AL_.jpg')
INSERT [dbo].[MediaStream] ([Id], [StreamId], [TvShowId], [Season], [MediaStreamTypeId], [Length], [Title], [Synopsis], [ImageUri]) VALUES (7, N'01517eb5-2f17-4d0b-b0de-cd5a1dcdf0f6', NULL, NULL, 2, CAST(N'01:29:00' AS Time), N'Lucy', N'A woman, accidentally caught in a dark deal, turns the tables on her captors and transforms into a merciless warrior evolved beyond human logic.', N'http://ia.media-imdb.com/images/M/MV5BODcxMzY3ODY1NF5BMl5BanBnXkFtZTgwNzg1NDY4MTE@._V1_SX214_AL_.jpg')
INSERT [dbo].[MediaStream] ([Id], [StreamId], [TvShowId], [Season], [MediaStreamTypeId], [Length], [Title], [Synopsis], [ImageUri]) VALUES (8, N'f2b59ccd-271c-461a-a6a6-df7cb397a2f0', NULL, NULL, 2, CAST(N'02:16:00' AS Time), N'Captain America: The Winter Soldier', N'Steve Rogers struggles to embrace his role in the modern world and battles a new threat from old history: the Soviet agent known as the Winter Soldier.', N'http://ia.media-imdb.com/images/M/MV5BMzA2NDkwODAwM15BMl5BanBnXkFtZTgwODk5MTgzMTE@._V1_SY317_CR1,0,214,317_AL_.jpg')
INSERT [dbo].[MediaStream] ([Id], [StreamId], [TvShowId], [Season], [MediaStreamTypeId], [Length], [Title], [Synopsis], [ImageUri]) VALUES (9, N'7aefee1c-b527-4877-98a5-1603f0c63a29', NULL, NULL, 2, CAST(N'03:00:00' AS Time), N'The Wolf of Wall Street', N'Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.', N'http://ia.media-imdb.com/images/M/MV5BMjIxMjgxNTk0MF5BMl5BanBnXkFtZTgwNjIyOTg2MDE@._V1_SX214_AL_.jpg')
INSERT [dbo].[MediaStream] ([Id], [StreamId], [TvShowId], [Season], [MediaStreamTypeId], [Length], [Title], [Synopsis], [ImageUri]) VALUES (10, N'e10545a4-7081-4ab0-abc6-50533104c50f', 1, 2, 1, CAST(N'00:22:00' AS Time), N'The Bad Fish Paradigm', N'Leonard becomes concerned when his date with Penny ends abruptly and she starts blowing him off. When told the truth, Sheldon would rather move out than keep Penny''s reasons a secret from Leonard.', N'http://ia.media-imdb.com/images/M/MV5BMjAxNzM5MDk2MV5BMl5BanBnXkFtZTcwMjE4MzU5MQ@@._V1_SY317_CR44,0,214,317_AL_.jpg')
INSERT [dbo].[MediaStream] ([Id], [StreamId], [TvShowId], [Season], [MediaStreamTypeId], [Length], [Title], [Synopsis], [ImageUri]) VALUES (11, N'594e1d0b-667c-4dd8-8296-d1f2b330e2aa', 1, 2, 1, CAST(N'00:21:00' AS Time), N'The Codpiece Topology', N'Sheldon is annoyed when Leonard turns to Leslie for comfort after seeing Penny with her new boyfriend.', N'http://ia.media-imdb.com/images/M/MV5BMTcyNDMwNTIzOF5BMl5BanBnXkFtZTcwMzk3MzU5MQ@@._V1_SY317_CR62,0,214,317_AL_.jpg')
INSERT [dbo].[MediaStream] ([Id], [StreamId], [TvShowId], [Season], [MediaStreamTypeId], [Length], [Title], [Synopsis], [ImageUri]) VALUES (12, N'afb717d6-66af-4264-9e94-d9d66f42cc53', 1, 2, 1, CAST(N'00:21:00' AS Time), N'The Barbarian Sublimation', N'Sheldon introduces Penny to online gaming, however she refuses to quit after becoming addicted.', N'http://ia.media-imdb.com/images/M/MV5BMjMxODU5OTk0M15BMl5BanBnXkFtZTgwNjcwMDU1MjE@._V1_SY317_CR104,0,214,317_AL_.jpg')
INSERT [dbo].[MediaStream] ([Id], [StreamId], [TvShowId], [Season], [MediaStreamTypeId], [Length], [Title], [Synopsis], [ImageUri]) VALUES (13, N'8ad33903-3255-41d5-8f34-cd563b2d3e6c', 1, 2, 1, CAST(N'00:21:00' AS Time), N'The Griffin Equivalency', N'The guys struggle to cope with Raj''s arrogance after he is featured in a People magazine article.', N'http://ia.media-imdb.com/images/M/MV5BMjIxOTMwNzMzMV5BMl5BanBnXkFtZTgwMzgwMDU1MjE@._V1_SY317_CR104,0,214,317_AL_.jpg')
INSERT [dbo].[MediaStream] ([Id], [StreamId], [TvShowId], [Season], [MediaStreamTypeId], [Length], [Title], [Synopsis], [ImageUri]) VALUES (14, N'fbf5bfd4-6994-430d-a0bd-cf2281170938', 1, 2, 1, CAST(N'00:20:00' AS Time), N'The Euclid Alternative', N'Sheldon annoys the rest of the gang when Leonard can''t drive him to and from work, so they try to teach him how to drive.', N'http://ia.media-imdb.com/images/M/MV5BMTcwNTU4MTg0NF5BMl5BanBnXkFtZTgwNzQwMDU1MjE@._V1_SY317_CR104,0,214,317_AL_.jpg')
INSERT [dbo].[MediaStream] ([Id], [StreamId], [TvShowId], [Season], [MediaStreamTypeId], [Length], [Title], [Synopsis], [ImageUri]) VALUES (15, N'd0519050-ac87-4641-baa9-dfda39ee2852', 1, 2, 1, CAST(N'00:21:00' AS Time), N'The Cooper-Nowitzki Theorem', N'Sheldon is flattered when a graduate student takes a shine to him, however her extreme devotion becomes too much to handle.', N'http://ia.media-imdb.com/images/M/MV5BMTk3NTczNTE3MF5BMl5BanBnXkFtZTcwNDEzMTIwMg@@._V1_SX214_AL_.jpg')
SET IDENTITY_INSERT [dbo].[MediaStream] OFF
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (1, 5)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (2, 5)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (3, 5)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (4, 5)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (5, 5)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (6, 5)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (7, 1)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (7, 21)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (7, 25)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (8, 1)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (8, 2)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (8, 21)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (9, 4)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (9, 5)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (9, 6)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (10, 5)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (11, 5)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (12, 5)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (13, 5)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (14, 5)
INSERT [dbo].[MediaStreamGenre] ([MediaStreamId], [GenreId]) VALUES (15, 5)
INSERT [dbo].[ShowSeason] ([TvShowId], [Season]) VALUES (1, 1)
INSERT [dbo].[ShowSeason] ([TvShowId], [Season]) VALUES (1, 2)
SET IDENTITY_INSERT [dbo].[SubscriptionModel] ON 

INSERT [dbo].[SubscriptionModel] ([Id], [Name], [Description], [Price]) VALUES (1, N'Silver', NULL, 5.9900)
INSERT [dbo].[SubscriptionModel] ([Id], [Name], [Description], [Price]) VALUES (2, N'Gold', NULL, 6.9900)
INSERT [dbo].[SubscriptionModel] ([Id], [Name], [Description], [Price]) VALUES (3, N'Platinum', NULL, 9.9900)
SET IDENTITY_INSERT [dbo].[SubscriptionModel] OFF
INSERT [dbo].[SubscriptionOption] ([SubscriptionModelId], [SubscriptionOptionTemplateId], [Value]) VALUES (1, 1, N'False')
INSERT [dbo].[SubscriptionOption] ([SubscriptionModelId], [SubscriptionOptionTemplateId], [Value]) VALUES (1, 2, N'False')
INSERT [dbo].[SubscriptionOption] ([SubscriptionModelId], [SubscriptionOptionTemplateId], [Value]) VALUES (1, 5, N'1')
INSERT [dbo].[SubscriptionOption] ([SubscriptionModelId], [SubscriptionOptionTemplateId], [Value]) VALUES (2, 1, N'True')
INSERT [dbo].[SubscriptionOption] ([SubscriptionModelId], [SubscriptionOptionTemplateId], [Value]) VALUES (2, 2, N'False')
INSERT [dbo].[SubscriptionOption] ([SubscriptionModelId], [SubscriptionOptionTemplateId], [Value]) VALUES (2, 5, N'2')
INSERT [dbo].[SubscriptionOption] ([SubscriptionModelId], [SubscriptionOptionTemplateId], [Value]) VALUES (3, 1, N'True')
INSERT [dbo].[SubscriptionOption] ([SubscriptionModelId], [SubscriptionOptionTemplateId], [Value]) VALUES (3, 2, N'True')
INSERT [dbo].[SubscriptionOption] ([SubscriptionModelId], [SubscriptionOptionTemplateId], [Value]) VALUES (3, 5, N'4')
SET IDENTITY_INSERT [dbo].[SubscriptionOptionTemplate] ON 

INSERT [dbo].[SubscriptionOptionTemplate] ([Id], [OptionTypeId], [Name], [Description]) VALUES (1, 1, N'HD available', NULL)
INSERT [dbo].[SubscriptionOptionTemplate] ([Id], [OptionTypeId], [Name], [Description]) VALUES (2, 1, N'Ultra-HD available', NULL)
INSERT [dbo].[SubscriptionOptionTemplate] ([Id], [OptionTypeId], [Name], [Description]) VALUES (5, 2, N'Screens', N'Screens you can watch on at the same time')
SET IDENTITY_INSERT [dbo].[SubscriptionOptionTemplate] OFF
SET IDENTITY_INSERT [dbo].[TvShow] ON 

INSERT [dbo].[TvShow] ([Id], [Title], [ImageUri]) VALUES (1, N'The Big Bang Theory', N'http://ia.media-imdb.com/images/M/MV5BMjI1Mzc4MDUwNl5BMl5BanBnXkFtZTgwMDAzOTIxMjE@._V1_SY317_CR20,0,214,317_AL_.jpg')
SET IDENTITY_INSERT [dbo].[TvShow] OFF
INSERT [dbo].[TvShowGenre] ([TvShowId], [GenreId]) VALUES (1, 5)
ALTER TABLE [dbo].[CastMember]  WITH CHECK ADD  CONSTRAINT [FK_CastMember_Celebrity] FOREIGN KEY([CelebrityId])
REFERENCES [dbo].[Celebrity] ([Id])
GO
ALTER TABLE [dbo].[CastMember] CHECK CONSTRAINT [FK_CastMember_Celebrity]
GO
ALTER TABLE [dbo].[CastMember]  WITH CHECK ADD  CONSTRAINT [FK_CastMember_MediaRole] FOREIGN KEY([MediaRoleId])
REFERENCES [dbo].[MediaRole] ([Id])
GO
ALTER TABLE [dbo].[CastMember] CHECK CONSTRAINT [FK_CastMember_MediaRole]
GO
ALTER TABLE [dbo].[CastMember]  WITH CHECK ADD  CONSTRAINT [FK_CastMember_MediaStream] FOREIGN KEY([MediaStreamId])
REFERENCES [dbo].[MediaStream] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CastMember] CHECK CONSTRAINT [FK_CastMember_MediaStream]
GO
ALTER TABLE [dbo].[MediaStream]  WITH CHECK ADD  CONSTRAINT [FK_MediaStream_ShowSeason] FOREIGN KEY([TvShowId], [Season])
REFERENCES [dbo].[ShowSeason] ([TvShowId], [Season])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MediaStream] CHECK CONSTRAINT [FK_MediaStream_ShowSeason]
GO
ALTER TABLE [dbo].[MediaStreamGenre]  WITH CHECK ADD  CONSTRAINT [FK_MediaStreamGenre_Genre] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([Id])
GO
ALTER TABLE [dbo].[MediaStreamGenre] CHECK CONSTRAINT [FK_MediaStreamGenre_Genre]
GO
ALTER TABLE [dbo].[MediaStreamGenre]  WITH CHECK ADD  CONSTRAINT [FK_MediaStreamGenre_MediaStream] FOREIGN KEY([MediaStreamId])
REFERENCES [dbo].[MediaStream] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MediaStreamGenre] CHECK CONSTRAINT [FK_MediaStreamGenre_MediaStream]
GO
ALTER TABLE [dbo].[ShowSeason]  WITH CHECK ADD  CONSTRAINT [FK_ShowSeason_TvShow] FOREIGN KEY([TvShowId])
REFERENCES [dbo].[TvShow] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShowSeason] CHECK CONSTRAINT [FK_ShowSeason_TvShow]
GO
ALTER TABLE [dbo].[Subscription]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_SubscriptionModel] FOREIGN KEY([SubscriptionModelId])
REFERENCES [dbo].[SubscriptionModel] ([Id])
GO
ALTER TABLE [dbo].[Subscription] CHECK CONSTRAINT [FK_Subscription_SubscriptionModel]
GO
ALTER TABLE [dbo].[Subscription]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subscription] CHECK CONSTRAINT [FK_Subscription_User]
GO
ALTER TABLE [dbo].[SubscriptionOption]  WITH CHECK ADD  CONSTRAINT [FK_SubscriptionOption_SubscriptionModel] FOREIGN KEY([SubscriptionModelId])
REFERENCES [dbo].[SubscriptionModel] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubscriptionOption] CHECK CONSTRAINT [FK_SubscriptionOption_SubscriptionModel]
GO
ALTER TABLE [dbo].[SubscriptionOption]  WITH CHECK ADD  CONSTRAINT [FK_SubscriptionOption_SubscriptionOptionTemplate] FOREIGN KEY([SubscriptionOptionTemplateId])
REFERENCES [dbo].[SubscriptionOptionTemplate] ([Id])
GO
ALTER TABLE [dbo].[SubscriptionOption] CHECK CONSTRAINT [FK_SubscriptionOption_SubscriptionOptionTemplate]
GO
ALTER TABLE [dbo].[TvShowGenre]  WITH CHECK ADD  CONSTRAINT [FK_TvShowGenre_Genre] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([Id])
GO
ALTER TABLE [dbo].[TvShowGenre] CHECK CONSTRAINT [FK_TvShowGenre_Genre]
GO
ALTER TABLE [dbo].[TvShowGenre]  WITH CHECK ADD  CONSTRAINT [FK_TvShowGenre_TvShowGenre] FOREIGN KEY([TvShowId])
REFERENCES [dbo].[TvShow] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TvShowGenre] CHECK CONSTRAINT [FK_TvShowGenre_TvShowGenre]
GO

