CREATE TABLE [dbo].[Reception](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[SectionId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Total] [float] NOT NULL,
	[EnteredStock] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL
)