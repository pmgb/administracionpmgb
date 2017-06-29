USE [PedroMGB2]
GO
/****** Object:  StoredProcedure [dbo].[GetCoches]    Script Date: 29/06/2017 19:40:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetCoches]
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