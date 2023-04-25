--Database
USE [Ecommerce]
GO

--Create Table
CREATE TABLE [dbo].[LogPessoa]
([Guid] [uniqueidentifier] NOT NULL,
 [Id] [int] IDENTITY(1,1) NOT NULL,
 [IdPessoa] [int] NOT NULL,
 [IdUsuario] [int],
 [Acao] [varchar](128),
 [Campo] [varchar](64),
 [DataAlteracao] [datetime] NOT NULL,
 [DataCadastro] [datetime] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LogPessoa]
ADD CONSTRAINT [PK_LogPessoa_Guid]
PRIMARY KEY NONCLUSTERED (Guid)
GO

CREATE UNIQUE CLUSTERED INDEX IX_LogPessoa_Id ON [dbo].[LogPessoa](Id)
GO
--Create Table

--Foreign Key
ALTER TABLE [dbo].[LogPessoa]  WITH CHECK ADD  CONSTRAINT [FK_LogPessoa_IdPessoa_REFERENCES_Pessoa_Id] FOREIGN KEY([IdPessoa])
REFERENCES [dbo].[Pessoa] ([Id])
GO
 
ALTER TABLE [dbo].[LogPessoa] CHECK CONSTRAINT [FK_LogPessoa_IdPessoa_REFERENCES_Pessoa_Id]
GO
--Foreign Key