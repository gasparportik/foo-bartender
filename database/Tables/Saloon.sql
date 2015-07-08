CREATE TABLE [dbo].[Saloon](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[SectionId] [int] NOT NULL,
	[Capacity] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL
)