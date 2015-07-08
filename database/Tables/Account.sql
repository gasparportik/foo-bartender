CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[Username] [varchar](20) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[AccessLevel] [tinyint] NOT NULL,
	[Suspended] [bit] NOT NULL
)