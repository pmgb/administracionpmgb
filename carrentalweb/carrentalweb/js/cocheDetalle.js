$(document).ready(function () {

    // DEFINO LA FUNCIÓN QUE CONSULTARÁ LOS DATOS DEL API
    function cargarDetalle() {

        var id = window.location.search.substring(1).split('=')[1];

        // PREPARAR LA LLAMDA AJAX 
        $.get(`/api/coches/${id}`, function (respuesta, estado) {
            // COMPRUEBO EL ESTADO DE LA LLAMADA
            if (estado === 'success') {
                // SI LLEGO HASTA AQUÍ QUIERE DECIR
                // QUE EN 'RESPUESTA' TENGO LA INFO
                $('#combustible').html(respuesta.data[0].tipoCombustible.denominacion);
                $('#marca').html(respuesta.data[0].marca.denominacion);
            }
        });
    }

    // EJECUTO LA FUNCIÓN QUE CONSULTARÁ LOS DATOS DEL API
    cargarDetalle();
});