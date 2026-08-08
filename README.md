# FoodShare API


## 1. Descripción general

FoodShare API es una API REST desarrollada en ASP.NET Core que expone endpoints básicos para la gestión de donaciones de alimentos. El proyecto tiene un enfoque académico y está orientado a demostrar la construcción, ejecución y prueba de servicios web utilizando buenas prácticas de organización.

La API permite realizar solicitudes HTTP para validar el funcionamiento de rutas, controladores y respuestas del servidor, utilizando Swagger como herramienta de documentación y prueba.

---

## 2. Objetivos del proyecto

1. Implementar una API REST utilizando ASP.NET Core.
2. Comprender el funcionamiento de los métodos HTTP (GET).
3. Validar respuestas HTTP mediante Swagger.
4. Estructurar un proyecto backend de forma clara y organizada.
5. Simular el comportamiento de endpoints s

---

## 3. Tecnologías utilizadas

- .NET 6 / .NET 7
- ASP.NET Core Web API
- Lenguaje C#
- Swagger (OpenAPI)
- Visual Studio Code

---

## 4. Estructura del proyecto


FoodShareAPI/
│
├── Controladores/ # Endpoints de la API (Controllers)
├── Modelos/ # Entidades del sistema
├── DTOs/ # Objetos de transferencia de datos
├── Repositorios/ # Acceso a datos
├── Servicios/ # Lógica de negocio
├── Interfaces/ # Contratos de servicios y repositorios
├── Fabricas/ # Creación de instancias
├── Datos/ # Configuración de base de datos
├── Migrations/ # Migraciones de Entity Framework
├── Database/ # Script SQL (FoodShareDB.sql)
├── Program.cs # Configuración principal
├── appsettings.json # Configuración de la aplicación


---

## 5. Requisitos previos

Para ejecutar el proyecto correctamente, se requiere:

1. Tener instalado .NET SDK (versión 6 o superior).
2. Tener instalado Visual Studio Code.
3. Contar con la extensión C# instalada en el editor.
4. Tener acceso a una terminal o consola.

---

## 6. Instalación del proyecto

Sigue los siguientes pasos:

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/JohnyFontalvo04/FoodShareAPI.git

Acceder al directorio del proyecto:

cd FoodShareAPI

Restaurar dependencias:

dotnet restore
7. Ejecución de la aplicación

Ejecutar el siguiente comando en la terminal:

dotnet run
Verificar que la aplicación se haya iniciado correctamente.

Acceder desde el navegador a la siguiente dirección:

http://localhost:5172

Acceder a Swagger para probar la API:

http://localhost:5172/swagger
8. Uso de Swagger

Swagger permite interactuar con la API sin necesidad de herramientas externas.

Pasos para utilizarlo:

Abrir la URL /swagger en el navegador.
Identificar los endpoints disponibles.
Seleccionar un endpoint.
Hacer clic en "Try it out".
Ejecutar la solicitud.
Analizar la respuesta generada por el servidor.

###7. Endopig implementados
###  Autenticación

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| POST | /api/auth/login | Permite autenticar un usuario en el sistema |
| POST | /api/auth/register | Permite registrar un nuevo usuario |

---

###  Usuarios

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | /api/usuario | Obtener todos los usuarios |
| GET | /api/usuario/{id} | Obtener un usuario por ID |
| POST | /api/usuario | Crear un nuevo usuario |
| PUT | /api/usuario/{id} | Actualizar un usuario existente |
| DELETE | /api/usuario/{id} | Eliminar un usuario |

---

###  Donaciones

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | /api/donacion | Obtener todas las donaciones |
| GET | /api/donacion/{id} | Obtener una donación por ID |
| POST | /api/donacion | Registrar una nueva donación |
| PUT | /api/donacion/{id} | Actualizar una donación |
| DELETE | /api/donacion/{id} | Eliminar una donación |

---

###  Solicitudes

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | /api/solicitud | Obtener todas las solicitudes |
| GET | /api/solicitud/{id} | Obtener una solicitud por ID |
| POST | /api/solicitud | Crear una nueva solicitud |
| PUT | /api/solicitud/{id} | Actualizar una solicitud |
| DELETE | /api/solicitud/{id} | Eliminar una solicitud |

---

### Entregas

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | /api/entrega | Obtener todas las entregas |
| GET | /api/entrega/{id} | Obtener una entrega por ID |
| POST | /api/entrega | Registrar una entrega |
| PUT | /api/entrega/{id} | Actualizar una entrega |
| DELETE | /api/entrega/{id} | Eliminar una entrega |

9.Endpoints  utilizados
9.1 Obtener todos los registros
Método: GET

Ruta:

/api/Donaciones
9.2 Obtener un registro por identificador
Método: GET

Ruta:

/api/Donaciones/{id}

Resultados de ejecución

10.1 Caso válido
Se realiza una petición GET a /api/Donaciones.
El servidor procesa la solicitud correctamente.
Se obtiene como resultado:
Código HTTP: 200 OK
10.2 Caso de prueba con parámetro
Se realiza una petición GET a /api/Donaciones/{id}.
El servidor responde a la solicitud.
El resultado depende de la implementación actual del controlador.

Evidencias de funcionamiento

Durante las pruebas realizadas se verificó:

La API inicia correctamente sin errores.
Swagger se genera automáticamente.
Los endpoints pueden ejecutarse desde el navegador.
El servidor responde con código HTTP 200 OK.

Autores

Daniel Angulo
Johny Fontalvo
Heinil Medina
Brayan Meza


. Licencia

Este proyecto ha sido desarrollado con fines académicos sobre el proyecto final del Diplomado .NET
