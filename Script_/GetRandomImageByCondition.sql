 
-- =============================================
-- Author:		tungtran
-- Create date: <Create Date,,>
-- Description:	Get Ramdom Image by condition
-- =============================================
ALTER PROCEDURE GetRandomImageByCondition
	   @IsNice int=0,
	   @HotLeve int = 0, 
	   @Domain nvarchar(1000) = '',
	   @amountReturn int = 10
	 
AS
BEGIN
 
    --select top 10 * from ImgLink

	declare @query nvarchar(4000)
	set @query = 'select top ' + cast(@amountReturn as nvarchar(6)) + ' * 
	from ImgLink as A where (isbadurl = 0 or isbadurl is null )'
	
	if(@IsNice > 0)
	begin
	   Set @query += 'And [IsNice] = 1'
	end

	if(@HotLeve > 0)
	begin
	   Set @query += 'And [HotLevel] = ' + @HotLeve
	end

	if(@Domain != '')
	begin
	   Set @query += 'And [Domain] = ' + @Domain
	end

	set @query += 'order by newid()'
	--print(@query)
	exec (@query)
END
GO
