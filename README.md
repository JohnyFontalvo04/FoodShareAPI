# FoodShare API

> API REST para la gestión de donaciones, solicitudes y entregas de alimentos, con integración de Inteligencia Artificial mediante Groq.

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet\&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-14.0-239120?logo=csharp\&logoColor=white)](https://learn.microsoft.com/dotnet/csharp/)
[![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-10.0-512BD4)](https://learn.microsoft.com/ef/core/)
[![SQLite](https://img.shields.io/badge/SQLite-Database-003B57?logo=sqlite\&logoColor=white)](https://www.sqlite.org/)
[![Swagger](https://img.shields.io/badge/Swagger-OpenAPI-85EA2D?logo=swagger\&logoColor=black)](https://swagger.io/)
[![JWT](https://img.shields.io/badge/Auth-JWT-black?logo=jsonwebtokens)](https://jwt.io/)
[![Groq](https://img.shields.io/badge/AI-Groq-orange)](https://groq.com/)

---

## Tabla de contenidos

* [Descripción](#descripción)
* [Problemática](#problemática)
* [Objetivos](#objetivos)
* [Funcionalidades](#funcionalidades)
* [Tecnologías](#tecnologías)
* [Arquitectura](#arquitectura)
* [Estructura del proyecto](#estructura-del-proyecto)
* [Requisitos previos](#requisitos-previos)
* [Instalación](#instalación)
* [Configuración](#configuración)
* [Configuración de User Secrets](#configuración-de-user-secrets)
* [Base de datos](#base-de-datos)
* [Ejecución](#ejecución)
* [Swagger / OpenAPI](#swagger--openapi)
* [Autenticación JWT](#autenticación-jwt)
* [Endpoints](#endpoints)
* [Integración con Inteligencia Artificial](#integración-con-inteligencia-artificial)
* [Pruebas](#pruebas)
* [Códigos HTTP](#códigos-http)
* [Flujo de funcionamiento](#flujo-de-funcionamiento)
* [Seguridad](#seguridad)
* [Solución de problemas](#solución-de-problemas)
* [Estado del proyecto](#estado-del-proyecto)
* [Autores](#autores)

---

## Descripción

**FoodShare API** es una aplicación backend desarrollada con **ASP.NET Core Web API**, cuyo propósito es facilitar la gestión de alimentos disponibles para donación.

La API permite administrar el ciclo completo de:

1. Registro de usuarios.
2. Registro de donaciones.
3. Solicitud de alimentos.
4. Aprobación de solicitudes.
5. Gestión de entregas.
6. Análisis de donaciones mediante Inteligencia Artificial.

La aplicación incorpora un módulo de Inteligencia Artificial mediante la API de **Groq**, capaz de analizar una donación y determinar su nivel de riesgo de desperdicio, proporcionando un motivo y una recomendación.

El proyecto fue desarrollado como proyecto final del Diplomado .NET.

---

## Problemática

El desperdicio de alimentos representa una problemática social y ambiental. Una cantidad considerable de alimentos que todavía pueden ser aprovechados termina siendo desperdiciada debido a problemas de distribución, comunicación y gestión.

FoodShare propone una solución tecnológica orientada a facilitar la gestión de alimentos disponibles para donación.

El sistema permite gestionar:

* Alimentos disponibles.
* Donaciones.
* Solicitudes.
* Aprobaciones.
* Entregas.
* Análisis de riesgo mediante Inteligencia Artificial.

---

## Objetivos

### Objetivo general

Desarrollar una API REST capaz de gestionar el proceso de donación, solicitud y entrega de alimentos, incorporando Inteligencia Artificial para analizar el riesgo de desperdicio alimentario.

### Objetivos específicos

1. Implementar una API REST utilizando ASP.NET Core.
2. Implementar operaciones CRUD.
3. Utilizar Entity Framework Core para la persistencia de datos.
4. Utilizar SQLite como sistema de base de datos.
5. Implementar autenticación mediante JWT.
6. Utilizar DTOs para el intercambio de información.
7. Separar responsabilidades mediante controladores, servicios y repositorios.
8. Integrar la API de Groq mediante `HttpClient`.
9. Implementar prompt engineering para el análisis de donaciones.
10. Documentar y probar los endpoints mediante Swagger/OpenAPI.

---

## Funcionalidades

### Usuarios

* Crear usuarios.
* Consultar usuarios.
* Consultar usuario por ID.
* Actualizar usuarios.
* Eliminar usuarios.

### Autenticación

* Inicio de sesión.
* Generación de tokens JWT.
* Protección de endpoints mediante `[Authorize]`.
* Validación del token.

### Donaciones

* Crear donaciones.
* Consultar donaciones.
* Consultar una donación por ID.
* Actualizar donaciones.
* Eliminar donaciones.

### Solicitudes

* Crear solicitudes.
* Consultar solicitudes.
* Consultar solicitud por ID.
* Actualizar solicitudes.
* Eliminar solicitudes.
* Aprobar solicitudes.

### Entregas

* Crear entregas.
* Consultar entregas.
* Consultar entrega por ID.
* Actualizar entregas.
* Eliminar entregas.

### Inteligencia Artificial

* Analizar donaciones.
* Determinar nivel de riesgo.
* Generar motivo del análisis.
* Generar recomendación.
* Comunicación con Groq mediante HTTP.

---

## Tecnologías

| Tecnología               | Uso                       |
| ------------------------ | ------------------------- |
| .NET 10                  | Plataforma de desarrollo  |
| C#                       | Lenguaje de programación  |
| ASP.NET Core Web API     | Desarrollo de la API REST |
| Entity Framework Core 10 | ORM y acceso a datos      |
| SQLite                   | Base de datos             |
| BCrypt.Net-Next          | Hash de contraseñas       |
| JWT Bearer               | Autenticación             |
| Swagger / OpenAPI        | Documentación y pruebas   |
| Swashbuckle.AspNetCore   | Generación de Swagger     |
| HttpClient               | Comunicación con Groq     |
| Groq API                 | Inteligencia Artificial   |
| Git / GitHub             | Control de versiones      |

---

## Arquitectura

El proyecto utiliza una arquitectura basada en separación de responsabilidades.

```text
                    Cliente
                       |
                       v
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
                    SQLite
```

Esta estructura permite separar:

* Recepción de solicitudes HTTP.
* Lógica de negocio.
* Acceso a datos.
* Persistencia.
* Modelos.
* Transferencia de información.

### Arquitectura de Inteligencia Artificial

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
   |
   +-- Serialización JSON
   |
   +-- HttpClient
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

---

## Estructura del proyecto

```text
FoodShareAPI/
│
├── Controladores/
│   ├── AuthController.cs
│   ├── DonacionesController.cs
│   ├── EntregasController.cs
│   ├── IAController.cs
│   ├── SolicitudesController.cs
│   └── UsuariosController.cs
│
├── DTOs/
│   ├── AnalizarDonacionDto.cs
│   ├── CrearDonacionDto.cs
│   ├── CrearSolicitudDto.cs
│   ├── CrearUsuarioDto.cs
│   ├── DonacionDto.cs
│   ├── EntregaDto.cs
│   ├── LoginDto.cs
│   ├── LoginRespuestaDto.cs
│   ├── RespuestaIA.cs
│   ├── SolicitudDto.cs
│   └── UsuarioDto.cs
│
├── Datos/
│   └── FoodShareDbContext.cs
│
├── Interfaces/
│   ├── IGroqService.cs
│   ├── IUsuarioService.cs
│   ├── IDonacionService.cs
│   ├── ISolicitudService.cs
│   └── IEntregaService.cs
│
├── Migrations/
│
├── Modelos/
│   ├── Usuario.cs
│   ├── Donacion.cs
│   ├── Solicitud.cs
│   └── Entrega.cs
│
├── Repositorios/
│   ├── UsuarioRepository.cs
│   ├── DonacionRepository.cs
│   ├── SolicitudRepository.cs
│   └── EntregaRepository.cs
│
├── Servicios/
│   ├── AuthService.cs
│   ├── UsuarioService.cs
│   ├── DonacionService.cs
│   ├── SolicitudService.cs
│   ├── EntregaService.cs
│   └── GroqService.cs
│
├── Properties/
│   └── launchSettings.json
│
├── FoodShareAPI.csproj
├── FoodShareAPI.http
├── FoodShareDB.db
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
└── README.md
```

---

## Requisitos previos

Antes de instalar el proyecto se requiere:

### .NET SDK

El proyecto utiliza:

```text
.NET 10.0
```

Verificar la instalación:

```bash
dotnet --version
```

También puede utilizarse:

```bash
dotnet --info
```

### Git

Verificar:

```bash
git --version
```

### API Key de Groq

Para utilizar la funcionalidad de Inteligencia Artificial se necesita una API Key válida de Groq.

La API Key no debe publicarse en el repositorio.

---

## Instalación

### 1. Clonar el repositorio

```bash
git clone https://github.com/JohnyFontalvo04/FoodShareAPI.git
```

### 2. Acceder al proyecto

```bash
cd FoodShareAPI
```

### 3. Restaurar dependencias

```bash
dotnet restore
```

### 4. Compilar

```bash
dotnet build
```

Si la compilación es correcta aparecerá:

```text
Build succeeded.
```

---

## Configuración

La aplicación utiliza archivos de configuración de ASP.NET Core junto con **.NET User Secrets** para información sensible.

La configuración principal se encuentra en:

```text
appsettings.json
appsettings.Development.json
```

Los datos sensibles deben almacenarse mediante User Secrets.

---

## Configuración de User Secrets

El proyecto cuenta con un `UserSecretsId` configurado en el archivo:

```text
FoodShareAPI.csproj
```

Por esta razón, no es necesario crear manualmente un identificador.

### Verificar los secretos

```bash
dotnet user-secrets list
```

### Configurar API Key de Groq

```bash
dotnet user-secrets set "Groq:ApiKey" "TU_API_KEY_DE_GROQ"
```

Ejemplo:

```bash
dotnet user-secrets set "Groq:ApiKey" "gsk_xxxxxxxxxxxxxxxxx"
```

La clave anterior es solamente un ejemplo.

### Configurar el modelo

```bash
dotnet user-secrets set "Groq:Model" "llama-3.1-8b-instant"
```

### Configurar la clave JWT

```bash
dotnet user-secrets set "Jwt:Key" "TU_CLAVE_JWT_SEGURA"
```

Ejemplo:

```bash
dotnet user-secrets set "Jwt:Key" "FoodShareAPI_Clave_JWT_2026_Segura"
```

### Verificar configuración

```bash
dotnet user-secrets list
```

Se deberían visualizar las claves configuradas.

### Eliminar una clave

```bash
dotnet user-secrets remove "Groq:ApiKey"
```

### Eliminar todos los secretos

```bash
dotnet user-secrets clear
```

---

## Base de datos

FoodShare API utiliza **SQLite**.

La cadena de conexión utiliza el archivo:

```text
FoodShareDB.db
```

La aplicación utiliza Entity Framework Core para administrar la persistencia.

No es necesario instalar SQL Server para ejecutar el proyecto.

---

## Migraciones

Para trabajar con las migraciones de Entity Framework Core se necesita `dotnet-ef`.

### Instalar

```bash
dotnet tool install --global dotnet-ef
```

Si ya está instalado:

```bash
dotnet tool update --global dotnet-ef
```

### Verificar

```bash
dotnet ef --version
```

### Aplicar migraciones

```bash
dotnet ef database update
```

### Crear una migración

Después de modificar un modelo:

```bash
dotnet ef migrations add NombreDeLaMigracion
```

Después:

```bash
dotnet ef database update
```

---

## Ejecución

Para iniciar la API:

```bash
dotnet run
```

El proyecto se ejecuta utilizando los perfiles configurados en:

```text
Properties/launchSettings.json
```

Las direcciones configuradas actualmente son:

```text
HTTP:
http://localhost:5172

HTTPS:
https://localhost:7003
```

---

## Swagger / OpenAPI

Una vez iniciada la aplicación, se puede acceder a Swagger desde:

```text
https://localhost:7003/swagger
```

o:

```text
http://localhost:5172/swagger
```

Swagger permite:

* Consultar los endpoints.
* Revisar los parámetros.
* Visualizar los DTOs.
* Ejecutar solicitudes.
* Revisar respuestas.
* Probar casos válidos.
* Probar casos inválidos.
* Autenticar mediante JWT.
* Probar la integración con Inteligencia Artificial.

---

## Autenticación JWT

El sistema utiliza JSON Web Token para autenticar a los usuarios.

El proceso es:

```text
Credenciales
     |
     v
AuthController
     |
     v
AuthService
     |
     v
Validación del usuario
     |
     v
Generación del JWT
     |
     v
Cliente
```

El endpoint de autenticación es:

```http
POST /api/Auth/login
```

Los endpoints protegidos utilizan:

```csharp
[Authorize]
```

### Uso desde Swagger

1. Ejecutar el endpoint de login.
2. Obtener el token JWT.
3. Seleccionar el botón `Authorize`.
4. Introducir el token.
5. Ejecutar los endpoints protegidos.

El formato utilizado es:

```text
Bearer TU_TOKEN
```

---

# Endpoints

## Auth

| Método | Endpoint          | Descripción        |
| ------ | ----------------- | ------------------ |
| POST   | `/api/Auth/login` | Autenticar usuario |

## Usuarios

| Método | Endpoint             | Descripción                |
| ------ | -------------------- | -------------------------- |
| GET    | `/api/Usuarios`      | Obtener todos los usuarios |
| GET    | `/api/Usuarios/{id}` | Obtener usuario por ID     |
| POST   | `/api/Usuarios`      | Crear usuario              |
| PUT    | `/api/Usuarios/{id}` | Actualizar usuario         |
| DELETE | `/api/Usuarios/{id}` | Eliminar usuario           |

## Donaciones

| Método | Endpoint               | Descripción                  |
| ------ | ---------------------- | ---------------------------- |
| GET    | `/api/Donaciones`      | Obtener todas las donaciones |
| GET    | `/api/Donaciones/{id}` | Obtener donación por ID      |
| POST   | `/api/Donaciones`      | Crear donación               |
| PUT    | `/api/Donaciones/{id}` | Actualizar donación          |
| DELETE | `/api/Donaciones/{id}` | Eliminar donación            |

## Solicitudes

| Método | Endpoint                        | Descripción              |
| ------ | ------------------------------- | ------------------------ |
| GET    | `/api/Solicitudes`              | Obtener solicitudes      |
| GET    | `/api/Solicitudes/{id}`         | Obtener solicitud por ID |
| POST   | `/api/Solicitudes`              | Crear solicitud          |
| PUT    | `/api/Solicitudes/{id}`         | Actualizar solicitud     |
| DELETE | `/api/Solicitudes/{id}`         | Eliminar solicitud       |
| PUT    | `/api/Solicitudes/{id}/aprobar` | Aprobar solicitud        |

## Entregas

| Método | Endpoint             | Descripción            |
| ------ | -------------------- | ---------------------- |
| GET    | `/api/Entregas`      | Obtener entregas       |
| GET    | `/api/Entregas/{id}` | Obtener entrega por ID |
| POST   | `/api/Entregas`      | Crear entrega          |
| PUT    | `/api/Entregas/{id}` | Actualizar entrega     |
| DELETE | `/api/Entregas/{id}` | Eliminar entrega       |

## Inteligencia Artificial

| Método | Endpoint           | Descripción                       |
| ------ | ------------------ | --------------------------------- |
| POST   | `/api/IA/analizar` | Analizar una donación mediante IA |

---

## Integración con Inteligencia Artificial

FoodShare utiliza **Groq API** para analizar las donaciones.

El endpoint es:

```http
POST /api/IA/analizar
```

### Solicitud

```json
{
  "nombreAlimento": "Leche",
  "cantidad": 20,
  "fechaVencimiento": "2026-08-10",
  "descripcion": "Leche próxima a vencer"
}
```

### Proceso

La solicitud sigue el siguiente flujo:

```text
IAController
     |
     v
IGroqService
     |
     v
GroqService
     |
     +-- Construcción del prompt
     |
     +-- Serialización JSON
     |
     +-- HttpClient
     |
     v
Groq API
     |
     v
Respuesta de IA
     |
     v
RespuestaIA
```

### Respuesta

La IA devuelve información relacionada con:

* Nivel de riesgo.
* Motivo.
* Recomendación.

Ejemplo:

```json
{
  "nivelRiesgo": "Alto",
  "motivo": "El alimento tiene una fecha de vencimiento cercana.",
  "recomendacion": "Priorizar su distribución."
}
```

Los niveles de riesgo utilizados son:

```text
BAJO
MEDIO
ALTO
```

---

## Prueba de Inteligencia Artificial mediante Swagger

Para realizar una prueba:

1. Ejecutar el proyecto.

```bash
dotnet run
```

2. Abrir Swagger.

```text
https://localhost:7003/swagger
```

3. Buscar:

```text
POST /api/IA/analizar
```

4. Seleccionar `Try it out`.
5. Introducir los datos de la donación.
6. Seleccionar `Execute`.
7. Revisar la respuesta generada.

Ejemplo:

```json
{
  "nombreAlimento": "Pan",
  "cantidad": 10,
  "fechaVencimiento": "2026-08-11",
  "descripcion": "Pan fresco próximo a vencer"
}
```

---

# Pruebas

Para validar el funcionamiento de la API se recomienda realizar pruebas de casos válidos e inválidos.

### Caso válido

Ejemplo:

```http
GET /api/Donaciones
```

Respuesta esperada:

```text
200 OK
```

### Caso inválido

Enviar información incompleta o incorrecta.

Por ejemplo:

```http
POST /api/IA/analizar
```

con datos inválidos.

Respuesta esperada:

```text
400 Bad Request
```

Swagger permite documentar estos casos mediante capturas de pantalla.

---

# Códigos HTTP

| Código | Descripción                     |
| -----: | ------------------------------- |
|    200 | Operación exitosa               |
|    201 | Recurso creado                  |
|    204 | Operación exitosa sin contenido |
|    400 | Solicitud inválida              |
|    401 | No autenticado                  |
|    404 | Recurso no encontrado           |
|    500 | Error interno del servidor      |
|    502 | Error de comunicación con Groq  |

---

# Flujo general del sistema

```text
                    Usuario
                       |
                       v
                    Login
                       |
                       v
                     JWT
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

El análisis mediante Inteligencia Artificial funciona de manera independiente:

```text
Donación
    |
    v
Análisis mediante IA
    |
    +-- Nivel de riesgo
    +-- Motivo
    +-- Recomendación
```

---

# Seguridad

FoodShare implementa diferentes mecanismos de seguridad.

### Contraseñas

Las contraseñas se procesan utilizando:

```text
BCrypt.Net-Next
```

### Autenticación

Se utiliza:

```text
JWT Bearer
```

### Autorización

Los recursos protegidos utilizan:

```csharp
[Authorize]
```

### API Keys

Las credenciales de Groq deben mantenerse fuera del código fuente.

Se recomienda:

```bash
dotnet user-secrets set "Groq:ApiKey" "TU_API_KEY"
```

También se recomienda almacenar la clave utilizada para firmar JWT mediante User Secrets.

---

# Seguridad de credenciales

Nunca se deben subir al repositorio:

```text
API Keys
JWT Secrets
Passwords
Tokens
Credenciales privadas
```

No se recomienda almacenar directamente una API Key dentro de:

```text
appsettings.json
```

Para desarrollo local se deben utilizar User Secrets.

Para producción se recomienda utilizar un sistema especializado de gestión de secretos o variables de entorno seguras.

---

# Solución de problemas

## `dotnet` no se reconoce

Ejecutar:

```bash
dotnet --version
```

Si no funciona, instalar el SDK de .NET requerido.

## Entity Framework presenta errores

Verificar:

```bash
dotnet ef --version
```

Si no está instalado:

```bash
dotnet tool install --global dotnet-ef
```

Después:

```bash
dotnet ef database update
```

## La API Key de Groq no funciona

Verificar:

```bash
dotnet user-secrets list
```

Debe existir:

```text
Groq:ApiKey
```

Si no existe:

```bash
dotnet user-secrets set "Groq:ApiKey" "TU_API_KEY"
```

## Error 401 Unauthorized

Verificar:

1. Que el login haya sido exitoso.
2. Que el JWT sea válido.
3. Que el token no haya expirado.
4. Que Swagger tenga configurado el esquema Bearer.
5. Que el token se haya introducido mediante `Authorize`.

## Swagger no aparece

Verificar que la aplicación se esté ejecutando correctamente:

```bash
dotnet run
```

Después acceder a:

```text
https://localhost:7003/swagger
```

---

# Ejecución rápida

Una vez configurado el entorno, el proceso completo es:

```bash
git clone https://github.com/JohnyFontalvo04/FoodShareAPI.git

cd FoodShareAPI

dotnet restore

dotnet build

dotnet ef database update

dotnet user-secrets set "Groq:ApiKey" "TU_API_KEY"

dotnet user-secrets set "Jwt:Key" "TU_CLAVE_JWT"

dotnet run
```

Después acceder a:

```text
https://localhost:7003/swagger
```

---

# Estado del proyecto

| Característica        |    Estado    |
| --------------------- | :----------: |
| API REST              | Implementado |
| ASP.NET Core          | Implementado |
| CRUD                  | Implementado |
| Entity Framework Core | Implementado |
| SQLite                | Implementado |
| DbContext             | Implementado |
| Migraciones           | Implementado |
| DTOs                  | Implementado |
| Repositorios          | Implementado |
| Servicios             | Implementado |
| JWT                   | Implementado |
| BCrypt                | Implementado |
| Swagger/OpenAPI       | Implementado |
| HttpClient            | Implementado |
| Integración Groq      | Implementado |
| Prompt Engineering    | Implementado |
| Análisis mediante IA  | Implementado |

---

# Relación con los ODS

FoodShare se relaciona principalmente con:

### ODS 2 — Hambre Cero

La aplicación busca facilitar el aprovechamiento y redistribución de alimentos mediante una solución tecnológica.

También presenta relación con:

* ODS 12 — Producción y consumo responsables.
* ODS 13 — Acción por el clima.

---

# Equipo de desarrollo

Proyecto desarrollado como parte del Diplomado .NET.

| Rol                      | Responsabilidad                                          |
| ------------------------ | -------------------------------------------------------- |
| Backend / Technical Lead | Arquitectura, modelos, DbContext y endpoints principales |
| API / IA                 | Integración con Groq, HttpClient y prompt engineering    |
| BD / DTOs                | Validaciones, DTOs, consultas LINQ, datos y filtros      |
| Docs / QA                | README, Swagger, pruebas y evidencias                    |

---

# Recursos

* Repositorio: https://github.com/JohnyFontalvo04/FoodShareAPI
* ASP.NET Core: https://learn.microsoft.com/aspnet/core/
* Entity Framework Core: https://learn.microsoft.com/ef/core/
* SQLite: https://www.sqlite.org/
* Swagger: https://swagger.io/
* JWT: https://jwt.io/
* Groq: https://groq.com/

---

# Licencia

Este proyecto fue desarrollado con fines académicos y educativos como parte del proyecto final del Diplomado .NET.

---

# FoodShare API

**Tecnología orientada al aprovechamiento y redistribución de alimentos.**

**Donar. Solicitar. Compartir. Aprovechar.**
