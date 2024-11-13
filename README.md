# 
<h1 alaign="center">Proyecto Integrador Programacion II</h1>

![image](https://github.com/user-attachments/assets/cd9c6309-1a83-45c5-847c-b1f8f0974826)


### Integrantes
- **Mateo DellAcqua Castro** - Legajo: 412088
- **Gustavo Ezequiel Miarka** - Legajo: 412348
- **Paolo Pacheco** - Legajo: 412037
- **Máximo Agustín Rodríguez** - Legajo: 412299

## Descripción del Proyecto
Este proyecto forma parte del Trabajo Práctico Universitario (TPU) de la materia Programación II. Incluye la creación de un sistema de login y una interfaz para interactuar con la API del TPU, junto con una base de datos para almacenar la información del usuario y otros datos relevantes.

## Pasos de Instalación y Configuración

### Paso 1: Crear las bases de datos
1. Crear la base de datos del sistema de **login**.
2. Crear la base de datos correspondiente al **TPU**.

### Paso 2: Configurar la cadena de conexión
Modificar la cadena de conexión en ambos proyectos:
- **Proyecto Login**: Ajustar la cadena de conexión en los archivos de configuración correspondientes para apuntar a la base de datos del login.
- **Proyecto TPU**: Configurar la cadena de conexión para que se conecte a la base de datos del TPU.

### Paso 3: Crear usuarios desde Swagger
1. Ejecutar el proyecto **Login**.
2. Acceder a la interfaz de Swagger y crear al menos 2 usuarios para pruebas.

### Paso 3.1: Creación de Usuarios de Prueba en Swagger

Accede al endpoint del proyecto Login en Swagger para crear dos usuarios de prueba: uno como **Alumno** y otro como **Docente**.

- **URL del Endpoint**: [https://localhost:7258/api/v1/User](https://localhost:7258/api/v1/User)

#### Usuarios de Prueba

1. **Usuario Alumno**
   ```json
   {
     "userName": "1007",
     "email": "david@gmail.com",
     "password": "C1:david",
     "rol": 1,
     "compania": 1
   }
    ```

2. **Usuario Docente**
   ```json
    {
      "userName": "2001",
      "email": "Carlos_Mendez@gmail.com",
      "password": "C1:carlos",
      "rol": 2,
      "compania": 1
    }
    ```

#### Paso 4: Verificar estado de URLs
Confirmar que las URLs configuradas en ambas APIs están accesibles y funcionando correctamente.
- Url Login: https://localhost:7258/swagger/index.html
- Url TPU: https://localhost:7146/swagger/index.html

### Paso 5: Ejecutar las Web APIs
Iniciar las dos APIs:
- **API de Login**
- **API de TPU**

### Paso 6: Iniciar el Frontend
1. Ejecutar el proyecto de **Frontend**.
2. Iniciar sesión utilizando uno de los usuarios y contraseñas creados en el paso 3.

## Requisitos
- .NET Core / .NET Framework
- Swagger para probar las APIs
- Base de datos compatible (SQL Server)
- Entorno para levantar el frontend (Visual Studio Code).

