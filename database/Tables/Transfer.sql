CREATE TABLE [dbo].[Transfer](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[SectionFrom] [int] NOT NULL,
	[SectionTo] [int] NOT NULL,
	[Transferred] [bit] NOT NULL,
	[Date] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL
)