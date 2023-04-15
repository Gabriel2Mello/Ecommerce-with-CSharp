CREATE TABLE [dbo].[Pessoa]
([Guid] [uniqueidentifier] NOT NULL,
 [Id] [int] IDENTITY(1,1) NOT NULL,
 [Celular] [nvarchar](14),
 [Email] [nvarchar](64),
 [Senha] [nvarchar](32) NOT NULL,
 [Tipo] [nvarchar](40) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pessoa]
ADD CONSTRAINT [PK_Pessoa_Guid]
PRIMARY KEY NONCLUSTERED (Guid)
GO

CREATE UNIQUE CLUSTERED INDEX IX_Pessoa_Id ON [dbo].[Pessoa](Id)
GO
