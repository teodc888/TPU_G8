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

async function obtenerMateriasDocente() {
    var docenteLocal = localStorage.getItem("tokenSesion");

    if (docenteLocal != "") {
        var docenteObjeto = JSON.parse(docenteLocal);

        try {
            const response = await fetch("https://localhost:7146/v1/api/Docente/materia?legajo=" + docenteObjeto.userName, {
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

            // Seleccionamos el cuerpo de la tabla usando el ID
            const tbody = document.querySelector("#materiasTable tbody");
            tbody.innerHTML = ""; // Limpiamos el contenido previo en la tabla

            data.forEach(materia => {
                const fila = document.createElement("tr");

                fila.innerHTML = `
                    <td>${materia.legajo}</td>
                    <td>${materia.materia}</td>
                    <td>${materia.carrera}</td>
                    <td>${materia.anioPlan}</td>
                `;

                tbody.appendChild(fila);
            });
        } catch (error) {
            console.error("Error en la solicitud:", error);
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
obtenerMateriasDocente();