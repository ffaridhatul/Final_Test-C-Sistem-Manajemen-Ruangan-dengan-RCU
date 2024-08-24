USE [RMS]
GO
ALTER TABLE [dbo].[Room] DROP CONSTRAINT [FK_Room_CheckIn]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 2017-02-21 오전 9:09:09 ******/
DROP TABLE [dbo].[Room]
GO
/****** Object:  Table [dbo].[CheckIn]    Script Date: 2017-02-21 오전 9:09:09 ******/
DROP TABLE [dbo].[CheckIn]
GO

/****** Object:  Table [dbo].[CheckIn]    Script Date: 2017-02-21 오전 9:09:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CheckIn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [nvarchar](4) NOT NULL,
	[CheckInDate] [datetime] NOT NULL,
	[CheckOutDate] [datetime] NULL,
	[CheckInDays] [int] NOT NULL,
	[Payment] [int] NOT NULL,
 CONSTRAINT [PK_CheckIn] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 2017-02-21 오전 9:09:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RcuId] [int] NOT NULL,
	[RoomNo] [nvarchar](4) NOT NULL,
	[Floor] [int] NOT NULL,
	[RoomStatus] [int] NOT NULL,
	[KeyStatus] [int] NOT NULL,
	[DoorStatus] [int] NOT NULL,
	[CheckInId] [int] NULL,
	[Temperature] [int] NULL,
	[NightlyRate] [int] NOT NULL CONSTRAINT [DF_Room_NightlyRate]  DEFAULT ((80000)),
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CheckIn] ON 

GO
INSERT [dbo].[CheckIn] ([Id], [RoomNo], [CheckInDate], [CheckOutDate], [CheckInDays], [Payment]) VALUES (1, N'101', CAST(N'2017-02-12 21:53:55.343' AS DateTime), CAST(N'2017-02-12 22:22:42.437' AS DateTime), 1, 60000)
GO
INSERT [dbo].[CheckIn] ([Id], [RoomNo], [CheckInDate], [CheckOutDate], [CheckInDays], [Payment]) VALUES (2, N'203', CAST(N'2017-02-12 21:54:45.757' AS DateTime), CAST(N'2017-02-12 21:54:52.110' AS DateTime), 1, 60000)
GO
INSERT [dbo].[CheckIn] ([Id], [RoomNo], [CheckInDate], [CheckOutDate], [CheckInDays], [Payment]) VALUES (3, N'201', CAST(N'2017-02-12 22:19:49.283' AS DateTime), CAST(N'2017-02-12 22:22:52.380' AS DateTime), 1, 60000)
GO
SET IDENTITY_INSERT [dbo].[CheckIn] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

GO
INSERT [dbo].[Room] ([Id], [RcuId], [RoomNo], [Floor], [RoomStatus], [KeyStatus], [DoorStatus], [CheckInId], [Temperature], [NightlyRate]) VALUES (1, 1, N'101', 1, 0, 0, 1, NULL, 27, 60000)
GO
INSERT [dbo].[Room] ([Id], [RcuId], [RoomNo], [Floor], [RoomStatus], [KeyStatus], [DoorStatus], [CheckInId], [Temperature], [NightlyRate]) VALUES (2, 2, N'102', 1, 0, 0, 1, NULL, 21, 60000)
GO
INSERT [dbo].[Room] ([Id], [RcuId], [RoomNo], [Floor], [RoomStatus], [KeyStatus], [DoorStatus], [CheckInId], [Temperature], [NightlyRate]) VALUES (4, 3, N'103', 1, 0, 0, 1, NULL, 19, 60000)
GO
INSERT [dbo].[Room] ([Id], [RcuId], [RoomNo], [Floor], [RoomStatus], [KeyStatus], [DoorStatus], [CheckInId], [Temperature], [NightlyRate]) VALUES (5, 4, N'104', 1, 0, 2, 1, NULL, 28, 60000)
GO
INSERT [dbo].[Room] ([Id], [RcuId], [RoomNo], [Floor], [RoomStatus], [KeyStatus], [DoorStatus], [CheckInId], [Temperature], [NightlyRate]) VALUES (6, 5, N'105', 1, 0, 2, 1, NULL, 25, 60000)
GO
INSERT [dbo].[Room] ([Id], [RcuId], [RoomNo], [Floor], [RoomStatus], [KeyStatus], [DoorStatus], [CheckInId], [Temperature], [NightlyRate]) VALUES (7, 6, N'201', 2, 0, 2, 1, NULL, 24, 60000)
GO
INSERT [dbo].[Room] ([Id], [RcuId], [RoomNo], [Floor], [RoomStatus], [KeyStatus], [DoorStatus], [CheckInId], [Temperature], [NightlyRate]) VALUES (8, 7, N'202', 2, 0, 1, 1, NULL, 27, 60000)
GO
INSERT [dbo].[Room] ([Id], [RcuId], [RoomNo], [Floor], [RoomStatus], [KeyStatus], [DoorStatus], [CheckInId], [Temperature], [NightlyRate]) VALUES (9, 8, N'203', 2, 0, 1, 1, NULL, 29, 60000)
GO
INSERT [dbo].[Room] ([Id], [RcuId], [RoomNo], [Floor], [RoomStatus], [KeyStatus], [DoorStatus], [CheckInId], [Temperature], [NightlyRate]) VALUES (10, 9, N'204', 2, 0, 1, 1, NULL, 24, 60000)
GO
INSERT [dbo].[Room] ([Id], [RcuId], [RoomNo], [Floor], [RoomStatus], [KeyStatus], [DoorStatus], [CheckInId], [Temperature], [NightlyRate]) VALUES (11, 10, N'205', 2, 0, 1, 1, NULL, 19, 60000)
GO
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_CheckIn] FOREIGN KEY([CheckInId])
REFERENCES [dbo].[CheckIn] ([Id])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_CheckIn]
GO
