$(document).ready(function () {
    cargarCarrito();
});

// Función para cargar los productos del carrito
function cargarCarrito() {
    $.ajax({
        url: "/Cliente/Carrito/GetAll", // La ruta de tu controlador
        type: "GET",
        dataType: "json",
        success: function (data) {
            const carritoArticulos = data.data;
            let htmlContent = '';

            if (carritoArticulos.length > 0) {
                carritoArticulos.forEach(item => {
                    htmlContent += `
                                <div class="col-md-4 mb-4">
                                    <div class="card">
                                        <img src="${item.articulo.imagen}" class="card-img-top" style="height: 200px; object-fit: cover;" alt="Imagen de producto">
                                        <div class="card-body">
                                            <h5 class="card-title">${item.articulo.nombre}</h5>
                                            <p class="card-text">Precio: $${item.articulo.precio}</p>
                                            <p class="card-text">Cantidad: ${item.cantidad}</p>
                                            <p class="card-text">Id: ${item.id}</p>
                                            <p class="card-text">Subtotal: $${item.articulo.precio * item.cantidad}</p>
                                            <a href="/Cliente/Articulo/Detalle/${item.articulo.id}" class="btn btn-info">Ver Detalles</a>
                                            <button class="btn btn-danger mt-2" onclick="eliminarDelCarrito(${item.id})">Eliminar</button>
                                        </div>
                                    </div>
                                </div>`;
                });
            } else {
                htmlContent = '<p>No tienes artículos en tu carrito.</p>';
            }

            $('#carrito-container').html(htmlContent);
        },
        error: function () {
            alert("Hubo un error al cargar el carrito.");
        }
    });
}

// Función para eliminar un artículo del carrito
function eliminarDelCarrito(carritoArticuloId) {
    $.ajax({
        url: `/Cliente/Carrito/Eliminar/${carritoArticuloId}`, // Ruta para eliminar artículo del carrito
        type: "POST",
        success: function () {
            cargarCarrito(); // Recargar el carrito
        },
        error: function () {
            alert("Hubo un error al eliminar el artículo.");
        }
    });
}

// Función para realizar la compra (vacía el carrito)
function realizarCompra() {
    $.ajax({
        url: "/Cliente/Carrito/RealizarCompra",
        type: "POST",
        success: function (response) {
            if (response.success) {
                toastr.success("Compra realizada con éxito.");
                
                cargarCarrito();
                
            } else {
                toastr.warning(response.mensaje || "Error al realizar la compra.");
            }
        },
        error: function (xhr) {
            // Manejo de errores del servidor (BadRequest)
            if (xhr.responseJSON && xhr.responseJSON.mensaje) {
                toastr.error(xhr.responseJSON.mensaje);
            } else {
                toastr.error("Ocurrió un error inesperado.");
            }
        }
    });
}

