SELECT c.Id
 ,c.[Nome]
 ,c.[Idade]
 ,c.[Saldo]
 ,e.Cidade
 ,e.Estado
FROM [dbo].[Cliente] c
inner join
[dbo].[Endereco] e
on c.Id = e.ClienteID