function verificarSession() {
    var docenteLocal = localStorage.getItem("tokenSesion");

    if (docenteLocal == "") {
        window.location.href = "/index.html";
    }

    var docenteObjeto = JSON.parse(docenteLocal);

    if (docenteObjeto.rol != "Docente") {
        window.location.href = "/index.html";
    }

}

async function ObtenerDocente() {
    var docenteLocal = localStorage.getItem("tokenSesion");

    if (docenteLocal != "") {
        var docenteObjeto = JSON.parse(docenteLocal);

        fetch("https://localhost:7146/v1/api/Docente?legajo=" + docenteObjeto.userName, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": docenteObjeto.response.tokenSesion,
                "UsuarioId": docenteObjeto.response.usuarioId
            }
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error("Error en la respuesta: " + response.status);
                }
                return response.json();
            })
            .then(data => {
                document.getElementById('nombreUser').innerHTML = data.nombre + ' ' + data.apellido;
                document.getElementById('nombreDocente').innerHTML = "Bienvenido de vuelta, " + data.nombre + ' ' + data.apellido;
            })
            .catch(error => {
                console.error("Error en la solicitud:", error);
            });
    }
}

async function ObtenerAdministracionDocente() {
    const docenteLocal = localStorage.getItem("tokenSesion");

    if (docenteLocal != "") {
        const docenteObjeto = JSON.parse(docenteLocal);

        try {
            const response = await fetch(`https://localhost:7146/v1/api/Docente/materia/only?legajo=${docenteObjeto.userName}`, {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": docenteObjeto.response.tokenSesion,
                    "UsuarioId": docenteObjeto.response.usuarioId
                }
            });

            if (!response.ok) {
                throw new Error("Error en la respuesta: " + response.status);
            }

            const data = await response.json();
            const materiasContainer = document.getElementById("materias-container");
            materiasContainer.innerHTML = ""; // Limpiar contenedor de materias

            data.forEach(materia => {
                const tableHTML = `
                    <div class="card shadow mb-4">
                        <div class="card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">${materia.materia} (${materia.carrera}) - Año ${materia.anioPlan}</h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table table-bordered" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th>Legajo</th>
                                            <th>Nombre</th>
                                            <th>Apellido</th>
                                            <th>Acciones</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        ${materia.listAlumno.map(alumno => `
                                            <tr>
                                                <td>${alumno.legajo}</td>
                                                <td>${alumno.nombre}</td>
                                                <td>${alumno.apellido}</td>
                                              
                                                <td>
                                                    <button class="btn btn-info btn-sm" onclick="mostrarInfo(${alumno.legajo}, '${materia.materia}')">
                                                        <i class="fas fa-info-circle"></i>
                                                    </button>
                                                </td>
                                            </tr>
                                        `).join("")}
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                `;

                materiasContainer.innerHTML += tableHTML;
            });

        } catch (error) {
            console.error("Error en la solicitud:", error);
        }
    }
}

function logout() {
    localStorage.removeItem("tokenSesion");
    window.location.href = "/index.html";
}

function editarNota(legajoAlumno, materia, notaActual) {
    const existingModal = document.getElementById('editarNotaModal');
    if (existingModal) {
        existingModal.remove();
    }
    const modalContent = `
        <div class="modal fade" id="editarNotaModal" tabindex="-1" role="dialog" aria-labelledby="editarNotaModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="editarNotaModalLabel">Editar Nota para ${materia}</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p>Legajo: ${legajoAlumno}</p>
                        <label for="nuevaNota">Nota Actual: ${notaActual}</label>
                        <input type="number" id="nuevaNotaInput" class="form-control" value="${notaActual}" min="1" max="10" required>
                        <div id="notaError" class="text-danger" style="display: none;">Por favor, ingrese una nota entre 1 y 10.</div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                        <button type="button" class="btn btn-primary" onclick="confirmarEdicionNota(${legajoAlumno}, '${materia}')">Confirmar</button>
                    </div>
                </div>
            </div>
        </div>
    `;
    document.body.insertAdjacentHTML('beforeend', modalContent);

    $('#editarNotaModal').modal('show');
}

async function confirmarEdicionNota(legajoAlumno, materia) {

    const docenteLocal = localStorage.getItem("tokenSesion");

    if (docenteLocal != "") {
        const docenteObjeto = JSON.parse(docenteLocal);

        const nuevaNota = document.getElementById("nuevaNotaInput").value;
        const notaError = document.getElementById("notaError");

        // Validar que la nota esté entre 1 y 10
        if (nuevaNota < 1 || nuevaNota > 10) {
            notaError.style.display = "block"; // Mostrar mensaje de error
            return; // Salir de la función si la nota es inválida
        } else {
            notaError.style.display = "none"; // Ocultar mensaje de error
        }

        try {
            const response = await fetch(`https://localhost:7146/v1/api/Docente/materia/editar?Legajo=${legajoAlumno}&Nota=${nuevaNota}&Materia=${encodeURIComponent(materia)}`, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": docenteObjeto.response.tokenSesion,
                    "UsuarioId": docenteObjeto.response.usuarioId
                }
            });

            if (!response.ok) {
                throw new Error("Error al actualizar la nota: " + response.status);
            }

            window.location.reload();
        } catch (error) {
            console.error("Error en la solicitud:", error);
            alert("Ocurrió un error al actualizar la nota. Intente nuevamente.");
        }

        $('#editarNotaModal').modal('hide');
        document.getElementById('editarNotaModal').remove();
    }
}

async function mostrarInfo(legajoAlumno) {
    const docenteLocal = localStorage.getItem("tokenSesion");

    if (docenteLocal != "") {
        const docenteObjeto = JSON.parse(docenteLocal);
        try {
            const response = await fetch(`https://localhost:7146/v1/api/Alumno?legajo=${legajoAlumno}`, {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": docenteObjeto.response.tokenSesion,
                    "UsuarioId": docenteObjeto.response.usuarioId
                }
            });

            if (!response.ok) {
                throw new Error("Error al obtener la información del alumno: " + response.status);
            }

            const alumnoData = await response.json();

            // Llenar el modal con los datos del alumno
            document.getElementById('infoLegajo').textContent = alumnoData.legajo;
            document.getElementById('infoNombre').textContent = alumnoData.nombre;
            document.getElementById('infoApellido').textContent = alumnoData.apellido;
            document.getElementById('infoTipoDocumento').textContent = alumnoData.tipoDocumento;
            document.getElementById('infoNumeroDocumento').textContent = alumnoData.numeroDocumento;
            document.getElementById('infoDireccion').textContent = alumnoData.direccion;
            document.getElementById('infoLocalidad').textContent = alumnoData.localidad;
            document.getElementById('infoEstadoCivil').textContent = alumnoData.estadoCivil;
            document.getElementById('infoEstadoHabitacional').textContent = alumnoData.estadoHabitacional;
            document.getElementById('infoSituacionLaboral').textContent = alumnoData.situacionLaboral;
            document.getElementById('infoFechaNacimiento').textContent = alumnoData.fechaNacimiento;
            document.getElementById('infoGenero').textContent = alumnoData.genero;

            // Mostrar el modal
            $('#infoAlumnoModal').modal('show');
        } catch (error) {
            console.error("Error en la solicitud:", error);
            alert("Hubo un problema al obtener la información del alumno.");
        }
    }
}



$(document).ready(function () {
    $("#sidebarToggle").on("click", function () {
        $("#accordionSidebar").toggleClass("toggled");
    });
});

verificarSession();
ObtenerDocente();
ObtenerAdministracionDocente();
