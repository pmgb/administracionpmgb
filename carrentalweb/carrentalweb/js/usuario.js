$document.ready(function() {

    //USARÉ ESTA FUNCION PARA GUARDAR DATOS EN EL LOCAL STORAGE
    function guardarDatosUsuario() {
        if (window.localStorage) {
            mensaje.showSwal('aviso', 'Local Storage', 'No disponible');
            return;
        }
        //SI TENEMOS LOCALSTORAGE
        var objetoSerializado = JSON.stringify(datosUsuarioLogueado);
        //var objetoDeserializado = JSON.parse('....')
        localStorage.setItem('usuarioLogueado', datosUsuarioLogueado);
    }





    // PROGRAMO EL EVENTO DEL LOGIN PARA IR A COMPROBAR LAS CREDENCIALES
    // A LA BASE DE DATOS
    $('#btnLogin').click(function () {

        // validar los datos
        var email = $('#email').val();
        if (email.length == 0) {
            //alert('Por favor, indique un valor para el email');
            mensajes.showSwal('aviso', 'Datos incompletos', 'Falta el email');
            return;
        }

        var password = $('#password').val();
        if (password.length == 0) {
            mensajes.showSwal('aviso', 'Datos incompletos', 'Falta la clave');
            return;
        }
        // hacer la llamada vía ajax
        mensajes.checkLogin(email, password, function (resultado, error) {
            console.log('estoy en el callback');
            //window.location.href = '
            if (!resultado || resultado === undefined) {
                // mensaje de que no se pudo hacer login
                mensajes.showSwal('error',
                                  'Login error',
                                  'No se pudo hacer login');
                return;
                // GUARDO LOS DATOS OBTENIDOS DEL API EN EL LOCALSTORAGE
                guardarDatosUsuario(resultado);
                window.location.href = '/dashboard.html';

            }
        });
        $.ajax({
            url: '/api/login',
            type: "POST",
            dataType: 'json',
            data: {
                email: email,
                password: password
            },
            success: function (respuesta) {
                // TODO OK
                if (respuesta !== null && respuesta.error !== '') {
                    //mensajes.showSwal('error', 'Atención', respuesta.error);
                    return cb(null, 'Usuario inexistente o no encontrado');
                }
                if (respuesta !== null && respuesta.error === '') {
                   // mensajes.showSwal('aviso', 'éxito', 'Usuario encontrado');
                    //HACER LA REDIRECCION AL DASHBOARD
                    //window.location.href = "/dashboard.html";
                    return cb('OK', null);
                    
                }
            },
            error: function (respuesta) {
                // HAY ERROR
                console.log(respuesta);
            }
        });


    });

})