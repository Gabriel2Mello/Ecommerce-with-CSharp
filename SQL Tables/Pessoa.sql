--Database
USE [Ecommerce]
GO

--Create Table
CREATE TABLE [dbo].[Pessoa]
([Guid] [uniqueidentifier] NOT NULL,
 [Id] [int] IDENTITY(1,1) NOT NULL,
 [Celular] [varchar](14),
 [Email] [varchar](64),
 [Senha] [nvarchar](32) NOT NULL,
 [Tipo] [varchar](40) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pessoa]
ADD CONSTRAINT [PK_Pessoa_Guid]
PRIMARY KEY NONCLUSTERED (Guid)
GO

CREATE UNIQUE CLUSTERED INDEX IX_Pessoa_Id ON [dbo].[Pessoa](Id)
GO
--Create Table