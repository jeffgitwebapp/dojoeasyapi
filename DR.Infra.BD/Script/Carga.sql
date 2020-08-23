USE [drRef]

declare @id as uniqueidentifier = newid();


INSERT INTO [dbo].[Cliente]
           ([Id]
           ,[Nome]
           ,[Idade]
           ,[Saldo])
     VALUES
           ('2089E442-8BC9-47E7-9D66-63D9595DD657'
           ,'Jefferson de Jesus Santos'
           ,35
           ,100000)
GO

INSERT INTO [dbo].[Endereco]
           ([Id]
           ,[Rua]
           ,[Numero]
           ,[Bairro]
           ,[Cidade]
           ,[Cep]
           ,[Estado]
           ,[ClienteID]
           ,[DataCriacao])
     VALUES
           (NEWID()
           ,'Avenida General Valdomiro de Lima'
           ,'590'
           ,'Jabaquara'
           ,'São Paulo'
           ,'11111-111'
           ,'SP'
           ,'2089E442-8BC9-47E7-9D66-63D9595DD657'
           ,getdate())
GO

INSERT INTO [dbo].[Produto]
           ([Id]
           ,[Codigo]
           ,[Descricao]
           ,[Estoque]
           ,[PrecoUnitario]
           ,[ValorMinimoDeCompra])
     VALUES
           (NEWID()
           ,'FIN-RV-1'
           ,'Renda Variavel'
           ,25
           ,100
           ,200)
GO


INSERT INTO [dbo].[Produto]
           ([Id]
           ,[Codigo]
           ,[Descricao]
           ,[Estoque]
           ,[PrecoUnitario]
           ,[ValorMinimoDeCompra])
     VALUES
           (NEWID()
           ,'FIN-RF-2'
           ,'Renda Fixa'
           ,25
           ,100
           ,200)
GO


/*
DELETE FROM [dbo].[Endereco]
DELETE FROM [dbo].[Cliente]
Delete From [dbo].[OrdemCompra]
DELETE FROM [dbo].[Produto]



INSERT INTO [dbo].[Endereco]
           ([Id]
           ,[Rua]
           ,[Numero]
           ,[Bairro]
           ,[Cidade]
           ,[Cep]
           ,[Estado]
           ,[ClienteID]
           ,[DataCriacao])
     VALUES
           (NEWID()
           ,'Avenida General Valdomiro de Lima'
           ,'590'
           ,'Jabaquara'
           ,'São Paulo'
           ,'11111-111'
           ,'SP'
           ,'2089E442-8BC9-47E7-9D66-63D9595DD657'
           ,getdate())
GO

*/