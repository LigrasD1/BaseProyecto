function printTable() {
			// Obtener el HTML de la tabla
			const originalTable = document.getElementById("tblUsuario");
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
					table {width: 100%; border-collapse: collapse; }
					th, td {border: 1px solid #000; padding: 8px; text-align: left; }
				</style>
		</head>
		<body>
			<h3>Lista de Usuarios</h3>
			${clonedTable.outerHTML}
		</body>
	</html>
	`);

	// Esperar a que se cargue el contenido y luego imprimir
	printWindow.document.close();
	printWindow.print();
}