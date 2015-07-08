CREATE PROCEDURE [dbo].[TransferProducts] 
	@TransferId int
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE myCur CURSOR FOR SELECT ProductId, Quantity FROM TransferItem WHERE TransferId = @TransferId;
	DECLARE @Transferred bit;
	DECLARE @SectionFrom int;
	DECLARE @SectionTo int;
	DECLARE @Result int;
	SELECT @Transferred = Transferred,@SectionFrom = SectionFrom, @SectionTo = SectionTo FROM Transfer WHERE Id = @TransferId;
	IF (@Transferred = 0) BEGIN
		DECLARE @ItemId int;
		DECLARE @Quantity float;
		BEGIN TRANSACTION;
		SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
		OPEN myCur;
		FETCH NEXT FROM myCur INTO @ItemId, @Quantity;
		WHILE (@@FETCH_STATUS <> -1)
		BEGIN
			EXEC @Result = DeductStockForProduct
				@ProductId = @ItemId,
				@SectionId = @SectionFrom,
				@Quantity = @Quantity;
			IF (@Result = 0)
			BEGIN
				INSERT INTO Stock VALUES (@TransferId, @ItemId, @SectionTo, 'TRA', @Quantity, @Quantity,0);
				IF (@@ERROR != 0) BEGIN
					CLOSE myCur;
					DEALLOCATE myCur;
					ROLLBACK;
					RETURN 4;
				END
			END 
			ELSE
			BEGIN
				CLOSE myCur;
				DEALLOCATE myCur;
				ROLLBACK;
				RETURN -1 * @ItemId;
			END
			FETCH NEXT FROM myCur INTO @ItemId, @Quantity;
		END
		CLOSE myCur;
		DEALLOCATE myCur;
		UPDATE Transfer SET Transferred = 1 WHERE Id = @TransferId;
		IF (@@ERROR != 0) BEGIN
			ROLLBACK;
			RETURN 2;
		END
		COMMIT;
	END ELSE BEGIN
		RETURN 1;
	END
END