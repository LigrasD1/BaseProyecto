$(document).ready(function () {
    $('#tblCategoria').DataTable({
        "ajax": {
            "url": "/Usuario/Categoria/GetAll", 
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
                        <a href="/Usuario/Categoria/Edit/${data}" class="btn btn-warning">Editar</a>
                        <a href="/Usuario/Categoria/Details/${data}" class="btn btn-info">Detalles</a>
                        <a onClick="DeleteCategory(${data})" class="btn btn-danger">Eliminar</a>`;;
                }
            }
        ]
    });
});

function DeleteCategory(id) {
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
                url: `/Usuario/Categoria/Delete/${id}`,
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