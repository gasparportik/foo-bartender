/****** Object:  Role [AccountantRole]    Script Date: 03/24/2011 21:09:12 ******/
CREATE ROLE [AccountantRole]
GO
/****** Object:  Role [AdminRole]    Script Date: 03/24/2011 21:09:12 ******/
CREATE ROLE [AdminRole]
GO
/****** Object:  Role [DescriberRole]    Script Date: 03/24/2011 21:09:12 ******/
CREATE ROLE [DescriberRole]
GO
/****** Object:  Role [WaiterRole]    Script Date: 03/24/2011 21:09:12 ******/
CREATE ROLE [WaiterRole]
GO
/****** Object:  User [jsmith]    Script Date: 03/24/2011 21:09:12 ******/
CREATE USER [jsmith] FOR LOGIN [jsmith] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [DbDescriber]    Script Date: 03/24/2011 21:09:12 ******/
CREATE USER [DbDescriber] FOR LOGIN [DbDescriber] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Recipe]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recipe](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [text] NULL,
	[Total] [float] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_Recipe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Country]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [char](2) NOT NULL,
	[Name] [varchar](80) NOT NULL,
	[Printable] [varchar](80) NOT NULL,
	[Iso3] [char](3) NOT NULL,
	[NumberCode] [smallint] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Company]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[NrOrdReg] [char](12) NOT NULL,
	[CIF] [char](11) NOT NULL,
	[CountryId] [char](2) NOT NULL,
	[County] [varchar](20) NOT NULL,
	[PostalCode] [int] NOT NULL,
	[City] [varchar](30) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[BankId] [int] NOT NULL,
	[IBAN] [char](24) NOT NULL,
	[Telephone] [varchar](50) NOT NULL,
	[Fax] [varchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Website] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RecipeItem]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeItem](
	[Id] [int] NOT NULL,
	[RecipeId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
 CONSTRAINT [PK_RecipeItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Invoice](
	[Id] [int] NOT NULL,
	[SectionId] [int] NOT NULL,
	[SeriesNumber] [varchar](30) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[PayDate] [datetime] NOT NULL,
	[DeliveryDate] [datetime] NOT NULL,
	[PaymentExpiration] [datetime] NOT NULL,
	[SumNet] [float] NOT NULL,
	[SumVat] [float] NOT NULL,
	[Delivered] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InvoiceItem]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceItem](
	[Id] [int] NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UnitId] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[Value] [float] NOT NULL,
	[VAT] [float] NOT NULL,
 CONSTRAINT [PK_InvoiceItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Section]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Section](
	[Id] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Section] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Saloon]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Saloon](
	[Id] [int] NOT NULL,
	[SectionId] [int] NOT NULL,
	[Capacity] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Saloon] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bank](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Website] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Reception]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reception](
	[Id] [int] NOT NULL,
	[SectionId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Total] [float] NOT NULL,
	[EnteredStock] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
 CONSTRAINT [PK_Reception] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceptionItem]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceptionItem](
	[Id] [int] NOT NULL,
	[ReceptionId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_ReceptionItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaloonTable]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaloonTable](
	[Id] [int] NOT NULL,
	[SaloonId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Capacity] [int] NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[Shape] [int] NOT NULL,
 CONSTRAINT [PK_SaloonTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[RawProducts]    Script Date: 03/24/2011 21:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RawProducts]
AS
SELECT     Id, CategoryId, Name, Price, UnitId, RecipeId
FROM         dbo.Product
WHERE     (RecipeId IS NULL)
GO
/****** Object:  View [dbo].[RecipeProducts]    Script Date: 03/24/2011 21:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RecipeProducts]
AS
SELECT     Id, CategoryId, Name, Price, UnitId
FROM         dbo.Product
WHERE     (RecipeId IS NULL)
GO
/****** Object:  Table [dbo].[CashClosing]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashClosing](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SaloonId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Total] [float] NOT NULL,
 CONSTRAINT [PK_CashClosing] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sale](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SaloonTableId] [int] NOT NULL,
	[Status] [char](3) NOT NULL,
	[Date] [datetime] NOT NULL,
	[AccountId] [int] NOT NULL,
 CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaleItem]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SaleId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[UnitId] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Delivered] [bit] NOT NULL,
 CONSTRAINT [PK_SaleItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[AccessLevel] [tinyint] NOT NULL,
	[Suspended] [bit] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TransferItem]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransferItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransferId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_TransferItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transfer]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transfer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SectionFrom] [int] NOT NULL,
	[SectionTo] [int] NOT NULL,
	[Transferred] [bit] NOT NULL,
	[Date] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
 CONSTRAINT [PK_Transfer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Stock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[SectionId] [int] NOT NULL,
	[Action] [varchar](50) NOT NULL,
	[Quantity] [float] NOT NULL,
	[OrigQuantity] [float] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[LoadUnitsForProduct]    Script Date: 03/24/2011 21:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		Portik Gaspar
-- Create date: 2010/05/18
-- Description:	selects all the units for a
--		specified Product
-- =============================================
CREATE PROCEDURE [dbo].[LoadUnitsForProduct]
	@ProductId int
AS
BEGIN
	SET NOCOUNT OFF;
	SELECT U.Id, U.Name, 1 AS Ratio FROM Product P INNER JOIN Unit U ON U.Id = P.UnitId WHERE P.Id = @ProductId 
	UNION
	SELECT U.Id, U.Name, U.Ratio FROM Unit U WHERE U.ProductId = @ProductId;
END
GO
/****** Object:  Table [dbo].[ProductionItem]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductionItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductionId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_ProductionItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Production]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Production](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Total] [float] NOT NULL,
 CONSTRAINT [PK_Production] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Unit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ProductId] [int] NULL,
	[Ratio] [float] NOT NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 03/24/2011 21:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[UnitId] [int] NOT NULL,
	[RecipeId] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[DeliverReception]    Script Date: 03/24/2011 21:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		Portik Gaspar
-- Create date: 2010/05/18
-- Description:	Inserts the products from a
--		Reception into the stock
-- =============================================
CREATE PROCEDURE [dbo].[DeliverReception] 
	@ReceptionId int 
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ReceptionState int;
	DECLARE @SectionId int;
	DECLARE @ReceptionTotal float;
	SELECT @ReceptionState = EnteredStock, @SectionId = SectionId FROM Reception WHERE Id = @ReceptionId;
	IF (@ReceptionState = 0) BEGIN
		BEGIN TRANSACTION;
		SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
		UPDATE ReceptionItem SET Price = P.Price * Quantity FROM Product P WHERE ReceptionId = @ReceptionId;
		SET @ReceptionTotal = (SELECT SUM(Price) FROM ReceptionItem WHERE ReceptionId = @ReceptionId);
		INSERT Stock SELECT R.Id AS ReferenceId, RI.ProductId, R.SectionId AS SectionId, 'REC' AS Action, RI.Quantity, RI.Quantity AS OrigQuant, RI.Price
			FROM Reception R INNER JOIN ReceptionItem RI ON RI.ReceptionId = R.Id WHERE R.Id = @ReceptionId
		UPDATE Reception SET EnteredStock = 1, Total = @ReceptionTotal WHERE Id = @ReceptionId;
		COMMIT;
	END ELSE RAISERROR('The specified reception does not exist or it has already been processed.',15,1);
END
GO
/****** Object:  StoredProcedure [dbo].[LoadTablesForSaloon]    Script Date: 03/24/2011 21:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		Portik Gaspar
-- Create date: 2010/05/18
-- Description:	Selects the tables and their 
--		states for a specified Saloon
-- =============================================
CREATE PROCEDURE [dbo].[LoadTablesForSaloon]
	@SaloonId int
AS
BEGIN
	SET NOCOUNT OFF;
	SELECT ST.Id, ST.Name, CASE WHEN S.Status IS NULL THEN 'FREE' ELSE S.Status END AS Status,
			A.Name AS Waiter, A.Id AS WaiterId, S.Id AS SaleId
		FROM SaloonTable ST 
		LEFT JOIN Sale S ON S.SaloonTableId = ST.Id AND S.Status <> 'DON'
		LEFT JOIN Account A ON A.Id = S.AccountId
		WHERE ST.SaloonId = @SaloonId;
END
GO
/****** Object:  StoredProcedure [dbo].[GenerateCashClosing]    Script Date: 03/24/2011 21:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		Portik Gaspar
-- Create date: 2010/05/18
-- Description:	Generates the CashClosing for a
--		Saloon, which is the sum of all sales in
--		in that Saloon
-- =============================================
CREATE PROCEDURE [dbo].[GenerateCashClosing]
	@SaloonId int
AS
BEGIN
	SET NOCOUNT ON;
	IF (EXISTS(SELECT * FROM CashClosing WHERE DATEDIFF(dd,Date,GETDATE()) = 1 AND SaloonId = @SaloonId))
		RETURN -1;
	ELSE BEGIN
		DECLARE @Total int;
		SELECT @Total = SUM(SI.Price * SI.Quantity)
			FROM Sale S 
			INNER JOIN SaleItem SI ON SI.SaleId = S.Id
			INNER JOIN SaloonTable ST ON ST.Id = S.SaloonTableId
			WHERE DATEDIFF(day,S.Date,GETDATE()) = 1 AND ST.SaloonId = @SaloonId;
		IF @Total IS NOT NULL
		INSERT CashClosing VALUES(@SaloonId,GETDATE(), @Total);
	END
END
GO
/****** Object:  StoredProcedure [dbo].[ModifyTable]    Script Date: 03/24/2011 21:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		Portik Gaspar
-- Create date: 2010/05/18
-- Description:	Modifies the state of a table
--		(updates or creates a sale) according to
--		the specified @Action:
--		1 - creates order on table
--		2 - occupies table for later use
--		3 - releases a table
-- =============================================
CREATE PROCEDURE [dbo].[ModifyTable] 
	@Action int = 1, 
	@TableId int,
	@AccountId int
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @SaleId int;
	IF @Action = 1
	BEGIN
		-- CREATE ORDER
		SELECT @SaleId = Id FROM Sale WHERE SaloonTableId = @TableId AND 
			AccountId = @AccountId AND Status = 'OCC';
		IF (@SaleId > 0)
		BEGIN
			UPDATE Sale SET Status = 'WAI' WHERE Id = @SaleId;
			RETURN 0;
		END ELSE IF (NOT EXISTS(SELECT * FROM Sale WHERE Status IN ('WAI', 'OCC') AND SaloonTableId = @TableId))
		BEGIN
			INSERT INTO Sale VALUES (@TableId, 'WAI', GETDATE(), @AccountId);
		END ELSE BEGIN
			RETURN -1;
		END 
	SELECT 1;
	END ELSE IF @Action = 2
	BEGIN
		--OCCUPY
		IF (NOT EXISTS(SELECT * FROM Sale WHERE Status IN ('WAI', 'OCC') AND SaloonTableId = @TableId AND AccountId = @AccountId))
		BEGIN
			INSERT INTO Sale VALUES (@TableId, 'OCC', GETDATE(), @AccountId);
		END ELSE BEGIN
			RETURN -2;
		END 
	END ELSE IF @Action = 3
	BEGIN
		--FREE
		SELECT @SaleId = Id FROM Sale WHERE Status IN ('WAI', 'OCC') AND AccountId = @AccountId AND SaloonTableId = @TableId;
		IF (@SaleId > 0)
		BEGIN
			UPDATE Sale SET Status = 'DON' WHERE Id = @SaleId;
		END ELSE BEGIN
			RETURN -1 * @TableId;
		END 
	END ELSE
		RETURN -4;
END
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 03/24/2011 21:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		Portik Gaspar
-- Create date: 2010/06/03
-- Description:	Creates a new Account, add a
--		db LOGIN and a db USER to it.
-- =============================================
CREATE PROCEDURE [dbo].[CreateUser] 
	@UserName VARCHAR(20),
	@Password VARCHAR(20),
	@RealName VARCHAR(30),
	@Role INT	
AS
BEGIN
	DECLARE @RoleName VARCHAR(30);
	DECLARE @ReturnCode INT;
	SET NOCOUNT ON;
	
	BEGIN TRANSACTION
	EXEC ('CREATE LOGIN ' + @UserName + ' WITH PASSWORD = ''' +  @Password + '''');
	IF @@ERROR != 0 BEGIN
		ROLLBACK;
		RETURN 1;
	END

	EXEC ('CREATE USER ' + @UserName + ' FOR LOGIN ' +  @UserName);
	IF @@ERROR != 0 BEGIN
		ROLLBACK;
		RETURN 2;
	END

	INSERT INTO Account VALUES(@UserName, @RealName, @Role, 0);
	IF @@ERROR != 0 BEGIN
		ROLLBACK;
		RETURN 3;
	END

	COMMIT;
	IF @Role = 1
		SET @RoleName = 'AdminRole';
	IF @Role = 2
		SET @RoleName = 'AccountantRole'
	IF @Role = 3
		SET @RoleName = 'WaiterRole'
	IF @Role > 3 OR @Role < 1
		RETURN 5;
	-- cannot be executed in a transaction!
	-- thus the error cannot be recovered :(
	EXEC @ReturnCode = sp_addrolemember @RoleName, @UserName
	IF @@ERROR != 0 OR @ReturnCode != 0 BEGIN
		RETURN 4;
	END
	RETURN 0;
END
GO
/****** Object:  StoredProcedure [dbo].[ChangeUserSuspension]    Script Date: 03/24/2011 21:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChangeUserSuspension]
	@AccountId int
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Suspended bit;
	DECLARE @Username varchar(30); 
	DECLARE @State varchar(10);
	SELECT @Suspended = Suspended, @Username = Username From Account WHERE Id = @AccountId;
	BEGIN TRANSACTION
	UPDATE Account SET Suspended = 1-@Suspended WHERE Id = @AccountId;
	IF @@ERROR != 0 BEGIN 
		ROLLBACK;
		RETURN -1;
	END
	IF @Suspended = 1 
		SET @State = 'ENABLE';
	ELSE
		SET @State = 'DISABLE';
	EXEC('ALTER LOGIN ' + @Username + ' ' + @State);
	IF @@ERROR != 0 BEGIN
		ROLLBACK;
		RETURN -2;
	END
	COMMIT
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 03/24/2011 21:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		Portik Gaspar
-- Create date: 2010/06/04
-- Description:	Deletes an Account, including
--		the DB user and login
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUser]
	@Id int
AS
BEGIN
	DECLARE @UserName varchar(30);
	DECLARE @Role int;
	DECLARE @RoleName varchar(30);
	DECLARE @Statement nvarchar(30);
	DECLARE @ReturnCode int;
	SET NOCOUNT ON;
	BEGIN TRANSACTION;
	SELECT @Role = AccessLevel, @UserName = Username  FROM Account WHERE Id = @Id;
	IF @UserName IS NULL BEGIN
		ROLLBACK;
		RETURN 1;
	END
	DELETE FROM Account WHERE Id = @Id;
	IF @@ERROR != 0 BEGIN
		ROLLBACK;
		RETURN 2;
	END

	IF @Role = 1
		SET @RoleName = 'AdminRole';
	IF @Role = 2
		SET @RoleName = 'AccountantRole'
	IF @Role = 3
		SET @RoleName = 'WaiterRole'
	IF @Role > 3 OR @Role < 1 BEGIN
		ROLLBACK;
		RETURN 6;
	END

	EXEC @ReturnCode = sp_droprolemember @RoleName, @UserName
	IF @@ERROR != 0 OR @ReturnCode = 1 BEGIN
		ROLLBACK;
		RETURN 3;
	END

	EXEC('DROP USER ' + @UserName);
	IF @@ERROR != 0 BEGIN
		ROLLBACK;
		RETURN 4;
	END
	

	EXEC('DROP LOGIN ' + @UserName);
	IF @@ERROR != 0 BEGIN
		ROLLBACK;
		RETURN 5;
	END

	COMMIT;
	RETURN 0;
END
GO
/****** Object:  StoredProcedure [dbo].[TransferProducts]    Script Date: 03/24/2011 21:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		Portik Gaspar
-- Create date: 2010/05/18
-- Description:	transfers a product between
--		two sections
-- =============================================
CREATE PROCEDURE [dbo].[TransferProducts] 
	@TransferId int
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE myCur CURSOR FOR SELECT ProductId, Quantity FROM TransferItem WHERE TransferId = @TransferId;
	DECLARE @Transferred bit;
	DECLARE @SectionFrom int;
	DECLARE @SectionTo int;
	DECLARE @Result int;
	SELECT @Transferred = Transferred,@SectionFrom = SectionFrom, @SectionTo = SectionTo FROM Transfer WHERE Id = @TransferId;
	IF (@Transferred = 0) BEGIN
		DECLARE @ItemId int;
		DECLARE @Quantity float;
		BEGIN TRANSACTION;
		SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
		OPEN myCur;
		FETCH NEXT FROM myCur INTO @ItemId, @Quantity;
		WHILE (@@FETCH_STATUS <> -1)
		BEGIN
			EXEC @Result = DeductStockForProduct
				@ProductId = @ItemId,
				@SectionId = @SectionFrom,
				@Quantity = @Quantity;
			IF (@Result = 0)
			BEGIN
				INSERT INTO Stock VALUES (@TransferId, @ItemId, @SectionTo, 'TRA', @Quantity, @Quantity,0);
				IF (@@ERROR != 0) BEGIN
					CLOSE myCur;
					DEALLOCATE myCur;
					ROLLBACK;
					RETURN 4;
				END
			END 
			ELSE
			BEGIN
				CLOSE myCur;
				DEALLOCATE myCur;
				ROLLBACK;
				RETURN -1 * @ItemId;
			END
			FETCH NEXT FROM myCur INTO @ItemId, @Quantity;
		END
		CLOSE myCur;
		DEALLOCATE myCur;
		UPDATE Transfer SET Transferred = 1 WHERE Id = @TransferId;
		IF (@@ERROR != 0) BEGIN
			ROLLBACK;
			RETURN 2;
		END
		COMMIT;
	END ELSE BEGIN
		RETURN 1;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[DeductStockForProduct]    Script Date: 03/24/2011 21:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		Portik Gaspar
-- Create date: 2010/05/18
-- Description:	Deducts the specified @Quantity
--		from the specified @Section of the Stock
--		or raises an error if there aren't 
--		enough products on stock
--		!ONLY USE THIS FROM INSIDE TRANSACTIONS!
-- =============================================
CREATE PROCEDURE [dbo].[DeductStockForProduct]
	@ProductId int,
	@SectionId int,
	@Quantity float
AS
BEGIN
	DECLARE dCur CURSOR FOR SELECT Id, Quantity FROM Stock 
		WHERE SectionId = @SectionId AND ProductId = @ProductId AND Quantity > 0;
	DECLARE @Remaining float;
	DECLARE @CurrentId int;
	DECLARE @CurrentQ float;
	
	SET @Remaining = @Quantity;	
	OPEN dCur;
	FETCH NEXT FROM dCur INTO @CurrentId, @CurrentQ;
	WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		IF @Remaining > @CurrentQ
		UPDATE Stock SET Quantity = 0 WHERE Id = @CurrentId;
		ELSE
		UPDATE Stock SET Quantity = Quantity - @Remaining WHERE Id = @CurrentId;
		SET @Remaining = @Remaining - @CurrentQ;
		FETCH NEXT FROM dCur INTO @CurrentId, @CurrentQ;
	END
	CLOSE dCur;
	DEALLOCATE dCur;
	IF (@Remaining > 0)
		RETURN (@Remaining * 1000);
	RETURN 0;
END
GO
/****** Object:  StoredProcedure [dbo].[DeliverInvoice]    Script Date: 03/24/2011 21:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Author:		Portik Gaspar
-- Create date: 2010/05/18
-- Description:	Deducts the product quantities
--		needed for an invoice. Raises error in
--		there aren't enough products in stock
--		!DEPENDS ON [DeductStockForProduct]!
-- =============================================
CREATE PROCEDURE [dbo].[DeliverInvoice] 
	@InvoiceId int
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Delivered bit;
	DECLARE @SectionId int;
	SELECT @Delivered = Delivered, @SectionId = SectionId FROM Invoice WHERE Id = @InvoiceId;
	IF (@Delivered = 0) BEGIN
		DECLARE myCur CURSOR FOR SELECT ProductId, Quantity FROM InvoiceItem WHERE InvoiceId = @InvoiceId;
		DECLARE @Result int;
		DECLARE @ItemId int;
		DECLARE @Quantity float;
		BEGIN TRANSACTION;
		SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
		OPEN myCur;
		FETCH NEXT FROM myCur INTO @ItemId, @Quantity;
		WHILE (@@FETCH_STATUS <> -1)
		BEGIN
			EXEC @Result = [DeductStockForProduct]
					@ProductId = @ItemId,
					@SectionId = @SectionId,
					@Quantity = @Quantity;
			IF @Result > 0 BEGIN 
				CLOSE myCur;
				DEALLOCATE myCur;
				ROLLBACK;
				RAISERROR('The tiny net @ProductId',15,1);
				RETURN;
			END
			FETCH NEXT FROM myCur INTO @ItemId, @Quantity;
		END
		UPDATE Invoice SET Delivered = 1 WHERE Id = @InvoiceId;
		CLOSE myCur;
		DEALLOCATE myCur;
		COMMIT;
	END ELSE RAISERROR(100002,15,10);
END
GO
