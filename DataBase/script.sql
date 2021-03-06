USE [OnlineStoreDB]
GO
/****** Object:  User [OnlineStore]    Script Date: 6/17/2018 10:32:23 PM ******/
CREATE USER [OnlineStore] FOR LOGIN [OnlineStore] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [sergey7138]    Script Date: 6/17/2018 10:32:23 PM ******/
CREATE USER [sergey7138] FOR LOGIN [sergey7138] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE LOGIN sergey53782 WITH PASSWORD = '123456';
Go
ALTER ROLE [db_owner] ADD MEMBER [OnlineStore]
GO
ALTER ROLE [db_owner] ADD MEMBER [sergey7138]
GO
/****** Object:  Table [dbo].[Basket]    Script Date: 6/17/2018 10:32:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Basket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Count] [int] NULL,
 CONSTRAINT [PK_ProductList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ParentId] [int] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Email]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Email](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Email2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[StatusId] [int] NOT NULL,
	[DateOrder] [date] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Phone]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Phone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[SeasonsId] [int] NOT NULL,
	[Picture] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Count] [int] NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Season]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Season](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Seasons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StatusOrder]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StatusOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserLogin] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserLoginId] [int] NOT NULL,
	[RoleId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[vBasket]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vBasket]
AS
SELECT        dbo.Basket.Id, dbo.Product.Name, dbo.Basket.OrderId, dbo.Basket.ProductId, dbo.Product.Picture, dbo.Basket.Count, dbo.Product.Price
FROM            dbo.Basket INNER JOIN
                         dbo.Product ON dbo.Basket.ProductId = dbo.Product.Id

GO
/****** Object:  View [dbo].[vCategory]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vCategory]
AS
SELECT        Id, Name ,ParentId
FROM            dbo.Category

GO
/****** Object:  View [dbo].[vEmail]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vEmail]
AS
SELECT        UserId, Email
FROM            dbo.Email

GO
/****** Object:  View [dbo].[vOrder]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vOrder]
AS
SELECT        dbo.[Order].Id, dbo.[Order].UserId, dbo.[Order].Address, dbo.[Order].StatusId, dbo.[Order].DateOrder
FROM            dbo.[Order] INNER JOIN
                         dbo.StatusOrder ON dbo.[Order].StatusId = dbo.StatusOrder.Id INNER JOIN
                         dbo.[User] ON dbo.[Order].Id = dbo.[User].Id

GO
/****** Object:  View [dbo].[vPhone]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vPhone]
AS
SELECT        UserId, Phone
FROM            dbo.Phone

GO
/****** Object:  View [dbo].[vProduct]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vProduct]
AS
SELECT        dbo.Product.Id, dbo.Product.Name, dbo.Product.CategoryId, dbo.Product.SeasonsId, dbo.Product.Picture, dbo.Product.Description, dbo.Product.Count, dbo.Product.Price
FROM            dbo.Product INNER JOIN
                         dbo.Category ON dbo.Product.CategoryId = dbo.Category.Id INNER JOIN
                         dbo.Season ON dbo.Product.SeasonsId = dbo.Season.Id

GO
/****** Object:  View [dbo].[vRole]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vRole]
AS
SELECT        Id, Name
FROM            dbo.Role

GO
/****** Object:  View [dbo].[vSeason]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vSeason]
AS
SELECT        Id, Name
FROM            dbo.Season

GO
/****** Object:  View [dbo].[vStatusOrder]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vStatusOrder]
AS
SELECT        Id, Name
FROM            dbo.StatusOrder

GO
/****** Object:  View [dbo].[vUser3]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vUser3]
AS
SELECT        dbo.[User].Id, dbo.[User].UserLogin, dbo.[User].Password, dbo.[User].Name, dbo.[User].LastName, dbo.UserRole.RoleId, dbo.Role.RoleName, dbo.Phone.Phone, dbo.Email.Email
FROM            dbo.Role INNER JOIN
                         dbo.UserRole ON dbo.Role.Id = dbo.UserRole.RoleId INNER JOIN
                         dbo.[User] ON dbo.UserRole.UserLoginId = dbo.[User].Id INNER JOIN
                         dbo.Email ON dbo.[User].Id = dbo.Email.UserId INNER JOIN
                         dbo.Phone ON dbo.[User].Id = dbo.Phone.UserId

GO
/****** Object:  View [dbo].[VUserContacts]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VUserContacts]
AS
SELECT        dbo.[User].Id, dbo.[User].UserLogin, dbo.Phone.Phone, dbo.Email.Email
FROM            dbo.Email INNER JOIN
                         dbo.[User] ON dbo.Email.UserId = dbo.[User].Id INNER JOIN
                         dbo.Phone ON dbo.[User].Id = dbo.Phone.UserId

GO
SET IDENTITY_INSERT [dbo].[Basket] ON 

INSERT [dbo].[Basket] ([Id], [OrderId], [ProductId], [Count]) VALUES (1230, 1108, 7, 2)
INSERT [dbo].[Basket] ([Id], [OrderId], [ProductId], [Count]) VALUES (1231, 1109, 9, 3)
INSERT [dbo].[Basket] ([Id], [OrderId], [ProductId], [Count]) VALUES (1232, 1109, 7, 23)
INSERT [dbo].[Basket] ([Id], [OrderId], [ProductId], [Count]) VALUES (1233, 1109, 25, 19)
INSERT [dbo].[Basket] ([Id], [OrderId], [ProductId], [Count]) VALUES (1234, 1109, 20, 13)
SET IDENTITY_INSERT [dbo].[Basket] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [ParentId]) VALUES (10, N'Деревья', 0)
INSERT [dbo].[Category] ([Id], [Name], [ParentId]) VALUES (12, N'Яблоня', 10)
INSERT [dbo].[Category] ([Id], [Name], [ParentId]) VALUES (13, N'Груша', 10)
INSERT [dbo].[Category] ([Id], [Name], [ParentId]) VALUES (14, N'Слива', 10)
INSERT [dbo].[Category] ([Id], [Name], [ParentId]) VALUES (16, N'Черешня', 10)
INSERT [dbo].[Category] ([Id], [Name], [ParentId]) VALUES (17, N'Смородина', 1108)
INSERT [dbo].[Category] ([Id], [Name], [ParentId]) VALUES (1104, N'Абрикос', 10)
INSERT [dbo].[Category] ([Id], [Name], [ParentId]) VALUES (1106, N'Виноград', 1108)
INSERT [dbo].[Category] ([Id], [Name], [ParentId]) VALUES (1108, N'Кусты', 0)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Email] ON 

INSERT [dbo].[Email] ([Id], [UserId], [Email]) VALUES (4, 4, N'qwe')
INSERT [dbo].[Email] ([Id], [UserId], [Email]) VALUES (1061, 1059, N'sergey7138@tut.by')
INSERT [dbo].[Email] ([Id], [UserId], [Email]) VALUES (1062, 1061, N'sergey7138@tut.by')
INSERT [dbo].[Email] ([Id], [UserId], [Email]) VALUES (1063, 1062, N'sergey7138@tut.by')
INSERT [dbo].[Email] ([Id], [UserId], [Email]) VALUES (1064, 1063, N'sergey7138@tut.by')
SET IDENTITY_INSERT [dbo].[Email] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [UserId], [Address], [StatusId], [DateOrder]) VALUES (1108, 1062, N'пр.Мира 41 кв2 п3 ', 4, CAST(N'2018-06-19' AS Date))
INSERT [dbo].[Order] ([Id], [UserId], [Address], [StatusId], [DateOrder]) VALUES (1109, 1062, N' не указан ', 1, CAST(N'2018-06-19' AS Date))
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[Phone] ON 

INSERT [dbo].[Phone] ([Id], [UserId], [Phone]) VALUES (1096, 1059, N'+(375)-44-537-82-87')
INSERT [dbo].[Phone] ([Id], [UserId], [Phone]) VALUES (1097, 1061, N'+(375)-44-537-82-87')
INSERT [dbo].[Phone] ([Id], [UserId], [Phone]) VALUES (1098, 1062, N'+(375)-44-537-82-87')
INSERT [dbo].[Phone] ([Id], [UserId], [Phone]) VALUES (1099, 1063, N'+(375)-44-537-82-87')
SET IDENTITY_INSERT [dbo].[Phone] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [SeasonsId], [Picture], [Description], [Count], [Price]) VALUES (7, N'Мечта', 12, 1, N'picture_Mechta.jpg', N'кисло-сладкое', 100, 10)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [SeasonsId], [Picture], [Description], [Count], [Price]) VALUES (8, N'Просто Мария', 13, 1, N'picture_ProstoMaria.jpg', N'сладкое', 1000, 15)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [SeasonsId], [Picture], [Description], [Count], [Price]) VALUES (9, N'Ипуть', 16, 2, N'picture_Iput.jpg', N'сладкое', 100, 10)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [SeasonsId], [Picture], [Description], [Count], [Price]) VALUES (10, N'Гуливер', 17, 1, N'picture_default.jpg', N'сладкая', 40, 7)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [SeasonsId], [Picture], [Description], [Count], [Price]) VALUES (18, N'Бел. сладкое', 12, 3, N'picture_BelSladkoe.jpg', N'на хранение', 130, 10)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [SeasonsId], [Picture], [Description], [Count], [Price]) VALUES (20, N'Елена', 12, 1, N'picture_Elena.jpg', N'сладкое', 133, 10)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [SeasonsId], [Picture], [Description], [Count], [Price]) VALUES (23, N'Золотая', 16, 1, N'picture_default.jpg', N'желтая сладкая ранняя ', 120, 16)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [SeasonsId], [Picture], [Description], [Count], [Price]) VALUES (25, N'Слива', 14, 1, N'picture_default.jpg', N'описание', 100, 15)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [SeasonsId], [Picture], [Description], [Count], [Price]) VALUES (1058, N'Флора', 1106, 1, N'picture_default.jpg', N'Сладкий зеленый без косточек', 1, 8)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [SeasonsId], [Picture], [Description], [Count], [Price]) VALUES (1059, N'3232', 1104, 1, N'picture_default.jpg', N'32', 32, 32)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [RoleName]) VALUES (1, N'admin')
INSERT [dbo].[Role] ([Id], [RoleName]) VALUES (2, N'user')
INSERT [dbo].[Role] ([Id], [RoleName]) VALUES (3, N'editor')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Season] ON 

INSERT [dbo].[Season] ([Id], [Name]) VALUES (1, N'лето')
INSERT [dbo].[Season] ([Id], [Name]) VALUES (2, N'осень')
INSERT [dbo].[Season] ([Id], [Name]) VALUES (3, N'зима')
SET IDENTITY_INSERT [dbo].[Season] OFF
SET IDENTITY_INSERT [dbo].[StatusOrder] ON 

INSERT [dbo].[StatusOrder] ([Id], [Name]) VALUES (1, N'добавление товаров')
INSERT [dbo].[StatusOrder] ([Id], [Name]) VALUES (2, N'обработка')
INSERT [dbo].[StatusOrder] ([Id], [Name]) VALUES (3, N'доставка')
INSERT [dbo].[StatusOrder] ([Id], [Name]) VALUES (4, N'оплачен')
SET IDENTITY_INSERT [dbo].[StatusOrder] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [UserLogin], [Password], [Name], [LastName]) VALUES (4, N'asdfgh', N'12312', N'Кирилл', N'Купийцу')
INSERT [dbo].[User] ([Id], [UserLogin], [Password], [Name], [LastName]) VALUES (31, N'sergey7138', N'123456', N'Сергей', N'Администратор')
INSERT [dbo].[User] ([Id], [UserLogin], [Password], [Name], [LastName]) VALUES (1059, N'admin', N'123456', N'1132123', N'Пользователь')
INSERT [dbo].[User] ([Id], [UserLogin], [Password], [Name], [LastName]) VALUES (1061, N'sergey1234', N'12213213', N'111', N'alinovskiy')
INSERT [dbo].[User] ([Id], [UserLogin], [Password], [Name], [LastName]) VALUES (1062, N'user', N'123456', N'sergey', N'alinovskiy')
INSERT [dbo].[User] ([Id], [UserLogin], [Password], [Name], [LastName]) VALUES (1063, N'editor', N'123456', N'sergey', N'alinovskiy')
SET IDENTITY_INSERT [dbo].[User] OFF
INSERT [dbo].[UserRole] ([UserLoginId], [RoleId]) VALUES (1061, 1)
INSERT [dbo].[UserRole] ([UserLoginId], [RoleId]) VALUES (1059, 1)
INSERT [dbo].[UserRole] ([UserLoginId], [RoleId]) VALUES (1062, 2)
INSERT [dbo].[UserRole] ([UserLoginId], [RoleId]) VALUES (1063, 3)
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_ProductList_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_ProductList_Order]
GO
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_ProductList_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_ProductList_Product]
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email2_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email2_User]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Setatus] FOREIGN KEY([StatusId])
REFERENCES [dbo].[StatusOrder] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Setatus]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[Phone]  WITH CHECK ADD  CONSTRAINT [FK_Phone_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Phone] CHECK CONSTRAINT [FK_Phone_User]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Season] FOREIGN KEY([SeasonsId])
REFERENCES [dbo].[Season] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Season]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserLoginId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
/****** Object:  StoredProcedure [dbo].[DeleteBasketById]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteBasketById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[Basket] WHERE Id = @Id),0) <> 0
	BEGIN
	
		DELETE FROM [dbo].[Basket] WHERE Id = @Id
	END
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteBasketByOrderId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[DeleteBasketByOrderId]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[Basket] WHERE OrderId = @Id),0) <> 0
	BEGIN
	
		DELETE FROM [dbo].[Basket] WHERE OrderId = @Id
	END
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteCategoryByCategoryId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[DeleteCategoryByCategoryId]
	@Id INT
	
AS
BEGIN
	SET NOCOUNT ON;


		DELETE FROM [dbo].[Category] WHERE Id = @Id
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteEmailByUserId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[DeleteEmailByUserId]
	@Id INT
AS
BEGIN
	
	BEGIN
		DELETE FROM [dbo].Email WHERE UserId=@Id
		--DELETE FROM [dbo].Phone WHERE UserId=@Id
		--DELETE FROM [dbo].UserRole WHERE UserLoginId=@Id
		--DELETE FROM [dbo].[User] WHERE Id = @Id
	END
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteOrderByOrderId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[DeleteOrderByOrderId]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[Order] WHERE Id = @Id),0) <> 0
	BEGIN

		--EXEC [dbo].[DeleteBaseByProductListId] @Id, OUTPUT

		DELETE FROM [dbo].[Order] WHERE Id = @Id
	END
END

GO
/****** Object:  StoredProcedure [dbo].[DeletePhoneByUserId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[DeletePhoneByUserId]
	@Id INT
AS
BEGIN
	
	BEGIN
		--DELETE FROM [dbo].Email WHERE UserId=@Id
		DELETE FROM [dbo].Phone WHERE UserId=@Id
		--DELETE FROM [dbo].UserRole WHERE UserLoginId=@Id
		--DELETE FROM [dbo].[User] WHERE Id = @Id
	END
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteProductByProductId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteProductByProductId]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[vProduct] WHERE Id = @Id),0) <> 0
	BEGIN

		DELETE FROM [dbo].Product WHERE Id = @Id

	END
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteProductInBasketById]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[DeleteProductInBasketById]
	@Id INT
	
AS
BEGIN
	SET NOCOUNT ON;


	IF ISNULL((SELECT COUNT(1) FROM [dbo].[vBasket] WHERE Id = @Id),0) <> 0
	BEGIN

		DELETE FROM [dbo].[Basket] WHERE Id = @Id
	END
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteRoleByRoleId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[DeleteRoleByRoleId]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[vRole] WHERE Id = @Id),0) <> 0
	BEGIN

		DELETE FROM [dbo].[Role] WHERE Id = @Id
	END
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteSeasonBySeasonId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[DeleteSeasonBySeasonId]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[vSeason] WHERE Id = @Id),0) <> 0
	BEGIN

		DELETE FROM [dbo].[Season] WHERE Id = @Id
	END
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteStatusOsrderByStatusOrderId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[DeleteStatusOsrderByStatusOrderId]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[vStatusOrder] WHERE Id = @Id),0) <> 0
	BEGIN

		DELETE FROM [dbo].[StatusOrder] WHERE Id = @Id
	END
END


GO
/****** Object:  StoredProcedure [dbo].[DeleteUserByUserId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[DeleteUserByUserId]
	@Id INT
AS
BEGIN
	
	BEGIN
		DELETE FROM [dbo].Email WHERE UserId=@Id
		DELETE FROM [dbo].Phone WHERE UserId=@Id
		DELETE FROM [dbo].UserRole WHERE UserLoginId=@Id
		DELETE FROM [dbo].[Order] WHERE UserId=@Id
		DELETE FROM [dbo].[User] WHERE Id = @Id
	END
END


GO
/****** Object:  StoredProcedure [dbo].[GetBasketById]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[GetBasketById]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id]
      ,[Name]
      ,[OrderId]
      ,[ProductId]
      ,[Picture]
      ,[Count]
      ,[Price]
      
	  
  FROM [dbo].[vBasket] WITH(NOLOCK) WHERE [Id] = @Id

END

GO
/****** Object:  StoredProcedure [dbo].[GetBasketByOrderId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[GetBasketByOrderId]
	@OrderId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id]
      ,[Name]
      ,[OrderId]
      ,[ProductId]
      ,[Picture]
      ,[Count]
      ,[Price]
      
	  
  FROM [dbo].[vBasket] WITH(NOLOCK) WHERE [OrderId] = @OrderId

END

GO
/****** Object:  StoredProcedure [dbo].[GetBaskets]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBaskets]
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id]
      ,[Name]
      ,[OrderId]
      ,[ProductId]
      ,[Picture]
      ,[Count]
      ,[Price]
      
	  
  FROM [dbo].[vBasket] WITH(NOLOCK)

END

GO
/****** Object:  StoredProcedure [dbo].[GetCategoryByCategoryId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCategoryByCategoryId]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [Name], [ParentId]
      
  FROM [dbo].[vCategory] WITH(NOLOCK) WHERE [Id] = @Id

END


GO
/****** Object:  StoredProcedure [dbo].[GetCategoryList]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategoryList]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Name,ParentId  FROM [dbo].[vCategory]

END
GO
/****** Object:  StoredProcedure [dbo].[GetEmailsByUserId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[GetEmailsByUserId]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Email FROM [dbo].[Email]
	where UserId=@Id

END



GO
/****** Object:  StoredProcedure [dbo].[GetEmailsList]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetEmailsList]
	AS
	SELECT Id,UserId, Email FROM [dbo].[Email]

GO
/****** Object:  StoredProcedure [dbo].[GetOrderByUserId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[GetOrderByUserId]
	@UserId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id] 
      ,[UserId]
      ,[Address]
      ,[StatusId]
      ,[DateOrder]
      
	  
  FROM [dbo].[Order] WITH(NOLOCK) WHERE [UserId] = @UserId

END



GO
/****** Object:  StoredProcedure [dbo].[GetOrders]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOrders]
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id] 
      ,[UserId]
      ,[Address]
      ,[StatusId]
      ,[DateOrder]
      
	  
  FROM [dbo].[Order] WITH(NOLOCK)

END



GO
/****** Object:  StoredProcedure [dbo].[GetOrdersList]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GetOrdersList]
AS
BEGIN
	SET NOCOUNT ON;
	
	    SELECT      dbo.[Order].Id, 
					dbo.[User].Id as UserId,
					dbo.[User].Name as UserName, 
					dbo.[User].LastName,
					dbo.[Order].Address,
					dbo.[Order].StatusId,
					dbo.StatusOrder.Name AS OrderStatusName, 
					dbo.[Order].DateOrder

		FROM dbo.[Order]
			 INNER JOIN  dbo.StatusOrder ON dbo.[Order].StatusId = dbo.StatusOrder.Id 
			 INNER JOIN  dbo.[User] ON dbo.[Order].UserId = dbo.[User].Id
			
			END


GO
/****** Object:  StoredProcedure [dbo].[GetOrdersListById]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GetOrdersListById]
@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	
	    SELECT  dbo.[Order].Id, 
				dbo.[User].Id as UserId,
				dbo.[User].Name as UserName, 
				dbo.[User].LastName,
				dbo.[Order].Address,
				dbo.[Order].StatusId,
				dbo.StatusOrder.Name AS OrderStatusName, 
				dbo.[Order].DateOrder

		FROM dbo.[Order]
			 INNER JOIN  dbo.StatusOrder ON dbo.[Order].StatusId = dbo.StatusOrder.Id 
			 INNER JOIN  dbo.[User] ON dbo.[Order].UserId = dbo.[User].Id
				WHERE  dbo.[Order].Id = @Id
			END


GO
/****** Object:  StoredProcedure [dbo].[GetOrderStatusByOrderId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================


CREATE PROCEDURE [dbo].[GetOrderStatusByOrderId]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [Name]
      
  FROM [dbo].[vStatusOrder] WITH(NOLOCK) WHERE [Id] = @Id

END


GO
/****** Object:  StoredProcedure [dbo].[GetPhonesByUserId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[GetPhonesByUserId]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Phone FROM [dbo].[Phone]
	where UserId=@Id

END



GO
/****** Object:  StoredProcedure [dbo].[GetPhonesList]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPhonesList]
	AS
	SELECT Id,UserId, Phone FROM [dbo].[Phone]

GO
/****** Object:  StoredProcedure [dbo].[GetProductByProductId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductByProductId]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [Name], [CategoryId],[SeasonsId],[Picture],[Description],[Count],[Price]
      
  FROM [dbo].[vProduct] WITH(NOLOCK) WHERE [Id] = @Id

END


GO
/****** Object:  StoredProcedure [dbo].[GetProductInBasketIdByOrderId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductInBasketIdByOrderId]
@OrderId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [ProductId]
      
  FROM [dbo].[Basket] WITH(NOLOCK) WHERE [OrderId]=@OrderId

END


GO
/****** Object:  StoredProcedure [dbo].[GetProductList]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductList]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [Name], [CategoryId],[SeasonsId],[Picture],[Description],[Count],[Price]
      
  FROM [dbo].[vProduct] WITH(NOLOCK) 

END


GO
/****** Object:  StoredProcedure [dbo].[GetProductListByProductId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetProductListByProductId]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

			SELECT       
			    dbo.Product.Id,
				dbo.Product.Name,
				c.Id as CategoryId,
				c.Name as CategoryName,
				c.ParentId as ParentId,
				s.Id as SeasonsId,
				s.Name as SeasonsName,
				dbo.Product.Picture, 
				dbo.Product.Description,
				dbo.Product.Count,
				dbo.Product.Price

			FROM   
	            dbo.Product 
				INNER JOIN  dbo.Category as c ON dbo.Product.CategoryId = c.Id 
				INNER JOIN  dbo.Season as s ON dbo.Product.SeasonsId = s.Id
			WHERE  dbo.Product.Id = @Id


END


GO
/****** Object:  StoredProcedure [dbo].[GetProducts]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetProducts]
AS
BEGIN
	SET NOCOUNT ON;

			SELECT       
			    dbo.Product.Id,
				dbo.Product.Name,
				c.Id as CategoryId,
				c.Name as CategoryName,
				c.ParentId as ParentId,
				s.Id as SeasonsId,
				s.Name as SeasonsName,
				dbo.Product.Picture, 
				dbo.Product.Description,
				dbo.Product.Count,
				dbo.Product.Price

			FROM   
	            dbo.Product 
				INNER JOIN  dbo.Category as c ON dbo.Product.CategoryId = c.Id 
				INNER JOIN  dbo.Season as s ON dbo.Product.SeasonsId = s.Id
			END


GO
/****** Object:  StoredProcedure [dbo].[GetProductsInBaskets]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[GetProductsInBaskets]
AS
BEGIN
	SET NOCOUNT ON;

			SELECT		    dbo.Basket.Id,
							dbo.[Order].Id as OrderId,
							dbo.[Order].UserId, 
							dbo.[Order].Address,
							dbo.[Order].StatusId, 
							dbo.[Order].DateOrder,
							dbo.Product.Id as ProductId,
							dbo.Product.Name,
							
							dbo.Category.Id as CategoryId,
							dbo.Category.Name as CategoryName,
							dbo.Product.SeasonsId, 
							dbo.Product.Picture,
							dbo.Product.Description,
							dbo.Product.Price,
							dbo.Basket.Count
FROM            dbo.Basket INNER JOIN
                         dbo.[Order] ON dbo.Basket.OrderId = dbo.[Order].Id INNER JOIN
                         dbo.Product ON dbo.Basket.ProductId = dbo.Product.Id INNER JOIN
						 dbo.Category ON dbo.Product.CategoryId= dbo.Category.Id

END


GO
/****** Object:  StoredProcedure [dbo].[GetProductsInBaskets2]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[GetProductsInBaskets2]
AS
BEGIN
	SET NOCOUNT ON;

			SELECT		    dbo.Basket.Id,
							dbo.[Order].Id as OrderId,
							dbo.[Order].UserId, 
							dbo.[Order].Address,
							dbo.[Order].StatusId, 
							dbo.[Order].DateOrder,
							dbo.Product.Id as ProductId,
							dbo.Product.Name,
							
							dbo.Category.Id as CategoryId,
							dbo.Category.Name as CategoryName,
							dbo.Product.SeasonsId, 
							dbo.Product.Picture,
							dbo.Product.Description,
							dbo.Product.Price,
							dbo.Basket.Count
FROM            dbo.Basket INNER JOIN
                         dbo.[Order] ON dbo.Basket.OrderId = dbo.[Order].Id INNER JOIN
                         dbo.Product ON dbo.Basket.ProductId = dbo.Product.Id INNER JOIN
						 dbo.Category ON dbo.Product.CategoryId= dbo.Category.Id

END


GO
/****** Object:  StoredProcedure [dbo].[GetProductsInBasketsByBasketId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[GetProductsInBasketsByBasketId]
@Id INT
AS
BEGIN
	SET NOCOUNT ON;

			SELECT           dbo.Basket.Id,
							dbo.[Order].Id as OrderId,
							dbo.[Order].UserId, 
							dbo.[Order].Address,
							dbo.[Order].StatusId, 
							dbo.[Order].DateOrder,
							dbo.Product.Id as ProductId,
							dbo.Product.Name,
							
							dbo.Category.Id as CategoryId,
							dbo.Category.Name as CategoryName,
							dbo.Product.SeasonsId, 
							dbo.Product.Picture,
							dbo.Product.Description,
							dbo.Product.Price,
							dbo.Basket.Count
FROM					 dbo.Basket INNER JOIN
                         dbo.[Order] ON dbo.Basket.OrderId = dbo.[Order].Id INNER JOIN
                         dbo.Product ON dbo.Basket.ProductId = dbo.Product.Id INNER JOIN
						 dbo.Category ON dbo.Product.CategoryId= dbo.Category.Id
WHERE dbo.Basket.Id=@Id

END


GO
/****** Object:  StoredProcedure [dbo].[GetRoles]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[GetRoles]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, RoleName FROM [dbo].[Role]

END



GO
/****** Object:  StoredProcedure [dbo].[GetSeasonList]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[GetSeasonList]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Name FROM [dbo].[vSeason]

END



GO
/****** Object:  StoredProcedure [dbo].[GetSeasonNames]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[GetSeasonNames]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Name FROM [dbo].[vSeason]

END



GO
/****** Object:  StoredProcedure [dbo].[GetStatusOrder]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[GetStatusOrder]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Name FROM [dbo].[StatusOrder]

END



GO
/****** Object:  StoredProcedure [dbo].[GetStatusOrderByOrderId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================



CREATE PROCEDURE [dbo].[GetStatusOrderByOrderId]
@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	
	    SELECT  
				dbo.StatusOrder.Name AS OrderStatusName

		FROM dbo.[Order]
			 INNER JOIN  dbo.StatusOrder ON dbo.[Order].StatusId = dbo.StatusOrder.Id 
			 INNER JOIN  dbo.[User] ON dbo.[Order].UserId = dbo.[User].Id
				WHERE  dbo.[Order].Id = @Id
			END


GO
/****** Object:  StoredProcedure [dbo].[GetUserByLogin]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[GetUserByLogin]
	@Login nvarchar(max)
AS
	BEGIN
		SET NOCOUNT ON;
		SELECT    
					dbo.[User].Id,
					dbo.[User].UserLogin,
					dbo.[User].Password, 
					dbo.[User].Name, 
					dbo.[User].LastName, 
					dbo.UserRole.RoleId,
					dbo.Role.RoleName, 
					dbo.Phone.Id AS PhoneId, 
					dbo.Phone.Phone,
					dbo.Email.Id AS EmailId, 
					dbo.Email.Email

		FROM		dbo.UserRole INNER JOIN
					dbo.Role ON dbo.UserRole.RoleId = dbo.Role.Id INNER JOIN
					dbo.Email INNER JOIN
					dbo.[User] ON dbo.Email.UserId = dbo.[User].Id INNER JOIN
					dbo.Phone ON dbo.[User].Id = dbo.Phone.UserId ON dbo.UserRole.UserLoginId = dbo.[User].Id
		Where dbo.[User].UserLogin=@Login;
	END

GO
/****** Object:  StoredProcedure [dbo].[GetUserList]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GetUserList]
	--@Id INT
AS
BEGIN
	SET NOCOUNT ON;

			SELECT    
			    dbo.[User].Id,
				dbo.[User].UserLogin,
				dbo.[User].Password, 
				dbo.[User].Name, 
				dbo.[User].LastName, 
				dbo.UserRole.RoleId,
				dbo.Role.RoleName, 
				dbo.Phone.Id AS PhoneId, 
				dbo.Phone.Phone,
				dbo.Email.Id AS EmailId, 
                dbo.Email.Email
FROM			         dbo.UserRole INNER JOIN
                         dbo.Role ON dbo.UserRole.RoleId = dbo.Role.Id INNER JOIN
                         dbo.Email INNER JOIN
                         dbo.[User] ON dbo.Email.UserId = dbo.[User].Id INNER JOIN
                         dbo.Phone ON dbo.[User].Id = dbo.Phone.UserId ON dbo.UserRole.UserLoginId = dbo.[User].Id

END


GO
/****** Object:  StoredProcedure [dbo].[GetUserListByUserId]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GetUserListByUserId]
	@Id INT
AS
	BEGIN
		SET NOCOUNT ON;
		SELECT    
					dbo.[User].Id,
					dbo.[User].UserLogin,
					dbo.[User].Password, 
					dbo.[User].Name, 
					dbo.[User].LastName, 
					dbo.UserRole.RoleId,
					dbo.Role.RoleName, 
					dbo.Phone.Id AS PhoneId, 
					dbo.Phone.Phone,
					dbo.Email.Id AS EmailId, 
					dbo.Email.Email

		FROM		dbo.UserRole INNER JOIN
					dbo.Role ON dbo.UserRole.RoleId = dbo.Role.Id INNER JOIN
					dbo.Email INNER JOIN
					dbo.[User] ON dbo.Email.UserId = dbo.[User].Id INNER JOIN
					dbo.Phone ON dbo.[User].Id = dbo.Phone.UserId ON dbo.UserRole.UserLoginId = dbo.[User].Id
		Where dbo.[User].Id=@Id;
	END

GO
/****** Object:  StoredProcedure [dbo].[GetUserListWithoutParam]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[GetUserListWithoutParam]
	--@Id INT
AS
BEGIN
	SET NOCOUNT ON;

			SELECT    
			    dbo.[User].Id,
				dbo.[User].UserLogin,
				dbo.[User].Password, 
				dbo.[User].Name, 
				dbo.[User].LastName
				
			FROM  dbo.[User]
END


GO
/****** Object:  StoredProcedure [dbo].[SaveCategory]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaveCategory]
	@Id INT null,
	@Name NVARCHAR(50),
	@ParentId INT
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[vCategory] WHERE Id = @Id),0) = 0
	BEGIN

		INSERT INTO [dbo].[Category]
		       ([Name]
			   ,[ParentId]) 
		VALUES
           (@Name,
			@ParentId )
	END
	ELSE
	BEGIN
			UPDATE [dbo].[Category]
			SET [Name]=@Name,
				[ParentId]=@ParentId 
				

			WHERE Id = @Id
	END
END


GO
/****** Object:  StoredProcedure [dbo].[SaveDefaultOrder]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[SaveDefaultOrder]
	
	@UserId INT,
	@DateOrder date
	
	
AS
BEGIN
	
	BEGIN
		INSERT INTO [dbo].[Order]
		       ([UserId]
			   ,[Address] 
		       ,[StatusId]
		       ,[DateOrder])

		VALUES
           (@UserId,
			' не указан ',
			1,
			@DateOrder)

	END
	--SELECT CAST(SCOPE_IDENTITY() as int)
END


GO
/****** Object:  StoredProcedure [dbo].[SaveNewProductInBasket]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SaveNewProductInBasket]
	@Id INT null,
	@ProductId INT ,
	@OrderId INT null,
	@Count INT null
AS
BEGIN
		INSERT INTO [dbo].[Basket]
		    ( 
			 [ProductId],
			[OrderId] ,
			[Count])
		       
		VALUES
         (
		  @ProductId,
		 @OrderId,
		 @Count)
	END


GO
/****** Object:  StoredProcedure [dbo].[SaveNewProductInBasket4]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SaveNewProductInBasket4]
	@Id INT null,
	@ProductId INT ,
	@OrderId INT null,
	@Count INT null
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[Basket] WHERE ProductId = @ProductId and OrderId=@OrderId ),0) = 0
	BEGIN

		INSERT INTO [dbo].[Basket]
		    ([ProductId],
			[OrderId] ,
			[Count])
		       
		VALUES
         (@ProductId,
		 @OrderId,
		 @Count)
	END
	--ELSE
	--BEGIN
	--		UPDATE [dbo].[Basket]
	--		SET [ProductId]=@ProductId,
	--		[OrderId]=@OrderId,
	--		[Count]=@Count
	--		WHERE ProductId = @ProductId
	--END
END

GO
/****** Object:  StoredProcedure [dbo].[SaveNewProductInBasket5]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[SaveNewProductInBasket5]
	@Id INT null,
	@ProductId INT ,
	@OrderId INT null,
	@Count INT null
AS
BEGIN
		INSERT INTO [dbo].[Basket]
		    ( 
			 [ProductId],
			[OrderId] ,
			[Count])
		       
		VALUES
         (
		  @ProductId,
		 @OrderId,
		 @Count)
	END


GO
/****** Object:  StoredProcedure [dbo].[SaveOrder]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[SaveOrder]
	@Id INT null,
	@UserId INT,
	@Address NVARCHAR(max),
	@StatusId INT,
	@DateOrder DateTime
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[Order] WHERE Id = @Id),0) = 0
	BEGIN
		INSERT INTO [dbo].[Order]
		       ([UserId]
			   ,[Address] 
		       ,[StatusId]
		       ,[DateOrder])
		VALUES
           (@UserId,
			@Address ,
			@StatusId ,
			@DateOrder)
	END
	ELSE
	BEGIN
			UPDATE [dbo].[Order]
			SET [UserId]=@UserId,
				[Address]=@Address, 
				[StatusId]=@StatusId,
				[DateOrder]=@DateOrder

			WHERE Id = @Id
	END
END


GO
/****** Object:  StoredProcedure [dbo].[SaveProduct]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[SaveProduct]
	@Id INT null,
	@Name NVARCHAR(50),
	@CategoryId INT,
	@SeasonsId INT,
	@Picture NVARCHAR(50),
	@Description NVARCHAR(50),
	@Count INT,
	@Price INT
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[vProduct] WHERE Id = @Id),0) = 0
	BEGIN

		INSERT INTO [dbo].[Product]
		       ([Name]
			   ,[CategoryId] 
		       ,[SeasonsId]
		       ,[Picture]
			   ,[Description]
			   ,[Count]
			   ,[Price])

		VALUES
           (@Name,
			@CategoryId ,
			@SeasonsId ,
			@Picture ,
			@Description,
			@Count ,
			@Price )
	END
	ELSE
	BEGIN
			UPDATE [dbo].[Product]
			SET [Name]=@Name,
				[CategoryId]=@CategoryId, 
				[SeasonsId]=@SeasonsId,
				[Picture]=@Picture,
				[Description]=@Description,
				[Count]=@Count,
				[Price]=@Price

			WHERE Id = @Id
	END
END


GO
/****** Object:  StoredProcedure [dbo].[SaveUser]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[SaveUser]
	@Id INT ,
	@UserLogin NVARCHAR(50),
	@Password NVARCHAR(50),
	@UserName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@RoleId INT,
	@Phone NVARCHAR(50),
	@Email NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[User] WHERE Id = @Id),0) = 0
	BEGIN

		INSERT INTO [dbo].[User]
		       (
			   [UserLogin] 
		       ,[Password]
		       ,[Name]
			   ,[LastName])
		VALUES
           (
		   	@UserLogin,
		   	@Password ,
		   	@UserName ,
		   	@LastName)

			 SET @Id = SCOPE_IDENTITY();

		   INSERT INTO [dbo].[UserRole]
		       ([UserLoginId],
			   [RoleId] )
		   VALUES
           (@Id,
		   @RoleId )

		   INSERT INTO [dbo].[Phone]
		       ([UserId],
			   [Phone] )
		   VALUES
           (@Id,
		   @Phone )

		   INSERT INTO [dbo].[Email]
		       ([UserId],
			   [Email] )
		   VALUES
           (@Id,
		    @Email )
			
	END
	ELSE
	BEGIN
			UPDATE [dbo].[User]
			SET [UserLogin]=@UserLogin,
				[Password]=@Password, 
				[Name]=@UserName,
				[LastName]=@LastName

			WHERE Id = @Id

			UPDATE [dbo].[UserRole]
			SET [RoleId]=@RoleId

			Where UserLoginId=@Id

			UPDATE [dbo].[Phone]
			SET [Phone]=@Phone

			Where UserId=@Id

			UPDATE [dbo].[Email]
			SET [Email]=@Email
			Where UserId=@Id
END
END

GO
/****** Object:  StoredProcedure [dbo].[SaveUser228]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[SaveUser228]
	@Id INT ,
	@UserLogin NVARCHAR(50),
	@Password NVARCHAR(50),
	@UserName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@RoleId INT,
	@Phone NVARCHAR(50),
	@Email NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[User] WHERE Id = @Id),0) = 0
	BEGIN

		INSERT INTO [dbo].[User]
		       (
			   [UserLogin] 
		       ,[Password]
		       ,[Name]
			   ,[LastName])
		VALUES
           (
		   	@UserLogin,
		   	@Password ,
		   	@UserName ,
		   	@LastName)

			 SET @Id = SCOPE_IDENTITY();

		   INSERT INTO [dbo].[UserRole]
		       ([UserLoginId],
			   [RoleId] )
		   VALUES
           (@Id,
		   @RoleId )

		   INSERT INTO [dbo].[Phone]
		       ([UserId],
			   [Phone] )
		   VALUES
           (@Id,
		   @Phone )

		   INSERT INTO [dbo].[Email]
		       ([UserId],
			   [Email] )
		   VALUES
           (@Id,
		    @Email )
			 INSERT INTO [dbo].[UserRole]
		       ([RoleId],
			   [UserLoginId] )
		   VALUES
           (
		   @RoleId,
		    @Id )
	END
	ELSE
	BEGIN
			UPDATE [dbo].[User]
			SET [UserLogin]=@UserLogin,
				[Password]=@Password, 
				[Name]=@UserName,
				[LastName]=@LastName

			WHERE Id = @Id

			UPDATE [dbo].[UserRole]
			SET [RoleId]=@RoleId

			Where UserLoginId=@Id

			UPDATE [dbo].[Phone]
			SET [Phone]=@Phone

			Where UserId=@Id

			UPDATE [dbo].[Email]
			SET [Email]=@Email
			Where UserId=@Id
END
END

GO
/****** Object:  StoredProcedure [dbo].[SaveUser229]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[SaveUser229]
	@Id INT ,
	@UserLogin NVARCHAR(50),
	@Password NVARCHAR(50),
	@UserName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@RoleId INT,
	@Phone NVARCHAR(50),
	@Email NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[User] WHERE Id = @Id),0) = 0
	BEGIN

		INSERT INTO [dbo].[User]
		       (
			   [UserLogin] 
		       ,[Password]
		       ,[Name]
			   ,[LastName])
		VALUES
           (
		   	@UserLogin,
		   	@Password ,
		   	@UserName ,
		   	@LastName)

			 SET @Id = SCOPE_IDENTITY();

		   INSERT INTO [dbo].[UserRole]
		       ([UserLoginId],
			   [RoleId] )
		   VALUES
           (@Id,
		   @RoleId )

		   INSERT INTO [dbo].[Phone]
		       ([UserId],
			   [Phone] )
		   VALUES
           (@Id,
		   @Phone )

		   INSERT INTO [dbo].[Email]
		       ([UserId],
			   [Email] )
		   VALUES
           (@Id,
		    @Email )
			
	END
	ELSE
	BEGIN
			UPDATE [dbo].[User]
			SET [UserLogin]=@UserLogin,
				[Password]=@Password, 
				[Name]=@UserName,
				[LastName]=@LastName

			WHERE Id = @Id

			UPDATE [dbo].[UserRole]
			SET [RoleId]=@RoleId

			Where UserLoginId=@Id

			UPDATE [dbo].[Phone]
			SET [Phone]=@Phone

			Where UserId=@Id

			UPDATE [dbo].[Email]
			SET [Email]=@Email
			Where UserId=@Id
END
END

GO
/****** Object:  StoredProcedure [dbo].[SaveUserEmail]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaveUserEmail]
	@Id INT null,
	@UserId INT,
	@Email NVARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[Email] WHERE UserId = @UserId),0) = 0
	BEGIN

		INSERT INTO [dbo].[Email]
		       (
			   [UserId] 
		       ,[Email])
		VALUES
           (
		   	@UserId,
		   	@Email )

		   
	END
	ELSE
	BEGIN
			UPDATE [dbo].[Email]
			SET [UserId]=@UserId,
				[Email]=@Email

			WHERE UserId = @UserId
END
END

GO
/****** Object:  StoredProcedure [dbo].[SaveUserPhone]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[SaveUserPhone]
	@Id INT null,
	@UserId INT,
	@Phone NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[Phone] WHERE UserId = @UserId),0) = 0
	BEGIN

		INSERT INTO [dbo].[Phone]
		       (
			   [UserId] 
		       ,[Phone])
		VALUES
           (
		   	@UserId,
		   	@Phone )

		   
	END
	ELSE
	BEGIN
			UPDATE [dbo].[Phone]
			SET [UserId]=@UserId,
				[Phone]=@Phone

			WHERE Id = @Id
END
END

GO
/****** Object:  StoredProcedure [dbo].[SaveUserRole]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[SaveUserRole]
	@Id INT ,
	@RoleId INT
	
AS
BEGIN
	SET NOCOUNT ON;

	IF ISNULL((SELECT COUNT(1) FROM [dbo].[UserRole] WHERE UserLoginId = @Id),0) = 0
	BEGIN

		INSERT INTO [dbo].[UserRole]
		       (
			   [UserLoginId] 
		       ,[RoleId]
		       )
		VALUES
           (
		   	@Id,
		   	@RoleId)
		   
	END
	ELSE
	BEGIN
			UPDATE [dbo].[UserRole]
			SET [UserLoginId]=@Id,
				[RoleId]=@RoleId

			WHERE UserLoginId = @Id

	
END
END

GO
/****** Object:  StoredProcedure [dbo].[SearchProducts]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SearchProducts]
	@Name NVARCHAR(max) = '',
	@CategoryId INT,
	@PriceMin INT,
	@PriceMax INT
AS
	SET NOCOUNT ON;
	Select * from dbo.vProduct
	
   WHERE [Name] like @Name + '%'
   and CategoryId=iif (@CategoryId=0,CategoryId,@CategoryId)
   and Price <@PriceMax 
   and [Price]>@PriceMin

GO
/****** Object:  StoredProcedure [dbo].[UpdateOrder]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[UpdateOrder]
	@Id INT null,
	@Address NVARCHAR(max) null,
	@StatusId INT,
	@DateOrder DateTime null
AS
BEGIN
	
	BEGIN
			UPDATE [dbo].[Order]
			SET 
				[Address]=@Address, 
				[StatusId]=@StatusId,
				[DateOrder]=@DateOrder

			WHERE Id = @Id
	END
END


GO
/****** Object:  StoredProcedure [dbo].[UpdateProductCountInBasket]    Script Date: 6/22/2018 11:33:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateProductCountInBasket]
	@Id INT null,
	@ProductId INT ,
	@OrderId INT null,
	@Count INT null
AS
BEGIN
	SET NOCOUNT ON;

			UPDATE [dbo].[Basket]
			SET [ProductId]=@ProductId,
			[OrderId]=@OrderId,
			[Count]=@Count
			WHERE ProductId = @ProductId and OrderId=@OrderId
	END


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
         Begin Table = "Basket"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Product"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 4
         End
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vBasket'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vBasket'
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
         Begin Table = "Category"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vCategory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vCategory'
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
         Begin Table = "Email"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vEmail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vEmail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[52] 4[20] 2[11] 3) )"
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
         Begin Table = "Order"
            Begin Extent = 
               Top = 54
               Left = 195
               Bottom = 184
               Right = 365
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "StatusOrder"
            Begin Extent = 
               Top = 164
               Left = 503
               Bottom = 267
               Right = 673
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "User"
            Begin Extent = 
               Top = 92
               Left = 698
               Bottom = 205
               Right = 868
            End
            DisplayFlags = 280
            TopColumn = 0
         End
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vOrder'
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
         Begin Table = "Phone"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vPhone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vPhone'
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
         Begin Table = "Role"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vRole'
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
         Begin Table = "Season"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vSeason'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vSeason'
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
         Begin Table = "StatusOrder"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vStatusOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vStatusOrder'
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
         Begin Table = "Role"
            Begin Extent = 
               Top = 203
               Left = 264
               Bottom = 299
               Right = 434
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UserRole"
            Begin Extent = 
               Top = 198
               Left = 697
               Bottom = 294
               Right = 867
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "User"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Email"
            Begin Extent = 
               Top = 21
               Left = 13
               Bottom = 134
               Right = 183
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Phone"
            Begin Extent = 
               Top = 198
               Left = 22
               Bottom = 311
               Right = 192
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vUser3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'= 900
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vUser3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vUser3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[39] 4[27] 2[16] 3) )"
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
         Left = -313
      End
      Begin Tables = 
         Begin Table = "Email"
            Begin Extent = 
               Top = 57
               Left = 501
               Bottom = 237
               Right = 692
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "User"
            Begin Extent = 
               Top = 6
               Left = 1131
               Bottom = 136
               Right = 1301
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Phone"
            Begin Extent = 
               Top = 220
               Left = 496
               Bottom = 334
               Right = 688
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VUserContacts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VUserContacts'
GO
