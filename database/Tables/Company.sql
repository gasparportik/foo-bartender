 CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
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
	[Website] [varchar](100) NOT NULL
)