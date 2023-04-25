--Database
USE [Ecommerce]
GO

--Create Table
CREATE TABLE [dbo].[Endereco]
([Guid] [uniqueidentifier] NOT NULL,
 [Id] [int] IDENTITY(1,1) NOT NULL,
 [IdPessoa] [int] NOT NULL,
 [Endereco] [varchar](160) NOT NULL,
 [Numero] [varchar](20),
 [Complemento] [varchar](160),
 [Bairro] [varchar](64),
 [CEP] [varchar](9),
 [Cidade] [varchar](64),
 [UF] [char](2),
 [Tipo] [varchar](40) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Endereco]
ADD CONSTRAINT [PK_Endereco_Guid]
PRIMARY KEY NONCLUSTERED (Guid)
GO

CREATE UNIQUE CLUSTERED INDEX IX_Endereco_Id ON [dbo].[Endereco](Id)
GO
--Create Table

--Foreign Key
ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD  CONSTRAINT [FK_Endereco_IdPessoa_REFERENCES_Pessoa_Id] FOREIGN KEY([IdPessoa])
REFERENCES [dbo].[Pessoa] ([Id])
GO
 
ALTER TABLE [dbo].[Endereco] CHECK CONSTRAINT [FK_Endereco_IdPessoa_REFERENCES_Pessoa_Id]
GO
--Foreign Key