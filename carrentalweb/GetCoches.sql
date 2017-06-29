--CREATE PROCEDURE GetCoches
--Begin

--   select 
--		TC.denominacion as Combustible
--		,M.denominacion as Marca
--		,C.id
--		,C.matricula
--		,C. color
--		,C.nPlazas
--		,C.cilindrada
--   from coches c
--		inner join Marcas M on C.idMarca = M.id
--		inner join TiposCombustible TC on C.idTipoCombustible = TC.id
--end

CREATE PROCEDURE GetCoches
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