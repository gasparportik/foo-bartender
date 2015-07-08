CREATE PROCEDURE [dbo].[DeleteUser]
	@Id int
AS
BEGIN
	DECLARE @UserName varchar(30);
	DECLARE @Role int;
	DECLARE @RoleName varchar(30);
	DECLARE @Statement nvarchar(30);
	DECLARE @ReturnCode int;
	SET NOCOUNT ON;
	BEGIN TRANSACTION;
	SELECT @Role = AccessLevel, @UserName = Username  FROM Account WHERE Id = @Id;
	IF @UserName IS NULL BEGIN
		ROLLBACK;
		RETURN 1;
	END
	DELETE FROM Account WHERE Id = @Id;
	IF @@ERROR != 0 BEGIN
		ROLLBACK;
		RETURN 2;
	END

	IF @Role = 1
		SET @RoleName = 'AdminRole';
	IF @Role = 2
		SET @RoleName = 'AccountantRole'
	IF @Role = 3
		SET @RoleName = 'WaiterRole'
	IF @Role > 3 OR @Role < 1 BEGIN
		ROLLBACK;
		RETURN 6;
	END

	EXEC @ReturnCode = sp_droprolemember @RoleName, @UserName
	IF @@ERROR != 0 OR @ReturnCode = 1 BEGIN
		ROLLBACK;
		RETURN 3;
	END

	EXEC('DROP USER ' + @UserName);
	IF @@ERROR != 0 BEGIN
		ROLLBACK;
		RETURN 4;
	END
	

	EXEC('DROP LOGIN ' + @UserName);
	IF @@ERROR != 0 BEGIN
		ROLLBACK;
		RETURN 5;
	END

	COMMIT;
	RETURN 0;
END