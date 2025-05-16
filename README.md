# CandidatosWebApp

CandidatosWebApp es una aplicación web desarrollada con ASP.NET Core Razor Pages (.NET 8, C# 12) para la gestión de experiencias laborales de candidatos. Permite crear, editar, visualizar y eliminar experiencias asociadas a cada candidato, facilitando la administración de información relevante para procesos de selección o recursos humanos.

## Características principales

- Listado de candidatos y sus experiencias laborales.
- Formularios para crear y editar experiencias.
- Validación de datos en el lado del cliente y servidor.
- Interfaz sencilla y responsiva basada en Razor Pages.
- Integración con Entity Framework Core para persistencia de datos.

## Requisitos

- .NET 8 SDK
- SQL Server (u otro proveedor compatible con EF Core)
- Visual Studio 2022 o superior

## Ejecución

1. Clona el repositorio.
2. Configura la cadena de conexión en `appsettings.json`.
3. Ejecuta las migraciones de la base de datos si es necesario.
4. Inicia la aplicación desde Visual Studio o usando `dotnet run`.

## Estructura del proyecto

- `Pages/`: Contiene las Razor Pages para CRUD de experiencias y candidatos.
- `Models/`: Modelos de datos utilizados por Entity Framework Core.
- `Data/`: Contexto de base de datos y configuración de acceso a datos.

## Contribuciones

Las contribuciones son bienvenidas. Por favor, abre un issue o pull request para sugerencias o mejoras.

---

Desarrollado con ❤️ usando ASP.NET Core Razor Pages, por Germán Pinilla