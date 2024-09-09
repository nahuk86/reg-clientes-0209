document.getElementById('consultaForm').addEventListener('submit', async (event) => {
    event.preventDefault();

    const clienteId = document.getElementById('clienteId').value;
    const resultadoDiv = document.getElementById('resultado');

    try {
        const response = await fetch(`/api/clientes/${clienteId}`);
        if (response.ok) {
            const cliente = await response.json();
            resultadoDiv.innerHTML = `
                <h2>Datos del Cliente</h2>
                <p><strong>ID:</strong> ${cliente.id}</p>
                <p><strong>Nombre:</strong> ${cliente.nombre}</p>
                <p><strong>Correo:</strong> ${cliente.correo}</p>
                <p><strong>Teléfono:</strong> ${cliente.telefono}</p>
                <p><strong>Dirección:</strong> ${cliente.direccion}</p>
            `;
        } else {
            resultadoDiv.innerHTML = '<p>Cliente no encontrado.</p>';
        }
    } catch (error) {
        resultadoDiv.innerHTML = '<p>Error al consultar la API.</p>';
    }
});
