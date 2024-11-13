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

function logout() {
    localStorage.removeItem("tokenSesion");
    window.location.href = "/index.html";
}

async function cargarPerfilDocente() {
    var docenteLocal = localStorage.getItem("tokenSesion");
    var docenteObjeto = JSON.parse(docenteLocal);
    try {
        const response = await fetch('https://localhost:7146/v1/api/Docente?legajo=' + docenteObjeto.userName, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": docenteObjeto.response.tokenSesion,
                "UsuarioId": docenteObjeto.response.usuarioId
            }
        });
        if (!response.ok) {
            throw new Error("Error al obtener los datos del alumno");
        }
        const data = await response.json();
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
                <p><strong>Título Universitario:</strong> ${alumno.tituloUniversitario}</p>
            </div>
        </div>
    `;
}


$(document).ready(function () {
    $("#sidebarToggle").on("click", function () {
        $("#accordionSidebar").toggleClass("toggled");
    });
});



verificarSession();
ObtenerDocente();
cargarPerfilDocente();