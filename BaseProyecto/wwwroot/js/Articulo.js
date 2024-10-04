$(document).ready(function () {
    $('#tblArticulo').DataTable({
        "ajax": {
            "url": "/Usuario/Articulo/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id" },
            { "data": "nombre" },
            {
                "data": "habilitada", "render": function (data) {
                    return data ? "Sí" : "No";
                },
            },
            //{
            //    "data": "Categoria.nombre", // Aquí accedemos al nombre de la categoría
            //    "render": function (data) {
            //        return data ? data : "Sin categoría";
            //    }
            //},
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <a href="/Usuario/Articulo/Edit/${data}" class="btn btn-warning">Editar</a>
                        <a href="/Usuario/Articulo/Details/${data}" class="btn btn-info">Detalles</a>
                        <a onClick="DeleteArticulo(${data})" class="btn btn-danger">Eliminar</a>`;
                }
            }
        ]
    });
});
