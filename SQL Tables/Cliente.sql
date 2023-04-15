--Create Table
CREATE TABLE [dbo].[Cliente]
([Guid] [uniqueidentifier] NOT NULL,
 [Id] [int] IDENTITY(1,1) NOT NULL,
 [IdPessoa] [int] NOT NULL,
 [NumeroIdentidade] [nvarchar](18) NOT NULL,
 [Nome] [nvarchar](255) NOT NULL,
 [RazaoSocial] [nvarchar](255),
 [InscricaoEstadual] [nvarchar](9),
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [PK_Cliente_Guid]
PRIMARY KEY NONCLUSTERED (Guid)
GO

CREATE UNIQUE CLUSTERED INDEX IX_Cliente_Id ON [dbo].[Cliente](Id)
GO
--Create Table

--Foreign Key
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_IdPessoa_REFERENCES_Pessoa_Id] FOREIGN KEY([IdPessoa])
REFERENCES [dbo].[Pessoa] ([Id])
GO
 
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_IdPessoa_REFERENCES_Pessoa_Id]
GO
--Foreign Key