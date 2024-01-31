
CREATE DATABASE CentroMedico;

USE CentroMedico;

-- Crear la tabla Paciente
CREATE TABLE Paciente (
    PacienteID INT PRIMARY KEY IDENTITY,
    Nombres VARCHAR(50) NOT NULL,
    Apellidos VARCHAR(50) NOT NULL,
    TipoDocumento VARCHAR(20) NOT NULL,
    NumeroDocumento VARCHAR(20) UNIQUE NOT NULL,
    FechaNacimiento DATE NOT NULL,
    CiudadResidencia VARCHAR(50) NOT NULL
);

-- Crear la tabla Departamento
CREATE TABLE Departamento (
    DepartamentoID INT PRIMARY KEY IDENTITY,
    NombreDepartamento VARCHAR(50) NOT NULL
);

-- Crear la tabla Ciudad
CREATE TABLE Ciudad (
    CiudadID INT PRIMARY KEY IDENTITY,
    NombreCiudad VARCHAR(50) NOT NULL,
    DepartamentoID INT FOREIGN KEY REFERENCES Departamento(DepartamentoID)
);