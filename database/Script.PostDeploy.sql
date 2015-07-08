/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

 INSERT INTO [dbo].[Country] VALUES 
     ('RO','Romania','Romania','ROM',642), 
     ('HU','Hungary','Ungaria','HUN',348);

 GO


CREATE ROLE [AccountantRole]
CREATE ROLE [AdminRole]
CREATE ROLE [DescriberRole]
CREATE ROLE [WaiterRole]

IF NOT EXISTS (SELECT loginname FROM master.dbo.syslogins WHERE name = 'DbDescriber')
BEGIN
	CREATE LOGIN [DbDescriber] WITH PASSWORD = 'dbdesc'
END

CREATE USER [DbDescriber] FOR LOGIN [DbDescriber] WITH DEFAULT_SCHEMA=[dbo]

IF NOT EXISTS (SELECT loginname FROM master.dbo.syslogins WHERE name = 'jsmith')
BEGIN
	CREATE LOGIN [jsmith] WITH PASSWORD = 'kovacs'
END


CREATE USER [jsmith] FOR LOGIN [jsmith] WITH DEFAULT_SCHEMA=[dbo]

INSERT INTO [restdb].[dbo].[Account] VALUES('jsmith','Kovi',1,0);

GO
