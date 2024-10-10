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
                "data": "habilitado", "render": function (data) {
                    return data ? "Sí" : "No";
                },
            },
            {
                "data": "categoria.nombre"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <a href="/Usuario/Articulo/Edit/${data}" class="btn btn-warning">Editar</a>
                        <a onClick="DeleteArticulo(${data})" class="btn btn-danger">Eliminar</a>`;
                }
            }
        ]
    });
});

function DeleteArticulo(id) {
    Swal.fire({
        title: '¿Estás seguro?',
        text: "¡No podrás revertir esto!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sí, eliminar!',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                url: `/Usuario/Articulo/Delete/${id}`,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        $('#tblCategoria').DataTable().ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                },
                error: function () {
                    toastr.error("Ocurrió un error al intentar eliminar la categoría.");
                }
            });
        }
    });
}
