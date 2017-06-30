USE [PedroMGB2]
GO
/****** Object:  Table [dbo].[Coches]    Script Date: 30/06/2017 20:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coches](
	[id] [bigint] IDENTITY(5,1) NOT NULL,
	[matricula] [nvarchar](10) NOT NULL,
	[idmarca] [bigint] NOT NULL,
	[idTipoCombustible] [bigint] NOT NULL,
	[color] [nchar](20) NULL,
	[cilindrada] [decimal](4, 2) NULL,
	[nPlazas] [smallint] NOT NULL,
	[FechaMatriculacion] [date] NULL,
 CONSTRAINT [PK_Coches] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[denominacion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Mitabla]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mitabla](
	[idUsuario] [nchar](10) NOT NULL,
	[email] [nchar](50) NOT NULL,
	[password] [nchar](10) NOT NULL,
	[fechanacimiento] [date] NOT NULL,
	[nombre] [nchar](50) NOT NULL,
	[apellidos] [nchar](50) NOT NULL,
	[nif] [nchar](10) NOT NULL
)

GO
/****** Object:  Table [dbo].[TiposCombustible]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposCombustible](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[denominacion] [nchar](10) NOT NULL,
 CONSTRAINT [PK_tipos combustible] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [nchar](10) NOT NULL,
	[email] [nchar](50) NOT NULL,
	[password] [nchar](10) NOT NULL,
	[fechanacimiento] [date] NOT NULL,
	[nombre] [nchar](50) NOT NULL,
	[apellidos] [nchar](50) NOT NULL,
	[nif] [nchar](10) NOT NULL
)

GO
ALTER TABLE [dbo].[Coches] ADD  CONSTRAINT [DF__Coches__nPlazas__398D8EEE]  DEFAULT ((5)) FOR [nPlazas]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarMarca]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- PROCEDIMIENTO PARA ACTUALIZAR LOS DATOS DE UNA MARCA

CREATE PROCEDURE [dbo].[ActualizarMarca]
    @id bigint
	,@denominacion nvarchar(50)
AS
BEGIN
   UPDATE Marcas SET
     denominacion = @denominacion
	WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarCoche]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarCoche]
     @matricula nvarchar(10)
    ,@idMarca bigint
    ,@idTipoCombustible bigint
    ,@color nvarchar(20)
    ,@cilindrada decimal(4,2)
    ,@nPlazas smallint
    ,@fechaMatriculacion date
AS
BEGIN

    INSERT INTO [Coches]
               ([matricula]
               ,[idMarca]
               ,[idTipoCombustible]
               ,[color]
               ,[cilindrada]
               ,[nPlazas]
               ,[fechaMatriculacion])
         VALUES
               (@matricula
               ,@idMarca
               ,@idTipoCombustible
               ,@color
               ,@cilindrada
               ,@nPlazas
               ,@fechaMatriculacion)    

END
GO
/****** Object:  StoredProcedure [dbo].[AgregarMarca]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- PROCEDIMIENTO PARA INSERTAR UNA NUEVA MARCA

CREATE PROCEDURE [dbo].[AgregarMarca]
	@denominacion nvarchar (50)
AS
BEGIN
	INSERT INTO Marcas (denominacion) VALUES (@denominacion)
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarClasificacion]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarClasificacion]
	@id bigint
AS
BEGIN
	DELETE FROM Clasificaciones WHERE IdClasificacion = @id
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarMarca]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarMarca]
	@id bigint
AS
BEGIN
	DELETE FROM Marcas WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarUsuario]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarUsuario]
AS
BEGIN
	DELETE FROM Usuario 
END

GO
/****** Object:  StoredProcedure [dbo].[GET_COCHE_EJERCICIO]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GET_COCHE_EJERCICIO]
AS
BEGIN

SELECT distinct M.denominacion AS Marca
	  ,C.matricula AS Matrículas
	  , C.nPlazas AS N_Plazas
FROM COCHES C, Marcas M
GROUP BY 
         M.denominacion
        ,C.matricula
        ,C.nPlazas
    ORDER BY nPlazas
END


GO
/****** Object:  StoredProcedure [dbo].[GET_COCHE_POR_MARCA]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- CREAMOS UN PROCEDIMIENTO ALMACENADO

CREATE PROCEDURE [dbo].[GET_COCHE_POR_MARCA]
AS
BEGIN
--	SELECT COUNT(*) FROM Coches
--	SELECT * FROM Coches

--	INSERT INTO Coches (matricula, idmarca, idTipoCombustible, color
--	, cilindrada, nPlazas, FechaMatriculacion)
--	SELECT matricula, idmarca, idTipoCombustible, color
--	, cilindrada, nPlazas, FechaMatriculacion
--	FROM Coches

--	SELECT * FROM Coches
	--PRINT 'MI PRIMER PROCEDIMIENTO ALMACENADO'

	SELECT 
		Marcas.denominacion as denominacionMarca
    , Marcas.denominacion as denominacionTipoCombustible
    , Coches.idMarca
    , Coches.idTipoCombustible
    , Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
    , Coches.fechaMatriculacion, Coches.cilindrada
FROM Marcas
    INNER JOIN Coches on Marcas.id = Coches.idMarca
    INNER JOIN TiposCombustible on Coches.idTipoCombustible = TiposCombustible.id
GROUP BY 
      Marcas.denominacion
    , TiposCombustible.denominacion
    , Coches.idMarca
    , Coches.idTipoCombustible
    , Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
    , Coches.fechaMatriculacion, Coches.cilindrada
ORDER BY Marcas.denominacion

END

GO
/****** Object:  StoredProcedure [dbo].[GET_COCHE_POR_MARCA_ID]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_COCHE_POR_MARCA_ID]
	@id bigint
AS
BEGIN
SELECT 
	  Marcas.denominacion as denominacionMarca
	, TiposCombustible.denominacion as denominacionTipoCombustible
	, Coches.idMarca
	, Coches.idTipoCombustible
	, Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
	, Coches.fechaMatriculacion, Coches.cilindrada
FROM Marcas
	INNER JOIN Coches on Marcas.id = Coches.idMarca
	INNER JOIN TiposCombustible on Coches.idTipoCombustible = TiposCombustible.id
WHERE Coches.id = @id
GROUP BY 
	  Marcas.denominacion
	, TiposCombustible.denominacion
	, Coches.idMarca
	, Coches.idTipoCombustible
	, Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
	, Coches.fechaMatriculacion, Coches.cilindrada
ORDER BY Marcas.denominacion

END

GO
/****** Object:  StoredProcedure [dbo].[GET_COCHE_POR_MARCA_MATRICULA_PLAZAS]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_COCHE_POR_MARCA_MATRICULA_PLAZAS]
AS
BEGIN
    SELECT 
         M.denominacion as Marca
        ,C.matricula
        ,C.nPlazas
    FROM Marcas M
        INNER JOIN Coches C ON M.id = C.idMarca
    GROUP BY 
         M.denominacion
        ,C.matricula
        ,C.nPlazas
    ORDER BY nPlazas
END

GO
/****** Object:  StoredProcedure [dbo].[GET_COCHE_POR_MARCA_MATRICULA_PLAZAS_2]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_COCHE_POR_MARCA_MATRICULA_PLAZAS_2]
      @marca nvarchar(50) = NULL
    , @nPlazas smallint = NULL
AS
BEGIN
    SELECT 
         M.denominacion as Marca
        ,C.matricula
        ,C.nPlazas
    FROM Marcas M
        INNER JOIN Coches C ON M.id = C.idMarca
    WHERE 
        (M.denominacion LIKE '%' + @marca + '%' OR @marca is null)
    and    (C.nPlazas >= @nPlazas OR @nPlazas is null)
    ORDER BY nPlazas
END

GO
/****** Object:  StoredProcedure [dbo].[Get_Marcas_ID]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Get_Marcas_ID]
      @id bigint   as
  Begin
    select id, denominacion from Marcas
    WHERE Marcas.id = @id
  end;

GO
/****** Object:  StoredProcedure [dbo].[GET_TiposCombustible]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GET_TiposCombustible]
AS
BEGIN
	SELECT id, denominacion FROM TiposCombustible 
END

GO
/****** Object:  StoredProcedure [dbo].[GetCoches]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCoches]
AS
BEGIN

    SELECT 
        TC.denominacion as Combustible
        ,M.denominacion as Marca
        ,C.id
        ,C.matricula
        ,C.color
        ,C.nPlazas
        ,C.cilindrada
        ,C.fechaMatriculacion
    FROM Coches C
        inner join Marcas M on C.idMarca = M.id
        inner join TiposCombustible TC on C.idTipoCombustible = TC.id

END
GO
/****** Object:  StoredProcedure [dbo].[GetCochesPorId]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCochesPorId]
    @id bigint
AS
BEGIN

    SELECT 
        TC.denominacion as Combustible
        ,M.denominacion as Marca
        ,C.id
        ,C.matricula
        ,C.color
        ,C.nPlazas
        ,C.cilindrada
        ,C.fechaMatriculacion
    FROM Coches C
        inner join Marcas M on C.idMarca = M.id
        inner join TiposCombustible TC on C.idTipoCombustible = TC.id
    WHERE C.id = @id

END
GO
/****** Object:  StoredProcedure [dbo].[GetMarcas]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMarcas]
AS
BEGIN
	SELECT id, denominacion FROM TiposCombustible 
END

GO
/****** Object:  StoredProcedure [dbo].[GetUsuarios]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUsuarios]
AS 
BEGIN
	SELECT idUsuario, nif, nombre, apellidos, email, fechanacimiento FROM Usuario
END
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 30/06/2017 20:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Login]
  @email nvarchar(255),
  @password  nvarchar (16)
AS
BEGIN

SELECT * FROM Usuario where email =@email and password =@password
END


GO
