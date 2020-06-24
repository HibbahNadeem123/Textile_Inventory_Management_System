CREATE TABLE [dbo].[Customers] (
    [CID]          INT            IDENTITY (1, 1) NOT NULL,
    [CName]        VARCHAR (50)   NOT NULL,
    [Email]              NVARCHAR(50)            NOT NULL,
    [CompanyName] NVARCHAR (MAX) NULL,
    [City]           VARCHAR (50)  NOT NULL,
    [Country]        VARCHAR (50)       NOT NULL,
    PRIMARY KEY CLUSTERED ([CID] ASC)
);

Create procedure [dbo].[DeleteCustomer]  
(  
   @id int 
)  
as  
begin  
   delete from Customers where CID =@id
End

Create procedure [dbo].[UpdateCustomer]  
(  
   @id int,
   @Name varchar (50),  
   @Email nvarchar(50),  
   @CompanyName nvarchar (MAX),
   @City varchar (50),
   @Country varchar(50)
)  
as  
begin  
   update Customers set CName=@Name, Email=@Email, CompanyName=@CompanyName, City= @City, Country= @Country where CID =@id
End

create procedure [dbo].[ViewCustomer] 
as
begin 
   select * from Customers
end


Create procedure [dbo].[AddNewCustomer]  
(  
   @CName varchar (50),  
   @Email nvarchar(50),
   @CompanyName nvarchar (max),  
   @City varchar (50),
   @Country varchar(50)
)  
as  
begin  
   Insert into Company values(@CName,@Email,@CompanyName,@City,@Country)  
End;