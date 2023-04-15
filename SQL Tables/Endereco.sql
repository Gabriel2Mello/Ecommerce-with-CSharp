--Create Table
CREATE TABLE [dbo].[Endereco]
([Guid] [uniqueidentifier] NOT NULL,
 [Id] [int] IDENTITY(1,1) NOT NULL,
 [IdPessoa] [int] NOT NULL,
 [Endereco] [nvarchar](160) NOT NULL,
 [Numero] [nvarchar](20),
 [Complemento] [nvarchar](160),
 [Bairro] [nvarchar](64),
 [CEP] [nvarchar](9),
 [Cidade] [nvarchar](64),
 [UF] [char](2),
 [Tipo] [nvarchar](40) NOT NULL
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