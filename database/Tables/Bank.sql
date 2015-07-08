CREATE TABLE [dbo].[Bank](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[Name] [varchar](50) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Website] [varchar](50) NOT NULL
)