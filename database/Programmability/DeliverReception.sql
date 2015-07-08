CREATE PROCEDURE [dbo].[DeliverReception] 
	@ReceptionId int 
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ReceptionState int;
	DECLARE @SectionId int;
	DECLARE @ReceptionTotal float;
	SELECT @ReceptionState = EnteredStock, @SectionId = SectionId FROM Reception WHERE Id = @ReceptionId;
	IF (@ReceptionState = 0) BEGIN
		BEGIN TRANSACTION;
		SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
		UPDATE ReceptionItem SET Price = P.Price * Quantity FROM Product P WHERE ReceptionId = @ReceptionId;
		SET @ReceptionTotal = (SELECT SUM(Price) FROM ReceptionItem WHERE ReceptionId = @ReceptionId);
		INSERT Stock SELECT R.Id AS ReferenceId, RI.ProductId, R.SectionId AS SectionId, 'REC' AS Action, RI.Quantity, RI.Quantity AS OrigQuant, RI.Price
			FROM Reception R INNER JOIN ReceptionItem RI ON RI.ReceptionId = R.Id WHERE R.Id = @ReceptionId
		UPDATE Reception SET EnteredStock = 1, Total = @ReceptionTotal WHERE Id = @ReceptionId;
		COMMIT;
	END ELSE RAISERROR('The specified reception does not exist or it has already been processed.',15,1);
END
