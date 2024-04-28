/*
Created: 28/04/2024
Modified: 28/04/2024
Model: Microsoft SQL Server 2019
Database: MS SQL Server 2019
*/


-- Create tables section -------------------------------------------------

-- Table Usuario

CREATE TABLE [Usuario]
(
 [UsuarioID] Int IDENTITY NOT NULL,
 [Nombre] Varchar(128) NOT NULL,
 [Password] Varchar(1) NOT NULL,
 [Id_Rol] Int NULL
)
go

-- Create indexes for table Usuario

CREATE INDEX [IX_Relationship20] ON [Usuario] ([Id_Rol])
go

-- Add keys for table Usuario

ALTER TABLE [Usuario] ADD CONSTRAINT [PK_Usuario] PRIMARY KEY ([UsuarioID])
go

-- Table Bus

CREATE TABLE [Bus]
(
 [Id_Bus] Int IDENTITY NOT NULL,
 [Capacidad] Int NOT NULL
)
go

-- Add keys for table Bus

ALTER TABLE [Bus] ADD CONSTRAINT [PK_Bus] PRIMARY KEY ([Id_Bus])
go

-- Table Horario

CREATE TABLE [Horario]
(
 [Id_Horario] Int NOT NULL,
 [Inicio_Horario] Date NOT NULL,
 [Fin_Horario] Date NOT NULL
)
go

-- Add keys for table Horario

ALTER TABLE [Horario] ADD CONSTRAINT [PK_Horario] PRIMARY KEY ([Id_Horario])
go

-- Table Ruta

CREATE TABLE [Ruta]
(
 [Id_ruta] Int NOT NULL,
 [Origen] Varchar(128) NOT NULL,
 [Destino] Varchar(128) NOT NULL
)
go

-- Add keys for table Ruta

ALTER TABLE [Ruta] ADD CONSTRAINT [PK_Ruta] PRIMARY KEY ([Id_ruta])
go

-- Table Empleado

CREATE TABLE [Empleado]
(
 [Id_Empleado] Int NOT NULL,
 [Nombre_Empleado] Varchar(128) NOT NULL,
 [Id_Departamento] Int NOT NULL,
 [Id_Organizacion] Int NOT NULL
)
go

-- Create indexes for table Empleado

CREATE INDEX [IX_Relationship6] ON [Empleado] ([Id_Departamento],[Id_Organizacion])
go

-- Add keys for table Empleado

ALTER TABLE [Empleado] ADD CONSTRAINT [PK_Empleado] PRIMARY KEY ([Id_Empleado])
go

-- Table Departamento

CREATE TABLE [Departamento]
(
 [Id_Departamento] Int NOT NULL,
 [Nombre_Depto] Varchar(128) NOT NULL,
 [Id_Organizacion] Int NOT NULL
)
go

-- Add keys for table Departamento

ALTER TABLE [Departamento] ADD CONSTRAINT [PK_Departamento] PRIMARY KEY ([Id_Departamento],[Id_Organizacion])
go

-- Table Asiganacion_viaje

CREATE TABLE [Asiganacion_viaje]
(
 [Id_Asiganacion] Int NOT NULL,
 [Descripcion_ruta] Varchar(128) NOT NULL,
 [Fecha] Date NOT NULL,
 [Id_Empleado] Int NOT NULL,
 [Id_ruta] Int NOT NULL,
 [Id_Bus] Int NOT NULL,
 [Id_Horario] Int NOT NULL,
 [Asientos_ocupados] Int NOT NULL,
 [Asientos_disponibles] Int NOT NULL,
 [UsuarioID] Int NULL
)
go

-- Create indexes for table Asiganacion_viaje

CREATE INDEX [IX_Relationship21] ON [Asiganacion_viaje] ([UsuarioID])
go

-- Add keys for table Asiganacion_viaje

ALTER TABLE [Asiganacion_viaje] ADD CONSTRAINT [PK_Asiganacion_viaje] PRIMARY KEY ([Id_Asiganacion],[Id_ruta],[Id_Empleado],[Id_Bus],[Id_Horario])
go

-- Table Organizacion

CREATE TABLE [Organizacion]
(
 [Id_Organizacion] Int NOT NULL,
 [Descripcion] Varchar(1) NULL
)
go

-- Add keys for table Organizacion

ALTER TABLE [Organizacion] ADD CONSTRAINT [PK_Organizacion] PRIMARY KEY ([Id_Organizacion])
go

-- Table Rol

CREATE TABLE [Rol]
(
 [Id_Rol] Int NOT NULL,
 [Descripcion_rol] Varchar(1) NOT NULL
)
go

-- Add keys for table Rol

ALTER TABLE [Rol] ADD CONSTRAINT [PK_Rol] PRIMARY KEY ([Id_Rol])
go

-- Create foreign keys (relationships) section ------------------------------------------------- 


ALTER TABLE [Empleado] ADD CONSTRAINT [Relationship6] FOREIGN KEY ([Id_Departamento], [Id_Organizacion]) REFERENCES [Departamento] ([Id_Departamento], [Id_Organizacion]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Asiganacion_viaje] ADD CONSTRAINT [Relationship9] FOREIGN KEY ([Id_Empleado]) REFERENCES [Empleado] ([Id_Empleado]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Asiganacion_viaje] ADD CONSTRAINT [Relationship10] FOREIGN KEY ([Id_ruta]) REFERENCES [Ruta] ([Id_ruta]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Asiganacion_viaje] ADD CONSTRAINT [Relationship11] FOREIGN KEY ([Id_Bus]) REFERENCES [Bus] ([Id_Bus]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Asiganacion_viaje] ADD CONSTRAINT [Relationship12] FOREIGN KEY ([Id_Horario]) REFERENCES [Horario] ([Id_Horario]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Departamento] ADD CONSTRAINT [Relationship16] FOREIGN KEY ([Id_Organizacion]) REFERENCES [Organizacion] ([Id_Organizacion]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Usuario] ADD CONSTRAINT [Relationship20] FOREIGN KEY ([Id_Rol]) REFERENCES [Rol] ([Id_Rol]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [Asiganacion_viaje] ADD CONSTRAINT [Relationship21] FOREIGN KEY ([UsuarioID]) REFERENCES [Usuario] ([UsuarioID]) ON UPDATE NO ACTION ON DELETE NO ACTION
go




