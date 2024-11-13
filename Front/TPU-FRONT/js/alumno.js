function verificarUsuario() {
    var alumnoLocal = localStorage.getItem("tokenSesion");

    if (alumnoLocal == "") {
        window.location.href = "/index.html";
    }

    var alumnoObjeto = JSON.parse(alumnoLocal);

    if (alumnoObjeto.rol != "Alumno") {
        window.location.href = "/index.html";
     
    }
}

async function ObtenerAlumno() {
    var alumnoLocal = localStorage.getItem("tokenSesion");
    
    if (alumnoLocal != "") {
        var alumnoObjeto = JSON.parse(alumnoLocal);

        fetch("https://localhost:7146/v1/api/Alumno?legajo=" + alumnoObjeto.userName, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": alumnoObjeto.response.tokenSesion,
                "UsuarioId": alumnoObjeto.response.usuarioId
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
                document.getElementById('nombreAlumno').innerHTML = data.nombre + ' ' + data.apellido;
            })
            .catch(error => {
                console.error("Error en la solicitud:", error);
            });
    }else{
        window.location.href = "/index.html";
    }
}

// ----------------------------------------------------------------

async function CompletarForm() {
    var alumnoLocal = localStorage.getItem("tokenSesion");

    if (alumnoLocal != "") {
        var alumnoObjeto = JSON.parse(alumnoLocal);

        fetch("https://localhost:7146/v1/api/Alumno?legajo=" + alumnoObjeto.userName, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": alumnoObjeto.response.tokenSesion,
                "UsuarioId": alumnoObjeto.response.usuarioId
            }
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error("Error en la respuesta: " + response.status);
                }
                return response.json();
            })
            .then(data => {
                document.getElementById('legajo').value = data.legajo;
                document.getElementById('nombre').value = data.nombre;
                document.getElementById('apellido').value = data.apellido;

            })
            .catch(error => {
                console.error("Error en la solicitud:", error);
            });
    }
}


async function ObtenerInfoAlumno() {
    var alumnoLocal = localStorage.getItem("tokenSesion");

    if (alumnoLocal != "") {
        var alumnoObjeto = JSON.parse(alumnoLocal);

        fetch("https://localhost:7146/v1/api/Alumno/info?legajo=" + alumnoObjeto.userName, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": alumnoObjeto.response.tokenSesion,
                "UsuarioId": alumnoObjeto.response.usuarioId
            }
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error("Error en la respuesta: " + response.status);
                }
                return response.json();
            })
            .then(data => {
                // Seleccionamos el contenedor donde se agregarán las tarjetas
                const contenedorTarjetas = document.getElementById("contenedorTarjetas");
                contenedorTarjetas.innerHTML = ""; // Limpiamos el contenido anterior

                // Recorremos cada objeto de data y generamos una tarjeta
                data.forEach(alumno => {
                    const tarjeta = document.createElement("div");
                    tarjeta.className = "col-xl-3 col-md-6 mb-4";
                    tarjeta.innerHTML = `
                    <div class="card border-left-primary shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                        ${alumno.carrera}</div>
                                    <div class="h5 mb-0 font-weight-bold text-gray-800">${alumno.materia}</div>
                                    <div class="text-xs mt-1">Tipo: ${alumno.tipoMateria}</div>
                                    <div class="text-xs">Fecha Inscripción Materia: ${alumno.fechaInscripcionMateria}</div>
                                    <div class="text-xs">Fecha Inscripción Cursado: ${alumno.fechaInscripcionCursado}</div>
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-calendar fa-2x text-gray-300"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                `;

                    // Agregamos la tarjeta al contenedor
                    contenedorTarjetas.appendChild(tarjeta);
                });
            })
            .catch(error => {
                console.error("Error en la solicitud:", error);
            });
    }
}

async function ObtenerNotasAlumno() {
    var alumnoLocal = localStorage.getItem("tokenSesion");

    if (alumnoLocal != "") {
        var alumnoObjeto = JSON.parse(alumnoLocal);

        fetch("https://localhost:7146/v1/api/Alumno/info/notas?legajo=" + alumnoObjeto.userName, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": alumnoObjeto.response.tokenSesion,
                "UsuarioId": alumnoObjeto.response.usuarioId
            }
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error("Error en la respuesta: " + response.status);
                }
                return response.json();
            })
            .then(data => {
                // Seleccionamos el cuerpo de la tabla
                const tbody = document.querySelector("#dataTable tbody");
                tbody.innerHTML = ""; // Limpiamos el contenido previo en la tabla

                // Recorremos el array de datos para agregar filas
                data.forEach(alumno => {
                    const fila = document.createElement("tr");
                    fila.innerHTML = `
                    <td>${alumno.legajo}</td>
                    <td>${alumno.curso}</td>
                    <td>${alumno.estado}</td>
                    <td>${alumno.materia}</td>
                    <td>${alumno.nota}</td>
                    <td>${alumno.fechaCursado}</td>
                `;

                    // Añadimos la fila al cuerpo de la tabla
                    tbody.appendChild(fila);
                });
            })
            .catch(error => {
                console.error("Error en la solicitud:", error);
            });
    }
}

async function CargarSelect() {
    var alumnoLocal = localStorage.getItem("tokenSesion");

    if (alumnoLocal != "") {
        var alumnoObjeto = JSON.parse(alumnoLocal);

        fetch("https://localhost:7146/v1/api/Alumno/info/notas?legajo=" + alumnoObjeto.userName, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": alumnoObjeto.response.tokenSesion,
                "UsuarioId": alumnoObjeto.response.usuarioId
            }
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error("Error en la respuesta: " + response.status);
                }
                return response.json();
            })
            .then(data => {
                const selectMateria = document.getElementById('materia');

                // Limpiar el select y agregar la opción inicial
                selectMateria.innerHTML = '<option value="">Seleccione una materia</option>';


                data.forEach(materia => {

                    const option = document.createElement('option');
                    if (materia.estado == 'REGULAR' || materia.estado == 'PROMOCIONAL') {
                        option.value = materia.id; // Usar el ID de la materia como valor
                        option.textContent = materia.materia// Mostrar el nombre de la materia
                        selectMateria.appendChild(option);
                    }

                });
            })
            .catch(error => {
                console.error("Error en la solicitud:", error);
            });
    }
}

async function ObtenerExamenesFinales() {
    var alumnoLocal = localStorage.getItem("tokenSesion");

    if (alumnoLocal != "") {
        var alumnoObjeto = JSON.parse(alumnoLocal);

        fetch(`https://localhost:7146/v1/api/Alumno/examen/final?legajo=${alumnoObjeto.userName}`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": alumnoObjeto.response.tokenSesion,
                "UsuarioId": alumnoObjeto.response.usuarioId
            }
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error("Error en la respuesta: " + response.status);
                }
                return response.json();
            })
            .then(data => {
                // Seleccionamos el contenedor donde se agregarán las tarjetas
                const contenedorTarjetas = document.getElementById("contenedorFinal");
                contenedorTarjetas.innerHTML = ""; // Limpiamos el contenido anterior

                // Recorremos cada objeto de data y generamos una tarjeta
                data.forEach(examen => {
                    const tarjeta = document.createElement("div");
                    tarjeta.className = "col-lg-4 col-md-6 mb-4"; // Ajustamos el tamaño de la tarjeta
                    tarjeta.innerHTML = `
                    <div class="card shadow border-left-primary h-100">
                        <div class="card-header bg-primary text-white text-center">
                            <h5 class="m-0">${examen.nombreMateria}</h5>
                        </div>
                        <div class="card-body">
                            <h6 class="text-gray-800">Fecha del Examen:</h6>
                            <p class="h5 font-weight-bold">${new Date(examen.fecha).toLocaleDateString()}</p>
                        </div>
                    </div>
                `;

                    // Agregamos la tarjeta al contenedor
                    contenedorTarjetas.appendChild(tarjeta);
                });
            })
            .catch(error => {
                console.error("Error en la solicitud:", error);
            });
    }
}

async function inscribirAlumno(event) {
    var alumnoLocal = localStorage.getItem("tokenSesion");

    if (alumnoLocal != "") {
        var alumnoObjeto = JSON.parse(alumnoLocal);
        event.preventDefault(); // Evita el envío del formulario por defecto

        // Obtiene los valores del formulario
        const legajo = document.getElementById("legajo").value;
        const selectMateria = document.getElementById('materia');
        const nombreMateria = selectMateria.options[selectMateria.selectedIndex].text;
        const fechaInscripcion = document.getElementById("fecha").value;

        // Construye el cuerpo de la solicitud
        const body = {
            legajo: parseInt(legajo), // Convierte legajo a número
            nombreMateria: nombreMateria,
            fechaInscripcion: new Date(fechaInscripcion).toISOString() // Formatea la fecha
        };
        try {
            const response = await fetch("https://localhost:7146/v1/api/Alumno/inscribir", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": alumnoObjeto.response.tokenSesion,
                    "UsuarioId": alumnoObjeto.response.usuarioId
                },
                body: JSON.stringify(body) // Convierte el cuerpo a JSON
            });

            if (!response.ok) {
                throw new Error("Error en la inscripción: " + response.status);
            }

            // Muestra el modal de confirmación si la inscripción es exitosa
            $('#confirmacionModal').modal('show');
        } catch (error) {
            console.error("Error en la solicitud:", error);
            alert("Ocurrió un error al inscribirse. Intente nuevamente.");
        }
    }
}

async function cargarPerfilAlumno() {
    var alumnoLocal = localStorage.getItem("tokenSesion");
    var alumnoObjeto = JSON.parse(alumnoLocal);
    try {
        const response = await fetch('https://localhost:7146/v1/api/Alumno?legajo=' + alumnoObjeto.userName, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": alumnoObjeto.response.tokenSesion,
                "UsuarioId": alumnoObjeto.response.usuarioId
            },
            body: JSON.stringify(body) // Convierte el cuerpo a JSON
        });
        console.log(response)
        if (!response.ok) {

            throw new Error("Error al obtener los datos del alumno");
        }
        const data = await response.json();
        console.log(data)
        mostrarPerfil(data);
    } catch (error) {
        console.error("Error:", error);
    }
}

function mostrarPerfil(alumno) {
    const cardPerfil = document.getElementById("cardPerfil");
    cardPerfil.innerHTML = `
        <div class="card shadow-lg p-3 mb-5 bg-white rounded" style="width: 24rem;">
            <div class="card-body">
                <h4 class="card-title text-center text-primary">${alumno.nombre} ${alumno.apellido}</h4>
                <h6 class="card-subtitle mb-2 text-muted text-center">Legajo: ${alumno.legajo}</h6>
                <hr>
                <p><strong>Documento:</strong> ${alumno.tipoDocumento} ${alumno.numeroDocumento}</p>
                <p><strong>Fecha de Nacimiento:</strong> ${new Date(alumno.fechaNacimiento).toLocaleDateString()}</p>
                <p><strong>Dirección:</strong> ${alumno.direccion}</p>
                <p><strong>Localidad:</strong> ${alumno.localidad}</p>
                <p><strong>Estado Civil:</strong> ${alumno.estadoCivil}</p>
                <p><strong>Estado Habitacional:</strong> ${alumno.estadoHabitacional}</p>
                <p><strong>Situación Laboral:</strong> ${alumno.situacionLaboral}</p>
                <p><strong>Género:</strong> ${alumno.genero}</p>
            </div>
        </div>
    `;
}

cargarPerfilAlumno()

ObtenerExamenesFinales();

ObtenerNotasAlumno();

ObtenerInfoAlumno();

ObtenerAlumno();

CompletarForm();

CargarSelect();

verificarUsuario();