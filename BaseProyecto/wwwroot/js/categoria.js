$(document).ready(function () {
    $('#tblCategoria').DataTable({
        "ajax": {
            "url": "/Usuario/Categoria/GetAll", // Ruta a tu controlador
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id" },
            { "data": "nombre" },
            {
                "data": "habilitada", "render": function (data) {
                    return data ? "Sí" : "No";
                }
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <a href="~/Areas/Usuario/Categoria/Edit/${data}" class="btn btn-warning">Editar</a>
                        <a href="/Usuario/Categoria/Details/${data}" class="btn btn-info">Detalles</a>
                        <a href="/Usuario/Categoria/Delete/${data}" class="btn btn-danger">Eliminar</a>`;
                }
            }
        ]
    });
});