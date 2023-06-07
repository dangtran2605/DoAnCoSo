create database DatLichHen
go
USE DatLichHen
GO
/****** Object:  Table [dbo].[accountAD]    Script Date: 5/28/2023 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accountAD](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](200) NULL,
	[passWord] [nvarchar](200) NULL,
	[idStaff] [int] NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_accountAD] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[booking]    Script Date: 5/28/2023 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[booking](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fullName] [nvarchar](200) NULL,
	[phone] [nvarchar](11) NULL,
	[email] [nvarchar](100) NULL,
	[address] [nvarchar](200) NULL,
	[dateCheckIn] [datetime] NULL,
	[people] [int] NULL,
	[isConfirm] [bit] NULL,
	[isDisable] [bit] NULL,
	[isDone] [bit] NULL,
	idStaff int Null,
 CONSTRAINT [PK_booking] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[categoryService]    Script Date: 5/28/2023 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoryService](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[categoryName] [nvarchar](100) NULL,
 CONSTRAINT [PK_categoryService] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[detailBooking]    Script Date: 5/28/2023 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detailBooking](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBooking] [int] NULL,
	[idService] [int] NULL,
 CONSTRAINT [PK_detail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[news]    Script Date: 5/28/2023 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[news](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[newsTitle] [nvarchar](200) NULL,
	[detail] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[image] [nvarchar](500) NULL,
	[isActive] [bit] NULL,
	[createById] [int] NULL,
	[dateCreate] [datetime] NULL,
 CONSTRAINT [PK_news] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[position]    Script Date: 5/28/2023 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[position](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[positionName] [nvarchar](100) NULL,
 CONSTRAINT [PK_position] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sale]    Script Date: 5/28/2023 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sale](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[discount] [nvarchar](50) NULL,
	[image] [nvarchar](500) NULL,
	[isNumble] [float] NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_sale] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[service]    Script Date: 5/28/2023 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[service](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[serviceName] [nvarchar](200) NULL,
	[price] [float] NULL,
	[priceSale] [float] NULL,
	[idCategory] [int] NULL,
	[isActive] [bit] NULL,
	[idSale] [int] NULL,
	[detail] [nvarchar](max) NULL,
	[image] [nvarchar](500) NULL,
 CONSTRAINT [PK_service] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[staff]    Script Date: 5/28/2023 7:56:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[staff](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fullName] [nvarchar](100) NULL,
	[detail] [nvarchar](max) NULL,
	[born] [date] NULL,
	[address] [nvarchar](500) NULL,
	[idPosition] [int] NULL,
	[email] [nvarchar](200) NULL,
	[phone] [nvarchar](11) NULL,
 CONSTRAINT [PK_staff] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[accountAD] ON 

INSERT [dbo].[accountAD] ([id], [userName], [passWord], [idStaff], [isActive]) VALUES (1, N'admin', N'admin', 1, 1)
SET IDENTITY_INSERT [dbo].[accountAD] OFF
SET IDENTITY_INSERT [dbo].[categoryService] ON 

INSERT [dbo].[categoryService] ([id], [categoryName]) VALUES (1, N'Hair Spa')
INSERT [dbo].[categoryService] ([id], [categoryName]) VALUES (2, N'Nails')
INSERT [dbo].[categoryService] ([id], [categoryName]) VALUES (3, N'Massage')
INSERT [dbo].[categoryService] ([id], [categoryName]) VALUES (4, N'Combo')
SET IDENTITY_INSERT [dbo].[categoryService] OFF
SET IDENTITY_INSERT [dbo].[position] ON 

INSERT [dbo].[position] ([id], [positionName]) VALUES (1, N'Staff')
INSERT [dbo].[position] ([id], [positionName]) VALUES (2, N'Manager')
INSERT [dbo].[position] ([id], [positionName]) VALUES (3, N'Owner')
SET IDENTITY_INSERT [dbo].[position] OFF
SET IDENTITY_INSERT [dbo].[staff] ON 

INSERT [dbo].[staff] ([id], [fullName], [detail], [born], [address], [idPosition], [email], [phone]) VALUES (1, N'Trần Văn Đăng', N'Chủ tiệm', CAST(N'2002-05-26' AS Date), N'HCM', 3, N'anh.hk.113@gmail.com', N'0906564920')
SET IDENTITY_INSERT [dbo].[staff] OFF
ALTER TABLE [dbo].[news] ADD  CONSTRAINT [DF_news_isActive]  DEFAULT ((0)) FOR [isActive]
GO
ALTER TABLE [dbo].[service] ADD  CONSTRAINT [DF_service_isActive]  DEFAULT ((0)) FOR [isActive]
GO
ALTER TABLE [dbo].[accountAD]  WITH CHECK ADD  CONSTRAINT [FK_accountAD_staff] FOREIGN KEY([idStaff])
REFERENCES [dbo].[staff] ([id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[accountAD] CHECK CONSTRAINT [FK_accountAD_staff]
GO
ALTER TABLE [dbo].[detailBooking]  WITH CHECK ADD  CONSTRAINT [FK_detailBooking_booking] FOREIGN KEY([idBooking])
REFERENCES [dbo].[booking] ([id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[detailBooking] CHECK CONSTRAINT [FK_detailBooking_booking]
GO
ALTER TABLE [dbo].[detailBooking]  WITH CHECK ADD  CONSTRAINT [FK_detailBooking_service] FOREIGN KEY([idService])
REFERENCES [dbo].[service] ([id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[detailBooking] CHECK CONSTRAINT [FK_detailBooking_service]
GO




ALTER TABLE [dbo].[booking]  WITH CHECK ADD  CONSTRAINT [FK_booking_staff] FOREIGN KEY([idStaff])
REFERENCES [dbo].[staff] ([id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[booking] CHECK CONSTRAINT [FK_booking_staff]
GO
ALTER TABLE [dbo].[news]  WITH CHECK ADD  CONSTRAINT [FK_news_accountAD] FOREIGN KEY([createById])
REFERENCES [dbo].[accountAD] ([id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[news] CHECK CONSTRAINT [FK_news_accountAD]
GO
ALTER TABLE [dbo].[service]  WITH CHECK ADD  CONSTRAINT [FK_service_categoryService] FOREIGN KEY([idCategory])
REFERENCES [dbo].[categoryService] ([id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[service] CHECK CONSTRAINT [FK_service_categoryService]
GO
ALTER TABLE [dbo].[service]  WITH CHECK ADD  CONSTRAINT [FK_service_sale] FOREIGN KEY([idSale])
REFERENCES [dbo].[sale] ([id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[service] CHECK CONSTRAINT [FK_service_sale]
GO
ALTER TABLE [dbo].[staff]  WITH CHECK ADD  CONSTRAINT [FK_staff_position] FOREIGN KEY([idPosition])
REFERENCES [dbo].[position] ([id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[staff] CHECK CONSTRAINT [FK_staff_position]
GO
