# Sistema de Gestión de Empleados

## Estudiante
- Nombre: Genesis Gutierrez Espinoza
- Carnet: C4F794

---

## Descripcion del proyecto

Este sistema web fue desarrollado en ASP.NET Core MVC y permite la gestión de empleados mediante operaciones CRUD (Crear, Leer, Actualizar y Eliminar).

El sistema incluye funcionalidades como:

- Registro de empleados
- Edicion de empleados
- Eliminacion (logica o fisica segun implementacion)
- Activacion y desactivacion de empleados
- Busqueda por nombre o departamento
- Paginacion de resultados

---

## Instrucciones de ejecucion

### 1. Requisitos
- Visual Studio 2022 o superior
- .NET 6 o superior
- NuGet packages

### 2. Configurar base de datos
Ejecutar el script SQL del proyecto para crear la base de datos y tablas necesarias.

### 3. Ejecutar migraciones
En la consola del Administrador de paquetes:
Add-Migration InitialCreate
Update-Database

---

## Ejecutar el proyecto

Presiona F5 en Visual Studio o ejecuta:
dotnet run
O boton de “Iniciar”

---

## Funcionalidad de paginacion

El sistema implementa paginación para mejorar el rendimiento y la visualización de datos.

- Divide los empleados en páginas
- Permite navegar entre páginas
- Mejora el rendimiento cuando hay muchos registros

---

## Ejemplo de uso con búsqueda y paginacion
/Empleados?busqueda=TI&pagina=1

Esto significa que va a buscar empleados que contengan “TI” y
mostrar la pagina 1 de resultados