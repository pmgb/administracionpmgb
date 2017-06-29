CREATE PROCEDURE EliminarUsuario
    @idUsuario int
AS
BEGIN
    DELETE FROM Usuarios WHERE idUsuario = @idUsuario
END
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE PROCEDURE [dbo].[EliminarUsuario]
--AS
--BEGIN
--	DELETE FROM Usuario 
--END

/* teacher
CREATE PROCEDURE EliminarUsuario
    @idUsuario int
AS
BEGIN
    DELETE FROM Usuarios WHERE idUsuario = @idUsuario
END*/