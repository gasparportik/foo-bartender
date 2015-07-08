CREATE PROCEDURE [dbo].[ChangeUserSuspension]
	@AccountId int
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Suspended bit;
	DECLARE @Username varchar(30); 
	DECLARE @State varchar(10);
	SELECT @Suspended = Suspended, @Username = Username From Account WHERE Id = @AccountId;
	BEGIN TRANSACTION
	UPDATE Account SET Suspended = 1-@Suspended WHERE Id = @AccountId;
	IF @@ERROR != 0 BEGIN 
		ROLLBACK;
		RETURN -1;
	END
	IF @Suspended = 1 
		SET @State = 'ENABLE';
	ELSE
		SET @State = 'DISABLE';
	EXEC('ALTER LOGIN ' + @Username + ' ' + @State);
	IF @@ERROR != 0 BEGIN
		ROLLBACK;
		RETURN -2;
	END
	COMMIT
END