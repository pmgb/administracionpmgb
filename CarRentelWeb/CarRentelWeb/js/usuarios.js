﻿$(document).ready(function () {

    // USARE ESTA FUNCION PARA GUARDAR DATOS EN EL LOCAL STORAGE
    function guardarDatosUsuario(datosUsuarioLogueado) {
        if (!window.localStorage) {
            mensajes.showSwal('aviso', 'Local Storage', 'No disponible');
            return;
        }
        // SI TENEMOS LOCALSTORAGE
        var objetoSerializado = JSON.stringify(datosUsuarioLogueado);
        localStorage.setItem('usuarioLogueado', objetoSerializado);
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
            
            if (!resultado || resultado === undefined) {
                // mensaje de que no se pudo hacer login
                mensajes.showSwal('error',
                                  'Login error',
                                  'No se pudo hacer login');
                return;
            }
            debugger;
            // GUARDO LOS DATOS OBTENIDOS DEL API EN EL LOCALSTORAGE
            guardarDatosUsuario(resultado);
            //window.location.href = '/dashboard.html';
            
        });
    });

});