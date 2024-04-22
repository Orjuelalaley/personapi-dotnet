# Laboratorio 1 Arquitectura de software
## Descripci�n
Este proyecto es una aplicaci�n monol�tica en .NET 7 que utiliza el patr�n MVC y DAO para gestionar informaci�n personal mediante una API REST
y una interfaz de usuario. Implementada con Microsoft SQL Server 2022 y documentada mediante Swagger 3, ofrece funcionalidades completas CRUD,
facilitando tanto el manejo directo de datos a trav�s de su interfaz como la integraci�n con otros sistemas.
Ideal para organizaciones que buscan una soluci�n robusta y eficiente para la administraci�n de datos personales.

## Prerrequisitos

Antes de comenzar, aseg�rate de tener instalado lo siguiente:
- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) 
- [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/es/vs/)

## Configuraci�n del entorno

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

2. **Configurar la Cadena de Conexi�n:**
   - Aseg�rate de que el archivo `appsettings.json` en tu proyecto tiene la cadena de conexi�n correcta:
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

### Ejecutar la aplicaci�n

1. **Abrir el Proyecto:**
   - Abre el archivo de soluci�n (`*.sln`) en Visual Studio.

2. **Restaurar Paquetes NuGet:**
   - En Visual Studio, haz clic derecho en la soluci�n y selecciona "Restore NuGet Packages".

3. **Compilar y Ejecutar:**
   - Compila la soluci�n presionando `Ctrl + Shift + B`.
   - Ejecuta la aplicaci�n presionando `F5` o clic en "Start Debugging".

4. **Acceder a Swagger:**
   - Una vez que la aplicaci�n est� ejecut�ndose, navega a `http://localhost:<puerto>/swagger` para ver la UI de Swagger y probar la API.
