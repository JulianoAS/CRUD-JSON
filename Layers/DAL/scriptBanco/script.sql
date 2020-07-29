
CREATE TABLE [dbo].[tbPessoas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NULL,
	[Sobrenome] [varchar](100) NULL,
	[CPF] [varchar](14) NULL,
	[RG] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
	[Telefone] [varchar](50) NULL,
	[Celular] [varchar](50) NULL,
	[Cep] [varchar](9) NULL,
	[Estado] [varchar](50) NULL,
	[Cidade] [varchar](50) NULL,
	[Logradouro] [varchar](100) NULL,
	[Data] [datetime] NULL,
 CONSTRAINT [PK_tbPessoas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Atualizar_Pessoa]
@Id int,
@Nome varchar(50),
@Sobrenome varchar(50),
@CPF varchar(14),
@RG varchar(20),
@CEP varchar(14),
@Logradouro varchar(100),
@Cidade varchar(50),
@Estado varchar(50),
@Email varchar(50),
@Telefone varchar(12),
@Celular varchar(12)
AS
UPDATE tbPessoas SET
Nome= @Nome,
Sobrenome = @Sobrenome,
CPF = @CPF,
RG = @RG,
CEP = @CEP,
LOGRADOURo =@Logradouro,
Cidade = @Cidade,
Estado =@Estado,
Telefone = @Telefone,
Celular = @Celular
WHERE Id = @Id
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Deletar_Pessoa]
@ID int
as
DELETE FROM tbPessoas WHERE ID = @ID
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_Inserir_Pessoa]
@Nome varchar(50),
@Sobrenome varchar(50),
@CPF varchar(14),
@RG varchar(20),
@CEP varchar(14),
@Logradouro varchar(100),
@Cidade varchar(50),
@Estado varchar(50),
@Email varchar(50),
@Telefone varchar(12),
@Celular varchar(12)
AS
INSERT INTO tbPessoas(Nome,Sobrenome,CPF,RG,CEP,Logradouro,Cidade,Estado,Email,Telefone,Celular)VALUES(@Nome,@Sobrenome,@CPF,@RG,@CEP,@Logradouro,@Cidade,@Estado,@Email,@Telefone,@Celular)


GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Ler_Pessoa]
@ID int
as
SELECT Id,Nome,Sobrenome,CPF,RG,CEP,Logradouro,Cidade,Estado,Celular,Email,Telefone,Celular FROM tbPessoas
WHERE Id = @ID 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_List_Pessoa]
as
SELECT Id,Nome,Sobrenome,CPF,RG,CEP,Logradouro,Cidade,Estado,Celular,Email,Telefone,Celular FROM tbPessoas 
GO
USE [master]
GO
ALTER DATABASE [Crud] SET  READ_WRITE 
GO
