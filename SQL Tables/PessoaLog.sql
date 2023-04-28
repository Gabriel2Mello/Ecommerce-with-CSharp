--Database
USE [Ecommerce]
GO

--Create Table
CREATE TABLE [dbo].[PessoaLog]
([Guid] [uniqueidentifier] NOT NULL,
 [Id] [int] IDENTITY(1,1) NOT NULL,
 [GuidPessoa] [uniqueidentifier],
 [IdPessoa] [int],
 [IdUsuario] [int],
 [Acao] [varchar](128),
 [Campo] [varchar](64),
 [DataAlteracao] [datetime] NOT NULL 
) ON [PRIMARY]
GO

--Create Table

--Foreign Key
ALTER TABLE [dbo].[PessoaLog]  WITH CHECK ADD  CONSTRAINT [FK_PessoaLog_IdPessoa_REFERENCES_Pessoa_Id] FOREIGN KEY([IdPessoa])
REFERENCES [dbo].[Pessoa] ([Id])
GO
 
ALTER TABLE [dbo].[PessoaLog] CHECK CONSTRAINT [FK_PessoaLog_IdPessoa_REFERENCES_Pessoa_Id]
GO
--Foreign Key