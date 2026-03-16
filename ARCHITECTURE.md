# Architecture / Arquitectura

The system follows a layered architecture to separate responsibilities and improve maintainability.
El sistema utiliza una arquitectura en capas para separar responsabilidades, mejorar la mantenibilidad y promover la escalabilidad.

## Layers / Capas

### UI (User Interface) 
Contains all WinForms screens responsible for user interaction.
Contiene todos los WinForms que permiten la interacción con el usuario.

### BLL (Business Logic Layer)
Handles application logic, validations and coordination between UI and data access.
Maneja la lógica de la aplicación, validaciones y cordinación entre la UI y el acceso a los datos.

### MAP (Mapping / Data Access)
Responsible for reading and writing XML files used as persistence storage.
Responsable de la lectura y escritura de los archivos XML, utilizados para la persistencia de los datos.

### BE (Business Entities)
Represents the domain entities of the system such as:
Representa el dominio de las entidades del sistema tales como:

- Patient / Paciente
- Psychologist / Psicólogo
- Session / Sesión
- Appointment / Turno
- Payment / Pago

### Services / Servicios
Provides shared utilities such as:
Provee utilidades compartidas como:

- file management / manejo de archivos
- resource handling / manejo de rutas
- configuration utilities / configuración general

### Security / Seguridad
Handles authentication and user access control.
Maneja cuestiones de autenticación, encriptación y acceso.
