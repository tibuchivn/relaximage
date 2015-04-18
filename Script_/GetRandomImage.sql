 ALTER PROCEDURE [dbo].[GetRandomImage] 
	@randomOn int = 50, --not use this param. random all
	@amountReturn int = 1
AS
BEGIN	
	SET NOCOUNT ON;
	--select * from ImgLink
	declare @query nvarchar(2000)
	set @query = 'select top ' + cast(@amountReturn as nvarchar(6)) + ' * from ImgLink as A where isbadurl = 0 or isbadurl is null order by newid()'
	--print(@query)
	exec (@query)
END 