# API Product

## Descripción

API REST en .NET 8 para la gestión de productos. Permite registrar, actualizar y consultar productos por ID.
El proyecto tiene buenas prácticas de desarrollo, separación de responsabilidades y código mantenible.

---

## Arquitectura

Se implementa una estructura basada en **Clean Architecture**, separando el proyecto en capas:

* **Domain**: entidades y lógica base del negocio
* **Application**: servicios, DTOs e interfaces
* **Infrastructure**: acceso a datos (repositorios, conexión a BD)
* **API**: controllers y endpoints

<img width="550" height="318" alt="imagen" src="https://github.com/user-attachments/assets/7167636e-d720-469b-9ab8-ef0d1296c976" />

---

## Patrones y buenas prácticas

* Repository Pattern
* Dependency Injection
* DTO (Data Transfer Objects)
* Uso de AutoMapper para mapeos
* Principios SOLID
* Validación de modelos (DataAnnotations)
* Manejo de HTTP Status Codes
* Middleware para logging de tiempo de respuesta

---

## Logging

Se implementa un **middleware personalizado** que registra el tiempo de respuesta de cada request (método, endpoint, status y duración).

Los logs se almacenan en archivos de texto mediante **NLog**, separando los logs de aplicación y los tiempos de respuesta.

---

## Tecnologías utilizadas

* .NET 8
* ASP.NET Core Web API
* AutoMapper
* SQL Server
* xUnit (pruebas unitarias)
* Moq (mocking)
* NLog

---

## Endpoints disponibles

* GET /api/product/{id} → Obtener producto por ID
* POST /api/product → Crear producto
* PUT /api/product/{id} → Actualizar producto

---

## Cómo ejecutar el proyecto

1. Clonar el repositorio
2. Abrir la solución en Visual Studio
3. Configurar la cadena de conexión en `appsettings.json`

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ApiProductDB;Trusted_Connection=True;"
}
```

4. Ejecutar el proyecto (F5 o Run)

Swagger disponible en:

```
https://localhost:<puerto>/swagger
```

---

## Pruebas

Se implementan pruebas unitarias enfocadas en la capa de servicios utilizando xUnit y Moq.
