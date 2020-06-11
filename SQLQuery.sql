truncate table Comments

/*Create Trigger addIdolID On dbo.Idols For Insert
As
begin
	update dbo.AspNetUsers set IdolID = (select dbo.Idols.ID from dbo.Idols where dbo.Idols.Email = dbo.AspNetUsers.Email) 
End*/
