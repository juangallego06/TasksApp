# TasksApp - Prueba Técnica Fullstack

## Descripción general

TasksApp es una aplicación fullstack para gestión de tareas y usuarios, desarrollada como solución para la prueba técnica propuesta.

El proyecto incluye:

- Base de datos SQL Server
- API REST desarrollada en .NET 9
- Frontend desarrollado en Angular 18

La aplicación permite:

- Gestión de usuarios
- Creación y consulta de tareas
- Asignación de tareas a usuarios
- Actualización de estados
- Filtrado de tareas por estado
- Manejo de metadata dinámica en formato JSON

---

# Estructura del proyecto

```plaintext
TasksApp
│
├── API
│
├── BD
│   ├── Create_DB_Tables_Index.sql
│   ├── Consultas.sql
│   └── Consultas_Json.sql
│
└── front
```

---

# Tecnologías utilizadas

## Backend

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- AutoMapper
- FluentValidation
- Swagger

## Frontend

- Angular 18
- Angular Signals
- Reactive Forms
- TailwindCSS
- DaisyUI

## Base de datos

- SQL Server 15
- Funciones JSON:
  - ISJSON
  - JSON_VALUE
  - JSON_QUERY

---

# Arquitectura

## Backend

La API fue organizada siguiendo una separación clara de responsabilidades por capas, inspirada en una Arquitectura Limpia.

La solución se dividió en:

- Domain
- Application
- Infrastructure
- Presentation
- Shared

Durante el desarrollo se aplicaron principios:

- SOLID
- GRASP

Y patrones como:

- Repository Pattern
- Unit Of Work Pattern

También se implementó:

- Middleware global para manejo de excepciones
- Validación centralizada usando FluentValidation
- AutoMapper para mapeo entre entidades y DTOs
- Swagger para pruebas y documentación de endpoints

---

## Frontend

El frontend fue organizado por funcionalidades (`features`) para mantener una estructura modular y escalable.

Cada feature contiene:

- pages
- components
- services
- interfaces
- pipes

Esto facilita:
- mantenimiento
- organización
- separación de responsabilidades
- escalabilidad del proyecto

También se utilizaron:

- Angular Signals para manejo reactivo del estado
- Reactive Forms para validaciones y manejo de formularios
- TailwindCSS y DaisyUI para la interfaz visual

---

# Decisiones técnicas

## API

- Uso de DTOs para separación entre entidades y respuestas HTTP.
- Uso de FluentValidation para centralizar validaciones.
- Middleware global para manejo de errores.
- Uso de AutoMapper para transformación entre modelos.
- Separación de responsabilidades por capas.
- Implementación de Repository y UnitOfWork.

---

## Frontend

- Organización basada en features.
- Manejo reactivo usando Angular Signals.
- Componentes reutilizables para:
  - loading
  - errores
  - tablas
  - selects
  - modales
- Formularios reactivos para validaciones.
- Manejo visual de estados y feedback al usuario.

---

## Base de datos

La base de datos fue diseñada utilizando:

- claves foráneas
- constraints
- validaciones
- índices para optimización

Índices implementados:

### IX_Task_UserId
Optimiza consultas de tareas por usuario.

### IX_Task_Status
Optimiza consultas de tareas por estado.

### IX_User_Email
Optimiza búsquedas de usuarios por email.

La columna `MetadataJson` permite almacenar información dinámica usando funciones JSON de SQL Server.

---

# Configuración de base de datos

La base de datos fue desarrollada sobre:

```plaintext
localhost\SQLEXPRESS
SQL Server 15.0.2000
```

El usuario `sa` debe estar habilitado con la contraseña:

```plaintext
4dm1n_CCU
```

---

# Pasos para ejecutar el proyecto

## 1. Base de datos

1. Abrir SQL Server Management Studio.
2. Conectarse a:

```plaintext
localhost\SQLEXPRESS
```

3. Ejecutar el script:

```plaintext
BD/Create_DB_Tables_Index.sql
```

Este script:

- crea la base de datos
- crea tablas
- crea constraints
- crea índices

Los archivos:

- `Consultas.sql`
- `Consultas_Json.sql`

incluyen consultas adicionales y ejemplos de uso de funciones JSON.

---

## 2. API .NET

### Requisitos

- .NET 9 SDK
- Visual Studio 2022 o superior

### Ejecución

1. Abrir la solución:

```plaintext
Tasks.sln
```

2. Establecer como proyecto de inicio:

```plaintext
Tasks.Presentation.WebApi
```

3. Ejecutar la API desde Visual Studio.

La API se expone por el puerto:

```plaintext
http://localhost:5120
```

Swagger se encuentra habilitado en modo desarrollo:

```plaintext
http://localhost:5120/swagger
```

---

## 3. Frontend Angular

### Requisitos

- Node.js
- Angular CLI v18

### Ejecución

1. Abrir la carpeta `front` en Visual Studio Code.

2. Instalar dependencias:

```bash
npm install
```

3. Ejecutar el proyecto:

```bash
ng serve -o
```

La aplicación frontend se expone en:

```plaintext
http://localhost:4200
```

---

# Funcionalidades implementadas

## Usuarios

- Crear usuarios
- Consultar usuarios
- Validaciones de campos requeridos
- Límites de caracteres

---

## Tareas

- Crear tareas
- Asignar tareas a usuarios
- Consultar tareas
- Filtrar tareas por estado
- Actualizar estados de tareas
- Validación de reglas de negocio para transición de estados

---

## Metadata JSON

La metadata dinámica permite almacenar:

- prioridad
- fecha estimada
- tags

---

# Ejemplos de consultas JSON

## Validar JSON

```sql
SELECT *
FROM Task
WHERE ISJSON(MetadataJson) = 1
```

---

## Obtener valores escalares

```sql
SELECT
    Title,
    JSON_VALUE(MetadataJson, '$.priority') AS Priority
FROM Task
```

---

## Obtener arreglos JSON

```sql
SELECT
    Title,
    JSON_QUERY(MetadataJson, '$.tags') AS Tags
FROM Task
```

---

# Uso de herramientas de IA

Durante el desarrollo se utilizaron herramientas de inteligencia artificial como apoyo para:

- refinamiento de la interfaz de usuario
- generación y mejora de estilos visuales
- propuestas de experiencia de usuario (UX)
- validación de enfoques técnicos
- optimización de estructuras y componentes

Las decisiones de arquitectura, implementación, integración y adaptación al contexto del proyecto fueron realizadas y ajustadas manualmente según los requerimientos de la prueba técnica.

El uso adecuado de herramientas de IA permitió acelerar tareas repetitivas y apoyar decisiones relacionadas con UX/UI y estructura visual del proyecto.

---

# Funcionalidades pendientes

No quedaron funcionalidades pendientes al momento de la entrega.
