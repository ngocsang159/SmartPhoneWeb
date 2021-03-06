USE [db_smartphone]
GO
/****** Object:  Table [dbo].[AccountAdmin]    Script Date: 04/25/2021 10:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountAdmin](
	[stt] [bigint] NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Avatar] [nvarchar](500) NULL,
	[Gender] [int] NULL,
	[Displayname] [nvarchar](50) NULL,
	[Phone] [int] NULL,
	[Facebook] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Status] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banner]    Script Date: 04/25/2021 10:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banner](
	[stt] [bigint] IDENTITY(1,1) NOT NULL,
	[Banner_Id] [varchar](50) NOT NULL,
	[Banner_Name] [nvarchar](50) NULL,
	[Banner_Title] [nvarchar](250) NULL,
	[Banner_Type] [int] NULL,
	[Banner_Image] [text] NULL,
	[Product_Id] [varchar](50) NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Banner] PRIMARY KEY CLUSTERED 
(
	[Banner_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 04/25/2021 10:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Stt] [bigint] IDENTITY(1,1) NOT NULL,
	[Brand_id] [varchar](50) NOT NULL,
	[Brand_name] [nvarchar](100) NULL,
	[Country] [nvarchar](100) NULL,
	[Status] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Brand_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 04/25/2021 10:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Customer_id] [bigint] IDENTITY(1,1) NOT NULL,
	[Customer_name] [nvarchar](250) NULL,
	[phone] [bigint] NULL,
	[email] [nvarchar](50) NULL,
	[Password] [nvarchar](250) NULL,
	[DistrictId] [varchar](50) NULL,
	[ProvinceId] [varchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](250) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[District]    Script Date: 04/25/2021 10:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[Stt] [bigint] IDENTITY(1,1) NOT NULL,
	[DistrictId] [varchar](50) NOT NULL,
	[DistrictName] [nvarchar](50) NULL,
	[DistrictType] [nvarchar](50) NULL,
	[ProvinceId] [varchar](50) NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 04/25/2021 10:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Order_id] [bigint] IDENTITY(1,1) NOT NULL,
	[fullname] [nvarchar](250) NULL,
	[phone] [bigint] NULL,
	[email] [nvarchar](50) NULL,
	[ProvinceId] [varchar](50) NULL,
	[DistrictId] [varchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Note] [nvarchar](250) NULL,
	[Order_Status_Id] [varchar](50) NULL,
	[Customer_id] [bigint] NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](250) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_details]    Script Date: 04/25/2021 10:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_details](
	[stt] [bigint] IDENTITY(1,1) NOT NULL,
	[Order_id] [bigint] NOT NULL,
	[Product_id] [varchar](50) NOT NULL,
	[Quantity] [int] NULL,
	[price] [decimal](18, 0) NULL,
	[price_ship] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Order_details] PRIMARY KEY CLUSTERED 
(
	[Order_id] ASC,
	[Product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Status]    Script Date: 04/25/2021 10:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Status](
	[Stt] [bigint] IDENTITY(1,1) NOT NULL,
	[Order_Status_Id] [varchar](50) NOT NULL,
	[Order_Status_Name] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Order_Status] PRIMARY KEY CLUSTERED 
(
	[Order_Status_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 04/25/2021 10:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Stt] [bigint] IDENTITY(1,1) NOT NULL,
	[Product_Id] [varchar](50) NOT NULL,
	[Product_Name] [nvarchar](50) NULL,
	[ImgaeAvatar] [nvarchar](max) NULL,
	[Price] [decimal](18, 0) NULL,
	[Original_Price] [decimal](18, 0) NULL,
	[Product_Category_TypeId] [varchar](50) NULL,
	[ApplyDate] [datetime] NULL,
	[Brand_id] [varchar](50) NULL,
	[Is_Hot] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[Product_Infor] [nvarchar](max) NULL,
	[Old_New] [int] NULL,
	[Quantity] [bigint] NULL,
	[Status] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Product_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Category]    Script Date: 04/25/2021 10:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Category](
	[Stt] [bigint] IDENTITY(1,1) NOT NULL,
	[Product_CategoryId] [varchar](50) NOT NULL,
	[Product_CategoryName] [nvarchar](250) NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](250) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Product_Category] PRIMARY KEY CLUSTERED 
(
	[Product_CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Category_Type]    Script Date: 04/25/2021 10:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Category_Type](
	[Stt] [bigint] IDENTITY(1,1) NOT NULL,
	[Product_Category_TypeId] [varchar](50) NOT NULL,
	[Product_Category_TypeName] [nvarchar](250) NULL,
	[Product_CategoryId] [varchar](50) NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](250) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Product_Category_Type] PRIMARY KEY CLUSTERED 
(
	[Product_Category_TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Color]    Script Date: 04/25/2021 10:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Color](
	[Stt] [bigint] IDENTITY(1,1) NOT NULL,
	[Color_Id] [varchar](50) NOT NULL,
	[Color_name] [nvarchar](50) NULL,
	[Product_Id] [varchar](50) NULL,
	[Status] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Product_Color] PRIMARY KEY CLUSTERED 
(
	[Color_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_image]    Script Date: 04/25/2021 10:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_image](
	[Stt] [bigint] IDENTITY(1,1) NOT NULL,
	[Image_Id] [varchar](50) NOT NULL,
	[Image_Name] [nvarchar](250) NULL,
	[Image] [nvarchar](max) NULL,
	[Image_Type] [nvarchar](250) NULL,
	[Product_Id] [varchar](50) NULL,
	[Description] [nvarchar](250) NULL,
	[Status] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Product_image] PRIMARY KEY CLUSTERED 
(
	[Image_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Specifications]    Script Date: 04/25/2021 10:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Specifications](
	[Stt] [bigint] IDENTITY(1,1) NOT NULL,
	[Specification_Id] [varchar](50) NOT NULL,
	[Specification_Name] [nvarchar](250) NULL,
	[Screen] [nvarchar](250) NULL,
	[Camera_rear] [nvarchar](250) NULL,
	[Camera_Selfie] [nvarchar](250) NULL,
	[RAM] [nvarchar](250) NULL,
	[Internal_memory] [nvarchar](250) NULL,
	[CPU] [nvarchar](250) NULL,
	[GPU] [nvarchar](250) NULL,
	[Battery_capacity] [nvarchar](250) NULL,
	[SIM] [nvarchar](250) NULL,
	[Operating_System] [nvarchar](250) NULL,
	[Made_In] [nvarchar](250) NULL,
	[Launch_Time] [datetime] NULL,
	[Product_Id] [varchar](50) NULL,
	[Status] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Product_Specifications] PRIMARY KEY CLUSTERED 
(
	[Specification_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Province]    Script Date: 04/25/2021 10:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Province](
	[Stt] [bigint] IDENTITY(1,1) NOT NULL,
	[ProvinceId] [varchar](50) NOT NULL,
	[ProvinceName] [nvarchar](50) NULL,
	[ProvinceType] [nvarchar](50) NULL,
 CONSTRAINT [PK_Province] PRIMARY KEY CLUSTERED 
(
	[ProvinceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 04/25/2021 10:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[Stt] [bigint] IDENTITY(1,1) NOT NULL,
	[Id] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Hotline] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Facebook] [nvarchar](50) NULL,
	[Content_text] [nvarchar](500) NULL,
	[Introduce] [nvarchar](500) NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AccountAdmin] ADD  CONSTRAINT [DF_Admin_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[AccountAdmin] ADD  CONSTRAINT [DF_Admin_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Banner] ADD  CONSTRAINT [DF_Banner_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Banner] ADD  CONSTRAINT [DF_Banner_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Product_Color] ADD  CONSTRAINT [DF_Product_Color_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Product_Color] ADD  CONSTRAINT [DF_Product_Color_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Product_image] ADD  CONSTRAINT [DF_Product_image_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Product_image] ADD  CONSTRAINT [DF_Product_image_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Product_Specifications] ADD  CONSTRAINT [DF_Product_Specifications_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Product_Specifications] ADD  CONSTRAINT [DF_Product_Specifications_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Banner]  WITH CHECK ADD  CONSTRAINT [FK_Banner_Product] FOREIGN KEY([Product_Id])
REFERENCES [dbo].[Product] ([Product_Id])
GO
ALTER TABLE [dbo].[Banner] CHECK CONSTRAINT [FK_Banner_Product]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Province] FOREIGN KEY([ProvinceId])
REFERENCES [dbo].[Province] ([ProvinceId])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Province]
GO
ALTER TABLE [dbo].[District]  WITH CHECK ADD  CONSTRAINT [FK_District_Province] FOREIGN KEY([ProvinceId])
REFERENCES [dbo].[Province] ([ProvinceId])
GO
ALTER TABLE [dbo].[District] CHECK CONSTRAINT [FK_District_Province]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Brand] FOREIGN KEY([Brand_id])
REFERENCES [dbo].[Brand] ([Brand_id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Brand]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Product_Category_Type] FOREIGN KEY([Product_Category_TypeId])
REFERENCES [dbo].[Product_Category_Type] ([Product_Category_TypeId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Product_Category_Type]
GO
ALTER TABLE [dbo].[Product_Category_Type]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category_Type_Product_Category] FOREIGN KEY([Product_CategoryId])
REFERENCES [dbo].[Product_Category] ([Product_CategoryId])
GO
ALTER TABLE [dbo].[Product_Category_Type] CHECK CONSTRAINT [FK_Product_Category_Type_Product_Category]
GO
