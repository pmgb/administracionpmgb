$(document).ready(function () {


    mensajes.cargarDatosUsuario(function (datosUsuario, error)
    //yo: var datosUsuario = mensajes.cargarDatosUsuario(function (resultado, error) {
        if (datosUsuario === null) {
            //REDIRECCIONO
            window.location.href = '/login.html';
        }
    });






    mensajes.checkLogin('test@test.com', '123456', function () {
        console.log('estoy en el callback');
        //window.location.href = '/dashboard.html';
    });

});