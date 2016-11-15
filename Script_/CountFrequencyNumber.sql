 
-- =============================================
-- Author:		tungtran
-- Create date: <Create Date,,>
-- Description:	Count frequency number
-- =============================================
alter PROCEDURE CountFrequencyNumber
	@myNumber int = 0 
AS
BEGIN
	select count(*) as 'total' 
	from [dbo].[VietlottVN]
	where NumberOne = @myNumber
	OR NumberTwo = @myNumber
	OR NumberThree = @myNumber
	OR NumberFour = @myNumber
	OR NumberFive = @myNumber
	OR NumberSix = @myNumber
END
GO
