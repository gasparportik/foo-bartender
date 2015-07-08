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