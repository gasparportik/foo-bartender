CREATE TABLE [dbo].[Invoice](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
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
	[CreatedBy] [int] NOT NULL
)