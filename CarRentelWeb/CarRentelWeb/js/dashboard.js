$(document).ready(function () {

    mensajes.cargarDatosUsuario(function (datosUsuario, error) {
        if (datosUsuario === null) {
            // REDIRECCIONO
            window.location.href = '/login.html';
        }
    });

});


//mensajes.checkLogin('test@test.com', '123456', function () {
//    debugger;
//    console.log('estoy en el callback');
//    //window.location.href = '/login.html';
//});
