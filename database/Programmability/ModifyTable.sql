CREATE PROCEDURE [dbo].[ModifyTable] 
	@Action int = 1, 
	@TableId int,
	@AccountId int
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @SaleId int;
	IF @Action = 1
	BEGIN
		-- CREATE ORDER
		SELECT @SaleId = Id FROM Sale WHERE SaloonTableId = @TableId AND 
			AccountId = @AccountId AND Status = 'OCC';
		IF (@SaleId > 0)
		BEGIN
			UPDATE Sale SET Status = 'WAI' WHERE Id = @SaleId;
			RETURN 0;
		END ELSE IF (NOT EXISTS(SELECT * FROM Sale WHERE Status IN ('WAI', 'OCC') AND SaloonTableId = @TableId))
		BEGIN
			INSERT INTO Sale VALUES (@TableId, 'WAI', GETDATE(), @AccountId);
		END ELSE BEGIN
			RETURN -1;
		END 
	SELECT 1;
	END ELSE IF @Action = 2
	BEGIN
		--OCCUPY
		IF (NOT EXISTS(SELECT * FROM Sale WHERE Status IN ('WAI', 'OCC') AND SaloonTableId = @TableId AND AccountId = @AccountId))
		BEGIN
			INSERT INTO Sale VALUES (@TableId, 'OCC', GETDATE(), @AccountId);
		END ELSE BEGIN
			RETURN -2;
		END 
	END ELSE IF @Action = 3
	BEGIN
		--FREE
		SELECT @SaleId = Id FROM Sale WHERE Status IN ('WAI', 'OCC') AND AccountId = @AccountId AND SaloonTableId = @TableId;
		IF (@SaleId > 0)
		BEGIN
			UPDATE Sale SET Status = 'DON' WHERE Id = @SaleId;
		END ELSE BEGIN
			RETURN -1 * @TableId;
		END 
	END ELSE
		RETURN -4;
END