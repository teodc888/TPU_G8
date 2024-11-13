document.getElementById("loginForm").addEventListener("submit", async function (event) {
    event.preventDefault(); // Evita que se recargue la página

    // Obtener valores de los campos de entrada
    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;

    // Crear el cuerpo de la solicitud
    const requestBody = {
        userName: username,
        password: password
    };

    try {

        const response = await fetch("https://localhost:7258/api/v1/Login/Login", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(requestBody)
        });

        // Verificar si la respuesta es exitosa
        if (response.ok) {
            const data = await response.json();

            // Guardar el token de sesión en localStorage si la respuesta es válida
            if (data.response && data.response.tokenSesion) {
                localStorage.setItem("tokenSesion", JSON.stringify(data));

                if (data.rol == "Alumno") {
                    window.location.href = "../alumno/alumno-index.html"
                }
                if (data.rol == "Docente") {
                    window.location.href = "/docente/docente-index.html"
                }

            } else {
               alert("Contraseña incorrecta")
            }
        } else {
            const resultadoModal = new bootstrap.Modal(document.getElementById("errorModal"));
        resultadoModal.show();

        }
    } catch (error) {
        alert("Contraseña incorrecta")
 
    }
});

// Función para mostrar u ocultar la contraseña
function togglePassword() {
    const passwordField = document.getElementById("password");
    const type = passwordField.getAttribute("type") === "password" ? "text" : "password";
    passwordField.setAttribute("type", type);
}


function logout() {
    console.log("hola")
    localStorage.removeItem('tokenSesion');
    window.location.href = "/index.html"
}
