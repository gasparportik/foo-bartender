CREATE TABLE [dbo].[Recipe](
	[Id] int IDENTITY NOT NULL PRIMARY KEY,
	[Name] varchar(50) NULL,
	[Description] text NULL,
	[Total] float NULL,
	[CreatedBy] int NULL,
)