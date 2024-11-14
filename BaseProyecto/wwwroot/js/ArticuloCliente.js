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
                    <div class="col-md-4">
                        <div class="card mb-4" >
                            <img src="${producto.imagen}" class="card-img-top" style="width: 100%; height: 200px; object-fit: cover;" alt="Imagen del producto" />
                            <div class="card-body">
                                <h5 class="card-title">${producto.nombre}</h5>
                                <p class="card-text"><strong>Precio:</strong> ${producto.precio}</p>
                                <p class="card-text"><strong>Categoría:</strong> ${producto.categoria.nombre}</p>
                            </div>
                        </div>
                    </div>`;
            });
            $('#productos-container').html(htmlContent);
        },
        error: function () {
            toastr.error("Error al cargar los productos.");
        }
    });
}
