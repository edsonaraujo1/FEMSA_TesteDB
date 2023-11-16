USE [DBTeste]
GO
/****** Object:  Table [dbo].[Motorista]    Script Date: 29/06/2020 10:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Motorista]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Motorista](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[cpf] [varchar](25) NULL,
	[nome] [varchar](150) NULL,
	[sexo] [varchar](30) NULL,
	[idade] [int] NULL,
	[ativo] [varchar](15) NULL,
 CONSTRAINT [PK_Motorista] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[AtualizarMotorista]    Script Date: 29/06/2020 10:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AtualizarMotorista]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AtualizarMotorista] AS' 
END
GO
ALTER PROCEDURE [dbo].[AtualizarMotorista]
	@codigo int,
	@cpf varchar(25),
	@nome varchar(50),
	@sexo varchar(15),
	@idade int,
	@ativo varchar(15)
AS
	UPDATE Motorista SET cpf=@cpf, nome=@nome, sexo=@sexo, idade=@idade, ativo=@ativo
	WHERE codigo=@codigo
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[BuscaMotorista]    Script Date: 29/06/2020 10:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BuscaMotorista]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[BuscaMotorista] AS' 
END
GO
ALTER PROCEDURE [dbo].[BuscaMotorista]
(
    @cpf varchar(25)
)
AS
select * from Motorista Where cpf = @cpf
RETURN
GO
/****** Object:  StoredProcedure [dbo].[CarregaMotorista]    Script Date: 29/06/2020 10:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CarregaMotorista]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[CarregaMotorista] AS' 
END
GO
ALTER PROCEDURE [dbo].[CarregaMotorista]

AS
select * from Motorista
RETURN
GO
/****** Object:  StoredProcedure [dbo].[DeletarMotorista]    Script Date: 29/06/2020 10:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeletarMotorista]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[DeletarMotorista] AS' 
END
GO
ALTER PROCEDURE [dbo].[DeletarMotorista]
(
@codigo int
)
AS
DELETE
    FROM dbo.Motorista
    WHERE 
    codigo = @codigo
RETURN
GO
/****** Object:  StoredProcedure [dbo].[getMotorista]    Script Date: 29/06/2020 10:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[getMotorista]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[getMotorista] AS' 
END
GO
ALTER PROCEDURE [dbo].[getMotorista]
(
    @codigo int
)
AS
select * from Motorista Where codigo = @codigo
RETURN
GO
/****** Object:  StoredProcedure [dbo].[InserirMotorista]    Script Date: 29/06/2020 10:01:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InserirMotorista]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InserirMotorista] AS' 
END
GO
ALTER PROCEDURE [dbo].[InserirMotorista]
(
@cpf varchar(25),
@nome varchar(50),
@sexo varchar(15),
@idade int,
@ativo varchar(15)
)
AS
Insert into Motorista(cpf,nome,sexo,idade,ativo) values
(@cpf,@nome,@sexo,@idade,@ativo)

ALTER INDEX ALL ON dbo.Motorista
REORGANIZE

RETURN
GO
