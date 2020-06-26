CREATE TABLE [dbo].[Order] (
    [OID]          INT            IDENTITY (1, 1) NOT NULL,
    [Quantity]        INT   NOT NULL,
    [TotalPrice]              INT            NOT NULL,
    
    PRIMARY KEY CLUSTERED ([OID] ASC)
);

Create procedure [dbo].[DeleteOrder]  
(  
   @id int 
)  
as  
begin  
   delete from [Order] where OID =@id
End

Create procedure [dbo].[UpdateOrder]  
(  
   @id int,
   @quantity int,
   @tprice int
)  
as  
begin  
   update [Order] set Quantity= @quantity, TotalPrice=@tprice where OID =@id
End

create procedure [dbo].[ViewOrder] 
as
begin 
   select * from [Order]
end

CREATE PROCEDURE [dbo].[SearchOrder]
	@id nvarchar(25)
AS
begin
	SELECT * from [Order] where OID like @id+'%'
end

CREATE procedure [dbo].[InsertOrder]  
(  
    @quantity int,
   @tprice int
)  
as  
begin  
   Insert into [Order] values(@quantity,@tprice)  
End