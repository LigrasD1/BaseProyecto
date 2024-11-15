$(document).ready(function () {
    cargarProductos();
});

function cargarProductos() {
    $.ajax({
        url: "/Cliente/Articulo/GetAll", // Cambia esta URL según la ruta de tu controlador
        type: "GET",
        datatype: "json",
        success: function (data) {
            const productos = data.data;
            let htmlContent = '';
            productos.forEach(producto => {
                htmlContent += `
                    <div class="col-md-4 col-lg-3 mb-4"> <!-- Asegúrate de usar las clases col-md-4 o col-lg-3 para las columnas -->
                        <!-- Envolvemos todo el contenedor en un enlace para la redirección -->
                        <a href="/Cliente/Articulo/Detalle/${producto.id}" class="text-decoration-none">
                            <div class="card">
                                <img src="${producto.imagen}" class="card-img-top" style="width: 100%; height: 200px; object-fit: cover;" alt="Imagen del producto" />
                                <div class="card-body">
                                    <h5 class="card-title">${producto.nombre}</h5>
                                    <p class="card-text"><strong>Precio:</strong> ${producto.precio}</p>
                                    <p class="card-text"><strong>Categoría:</strong> ${producto.categoria.nombre}</p>
                                </div>
                            </div>
                        </a>
                    </div>`;
            });
            $('#productos-container').html(htmlContent);
        },
        error: function () {
            toastr.error("Error al cargar los productos.");
        }
    });
}
