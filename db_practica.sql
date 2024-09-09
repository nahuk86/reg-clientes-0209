-- Crear la base de datos
CREATE DATABASE DB_CLIENTES;
GO

-- Usar la base de datos recién creada
USE DB_CLIENTES;
GO

-- Crear la tabla Clientes
CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(20) NOT NULL,
    Direccion NVARCHAR(200) NOT NULL
);
GO

-- Insertar algunos datos de ejemplo
INSERT INTO Clientes (Nombre, Correo, Telefono, Direccion)
VALUES ('Juan Pérez', 'juan.perez@example.com', '123456789', 'Calle Falsa 123'),
       ('Ana Gómez', 'ana.gomez@example.com', '987654321', 'Avenida Siempreviva 456');
GO
