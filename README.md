# Laboratorio 1 Arquitectura de software
## Descripción
Este proyecto es una aplicación monolítica en .NET 7 que utiliza el patrón MVC y DAO para gestionar información personal mediante una API REST
y una interfaz de usuario. Implementada con Microsoft SQL Server 2022 y documentada mediante Swagger 3, ofrece funcionalidades completas CRUD,
facilitando tanto el manejo directo de datos a través de su interfaz como la integración con otros sistemas.
Ideal para organizaciones que buscan una solución robusta y eficiente para la administración de datos personales.

## Prerrequisitos

Antes de comenzar, asegúrate de tener instalado lo siguiente:
- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) 
- [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/es/vs/)

## Configuración del entorno

### Clonar el repositorio
```bash
git clone https://github.com/Orjuelalaley/personapi-dotnet.git
```

### Configurar la base de datos

1. **Crear la Base de Datos:**
   - Abre Microsoft SQL Server Management Studio (SSMS) y conecta con tu instancia de SQL Server.
   - Ejecuta el siguiente script SQL para crear la base de datos:
     ```sql
     CREATE DATABASE persona_db;
     GO
     ```

2. **Configurar la Cadena de Conexión:**
   - Asegúrate de que el archivo `appsettings.json` en tu proyecto tiene la cadena de conexión correcta:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=persona_db;Trusted_Connection=True;"
       }
     }
     ```

3. **Ejecutar Scripts de Base de Datos:**
   - Utiliza los scripts proporcionados en la carpeta `/Scripts` del repositorio para crear las tablas y relaciones necesarias.
   - Puedes ejecutar estos scripts directamente desde SSMS.

### Ejecutar la aplicación

1. **Abrir el Proyecto:**
   - Abre el archivo de solución (`*.sln`) en Visual Studio.

2. **Restaurar Paquetes NuGet:**
   - En Visual Studio, haz clic derecho en la solución y selecciona "Restore NuGet Packages".

3. **Compilar y Ejecutar:**
   - Compila la solución presionando `Ctrl + Shift + B`.
   - Ejecuta la aplicación presionando `F5` o clic en "Start Debugging".

4. **Acceder a Swagger:**
   - Una vez que la aplicación esté ejecutándose, navega a `http://localhost:<puerto>/swagger` para ver la UI de Swagger y probar la API.
