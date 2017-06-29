CREATE PROCEDURE AgregarCoche
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