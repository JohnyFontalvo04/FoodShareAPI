# FoodShare API

API REST para la gestión de donaciones y solicitudes de alimentos, desarrollada como proyecto final del Diplomado .NET.

El proyecto busca contribuir a la reducción del desperdicio alimentario, permitiendo gestionar donaciones, solicitudes y entregas de alimentos mediante una API REST, incorporando además un módulo de inteligencia artificial con Groq para analizar el nivel de riesgo de desperdicio de una donación y generar recomendaciones.

---

## Descripción del proyecto

FoodShare API es una aplicación backend desarrollada con ASP.NET Core Web API que permite administrar el flujo de donación y aprovechamiento de alimentos.

La solución contempla:

* Registro y autenticación de usuarios.
* Gestión de usuarios.
* Registro y administración de donaciones.
* Gestión de solicitudes de alimentos.
* Gestión de entregas.
* Autenticación mediante JWT.
* Persistencia de información mediante Entity Framework Core.
* Integración con Groq mediante HttpClient.
* Análisis de donaciones mediante inteligencia artificial.
* Documentación y pruebas mediante Swagger/OpenAPI.

El proyecto está relacionado con la problemática de reducción del desperdicio alimentario, correspondiente al ODS 2 — Hambre Cero.

---

# Objetivos

## Objetivo general

Desarrollar una API REST capaz de gestionar el proceso de donación, solicitud y entrega de alimentos, incorporando inteligencia artificial para analizar el riesgo de desperdicio alimentario.

## Objetivos específicos

1. Implementar una API REST utilizando ASP.NET Core.
2. Diseñar modelos y relaciones mediante Entity Framework Core.
3. Implementar operaciones CRUD para las entidades principales.
4. Implementar autenticación mediante JWT.
5. Utilizar DTOs para el intercambio de información.
6. Separar la lógica mediante controladores, servicios y repositorios.
7. Integrar la API de Groq mediante HttpClient.
8. Diseñar prompts orientados al análisis de desperdicio alimentario.
9. Documentar y probar los endpoints mediante Swagger/OpenAPI.
10. Proporcionar casos de prueba válidos e inválidos para la API.

---

# Problemática

El desperdicio de alimentos representa una problemática social que afecta el aprovechamiento de recursos alimentarios disponibles.

FoodShare propone una solución tecnológica orientada a facilitar el proceso mediante el cual:

```text
Donante
   |
   v
Donación
   |
   v
Solicitud
   |
   v
Aprobación
   |
   v
Entrega
```

Adicionalmente, el sistema incorpora inteligencia artificial para analizar una donación y determinar su nivel de riesgo de desperdicio.

---

# Inteligencia Artificial

FoodShare integra Groq API mediante un servicio especializado denominado `GroqService`.

La integración utiliza:

* HttpClient.
* API REST de Groq.
* Modelo configurable.
* Prompt engineering.
* Respuestas estructuradas en JSON.
* DTOs para entrada y salida.
* Manejo de errores HTTP.
* Validación de la respuesta generada.

## Flujo de análisis

```text
Cliente
   |
   | POST /api/IA/analizar
   v
IAController
   |
   v
IGroqService
   |
   v
GroqService
   |
   +-- Construcción del prompt
   +-- Serialización JSON
   +-- HttpClient
   +-- Solicitud a Groq API
          |
          v
       Groq API
          |
          v
     Respuesta JSON
          |
          v
     RespuestaIA
          |
          v
       Cliente
```

## Análisis realizado por la IA

La inteligencia artificial recibe información relacionada con:

* Nombre del alimento.
* Cantidad.
* Fecha de vencimiento.
* Descripción.

Y genera:

* Nivel de riesgo.
* Motivo.
* Recomendación.

Los niveles de riesgo definidos son:

```text
Bajo
Medio
Alto
```

---

# Tecnologías utilizadas

| Tecnología             | Versión | Uso                       |
| ---------------------- | ------- | ------------------------- |
| .NET SDK               | 8 LTS   | Plataforma de desarrollo  |
| C#                     | 12      | Lenguaje de programación  |
| ASP.NET Core           | 8       | Desarrollo de la API REST |
| Entity Framework Core  | 8.0.10  | ORM para acceso a datos   |
| SQL Server             | -       | Base de datos             |
| BCrypt.Net-Next        | 4.2.0   | Hash de contraseñas       |
| JWT Bearer             | 8.0.10  | Autenticación             |
| Groq API               | -       | Inteligencia artificial   |
| HttpClient             | -       | Comunicación con Groq     |
| Swagger / OpenAPI      | -       | Documentación y pruebas   |
| Swashbuckle.AspNetCore | 10.2.3  | Generación de Swagger     |
| Git                    | -       | Control de versiones      |
| GitHub                 | -       | Repositorio               |
| Visual Studio Code     | -       | Editor                    |

---

# Estructura del proyecto

```text
FoodShareAPI/
|
+-- Controladores/
|   +-- AuthController.cs
|   +-- DonacionesController.cs
|   +-- EntregasController.cs
|   +-- IAController.cs
|   +-- SolicitudesController.cs
|   +-- UsuariosController.cs
|
+-- DTOs/
|   +-- AnalizarDonacionDto.cs
|   +-- CrearDonacionDto.cs
|   +-- CrearSolicitudDto.cs
|   +-- CrearUsuarioDto.cs
|   +-- DonacionDto.cs
|   +-- EntregaDto.cs
|   +-- LoginDto.cs
|   +-- LoginRespuestaDto.cs
|   +-- RespuestaIA.cs
|   +-- SolicitudDto.cs
|   +-- UsuarioDto.cs
|
+-- Datos/
|   +-- FoodShareDbContext.cs
|
+-- Interfaces/
|   +-- IGroqService.cs
|   +-- IUsuarioService.cs
|   +-- IDonacionService.cs
|   +-- ISolicitudService.cs
|   +-- IEntregaService.cs
|   +-- ...
|
+-- Modelos/
|   +-- Usuario.cs
|   +-- Donacion.cs
|   +-- Solicitud.cs
|   +-- Entrega.cs
|
+-- Repositorios/
|   +-- UsuarioRepository.cs
|   +-- DonacionRepository.cs
|   +-- SolicitudRepository.cs
|   +-- EntregaRepository.cs
|
+-- Servicios/
|   +-- AuthService.cs
|   +-- UsuarioService.cs
|   +-- DonacionService.cs
|   +-- SolicitudService.cs
|   +-- EntregaService.cs
|   +-- GroqService.cs
|
+-- Migrations/
|
+-- Program.cs
+-- FoodShareAPI.csproj
+-- appsettings.json
+-- appsettings.Development.json
+-- README.md
```

---

# Modelo de datos

La aplicación trabaja con las siguientes entidades principales:

```text
Usuario
  |
  +----------------+
  |                |
  v                v
Donación        Solicitud
                  |
                  v
                Entrega
```

## Entidades

### Usuario

Representa a las personas registradas en el sistema.

### Donación

Representa los alimentos disponibles para ser donados.

### Solicitud

Representa la solicitud de una donación por parte de un usuario.

### Entrega

Representa la entrega asociada a una solicitud aprobada.

---

# Autenticación

La API implementa autenticación mediante JWT (JSON Web Token).

## Login

```http
POST /api/Auth/login
```

Permite autenticar un usuario y obtener la información necesaria para utilizar los endpoints protegidos.

Los endpoints que requieren autenticación utilizan el atributo:

```csharp
[Authorize]
```

---

# Endpoints

## Autenticación

| Método | Endpoint          | Descripción        |
| ------ | ----------------- | ------------------ |
| POST   | `/api/Auth/login` | Autenticar usuario |

---

## Usuarios

| Método | Endpoint             | Descripción                |
| ------ | -------------------- | -------------------------- |
| GET    | `/api/Usuarios`      | Obtener todos los usuarios |
| GET    | `/api/Usuarios/{id}` | Obtener usuario por ID     |
| POST   | `/api/Usuarios`      | Crear usuario              |
| PUT    | `/api/Usuarios/{id}` | Actualizar usuario         |
| DELETE | `/api/Usuarios/{id}` | Eliminar usuario           |

---

## Donaciones

| Método | Endpoint               | Descripción                  |
| ------ | ---------------------- | ---------------------------- |
| GET    | `/api/Donaciones`      | Obtener todas las donaciones |
| GET    | `/api/Donaciones/{id}` | Obtener donación por ID      |
| POST   | `/api/Donaciones`      | Crear donación               |
| PUT    | `/api/Donaciones/{id}` | Actualizar donación          |
| DELETE | `/api/Donaciones/{id}` | Eliminar donación            |

---

## Solicitudes

| Método | Endpoint                        | Descripción              |
| ------ | ------------------------------- | ------------------------ |
| GET    | `/api/Solicitudes`              | Obtener solicitudes      |
| GET    | `/api/Solicitudes/{id}`         | Obtener solicitud por ID |
| POST   | `/api/Solicitudes`              | Crear solicitud          |
| PUT    | `/api/Solicitudes/{id}`         | Actualizar solicitud     |
| DELETE | `/api/Solicitudes/{id}`         | Eliminar solicitud       |
| PUT    | `/api/Solicitudes/{id}/aprobar` | Aprobar solicitud        |

---

## Entregas

| Método | Endpoint             | Descripción            |
| ------ | -------------------- | ---------------------- |
| GET    | `/api/Entregas`      | Obtener entregas       |
| GET    | `/api/Entregas/{id}` | Obtener entrega por ID |
| POST   | `/api/Entregas`      | Crear entrega          |
| PUT    | `/api/Entregas/{id}` | Actualizar entrega     |
| DELETE | `/api/Entregas/{id}` | Eliminar entrega       |

---

## Inteligencia Artificial

| Método | Endpoint           | Descripción                       |
| ------ | ------------------ | --------------------------------- |
| POST   | `/api/IA/analizar` | Analizar una donación mediante IA |

### Ejemplo de solicitud

```json
{
  "nombreAlimento": "Leche",
  "cantidad": 20,
  "fechaVencimiento": "2026-08-10",
  "descripcion": "Leche próxima a vencer"
}
```

### Ejemplo de respuesta

```json
{
  "nivelRiesgo": "Alto",
  "motivo": "El alimento tiene una fecha de vencimiento cercana.",
  "recomendacion": "Priorizar su distribución entre los usuarios disponibles."
}
```

---

# Configuración

Antes de ejecutar el proyecto es necesario configurar los valores de:

* Cadena de conexión de SQL Server.
* Clave JWT.
* API Key de Groq.
* Modelo de Groq.

Ejemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "..."
  },
  "Jwt": {
    "Key": "...",
    "Issuer": "FoodShareAPI",
    "Audience": "FoodShareAPI"
  },
  "Groq": {
    "ApiKey": "...",
    "Model": "llama-3.1-8b-instant"
  }
}
```

Importante: las claves privadas y credenciales no deben publicarse en GitHub. Se recomienda utilizar User Secrets o variables de entorno.

---

# Instalación

## 1. Clonar el repositorio

```bash
git clone https://github.com/JohnyFontalvo04/FoodShareAPI.git
```

## 2. Entrar al proyecto

```bash
cd FoodShareAPI
```

## 3. Restaurar dependencias

```bash
dotnet restore
```

## 4. Compilar

```bash
dotnet build
```

El proyecto debe compilar correctamente antes de ejecutarse.

## 5. Aplicar migraciones

```bash
dotnet ef database update
```

## 6. Ejecutar

```bash
dotnet run
```

---

# Swagger

Una vez ejecutada la aplicación, acceder a Swagger desde la URL indicada por ASP.NET Core durante el inicio de la aplicación.

Swagger permite:

1. Consultar los endpoints disponibles.
2. Revisar los modelos de entrada.
3. Ejecutar solicitudes.
4. Visualizar respuestas HTTP.
5. Probar casos válidos.
6. Probar casos inválidos.
7. Probar la integración con inteligencia artificial.

---

# Pruebas y evidencias

Para cumplir con los requerimientos del proyecto final se deben documentar pruebas de cada endpoint.

Cada endpoint debe contar con:

* Caso válido.
* Caso inválido.
* Solicitud enviada.
* Código HTTP recibido.
* Respuesta obtenida.
* Captura de pantalla de Swagger.

## Ejemplo de caso válido

```text
Endpoint:
POST /api/IA/analizar

Resultado esperado:
200 OK
```

## Ejemplo de caso inválido

```text
Endpoint:
POST /api/IA/analizar

Datos inválidos:
Cantidad = 0

Resultado esperado:
400 Bad Request
```

Las evidencias deben incorporarse al repositorio y referenciarse desde este README.

---

# Códigos HTTP utilizados

| Código | Significado                     |
| ------ | ------------------------------- |
| 200    | Operación exitosa               |
| 201    | Recurso creado                  |
| 204    | Operación exitosa sin contenido |
| 400    | Solicitud inválida              |
| 401    | No autenticado                  |
| 404    | Recurso no encontrado           |
| 500    | Error interno del servidor      |
| 502    | Error de comunicación con Groq  |

---

# Arquitectura

El proyecto utiliza una separación por responsabilidades:

```text
Controller
    |
    v
Service
    |
    v
Repository
    |
    v
Entity Framework Core
    |
    v
SQL Server
```

La integración de inteligencia artificial utiliza:

```text
IAController
    |
    v
IGroqService
    |
    v
GroqService
    |
    v
HttpClient
    |
    v
Groq API
```

Esta organización permite separar:

* Entrada y salida HTTP.
* Lógica de negocio.
* Acceso a datos.
* Integración con servicios externos.
* Modelos de persistencia.
* DTOs.

---

# Requisitos del proyecto final

| Requisito                     | Estado                           |
| ----------------------------- | -------------------------------- |
| API REST funcional            | Implementado                     |
| CRUD completo                 | Implementado                     |
| Base de datos                 | Implementado                     |
| Entity Framework Core 8       | Implementado                     |
| DbContext                     | Implementado                     |
| Migraciones                   | Implementado                     |
| Integración con Groq          | Implementado                     |
| HttpClient                    | Implementado                     |
| Prompt engineering            | Implementado                     |
| Swagger/OpenAPI               | Implementado                     |
| DTOs                          | Implementado                     |
| Autenticación JWT             | Implementado                     |
| Seed Data                     | Pendiente de completar/verificar |
| Filtros                       | Pendiente de completar/verificar |
| Evidencias de casos válidos   | Pendiente de documentar          |
| Evidencias de casos inválidos | Pendiente de documentar          |

---

# Integrantes

* Daniel Angulo
* Johny Fontalvo
* Heinil Medina
* Brayan Meza

---

# Proyecto académico

Proyecto desarrollado como parte del Proyecto Final del Diplomado .NET.

**Problemática:** Reducción del desperdicio alimentario.

**ODS relacionado:** ODS 2 — Hambre Cero.

---

# Licencia

Proyecto desarrollado con fines académicos.
