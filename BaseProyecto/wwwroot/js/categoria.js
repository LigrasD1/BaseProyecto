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
function printTable() {
    // Obtener el HTML de la tabla
    const originalTable = document.getElementById("tblCategoria");
    const clonedTable = originalTable.cloneNode(true);

    // Eliminar la columna de "Operaciones" en el encabezado
    clonedTable.querySelectorAll("thead tr th:last-child").forEach(cell => cell.remove());

    // Eliminar la columna de "Operaciones" en cada fila de la tabla
    clonedTable.querySelectorAll("tbody tr").forEach(row => {
        row.removeChild(row.lastElementChild);
    });

    // Crear una nueva ventana
    const printWindow = window.open("", "_blank");

    // Escribir el contenido en la nueva ventana
    printWindow.document.write(`
        <html>
            <head>
                <title>Imprimir Tabla</title>
                <link rel="stylesheet" href="https://cdn.datatables.net/1.10.21/css/jquery.dataTables.min.css">
                <style>
                    table { width: 100%; border-collapse: collapse; }
                    th, td { border: 1px solid #000; padding: 8px; text-align: left; }
                </style>
            </head>
            <body>
                <h3>Lista de categorias</h3>
                ${clonedTable.outerHTML}
            </body>
        </html>
    `);

    // Esperar a que se cargue el contenido y luego imprimir
    printWindow.document.close();
    printWindow.print();
}