USE [PedroMGB2]
GO
/****** Object:  StoredProcedure [dbo].[GetUsuarios]    Script Date: 22/06/2017 20:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetUsuarios]
AS 
BEGIN
	SELECT idUsuario, nif, nombre, apellidos, email, fechanacimiento FROM Usuario
END