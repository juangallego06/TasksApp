-- Usamos Master
USE [master]

GO

-- Creamos la BD TasksDb
CREATE DATABASE TasksDb

GO

-- Usamos la BD TasksDb
USE TasksDb

GO

-- Tabla de usuarios
CREATE TABLE [User](
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	UserName NVARCHAR(100) NOT NULL,
	Email NVARCHAR(150) NOT NULL UNIQUE,
	CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE()
)

GO

-- Tabla de tareas
CREATE TABLE Task(
	Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Title NVARCHAR(200) NOT NULL,
	[Description] NVARCHAR(250) NULL,
	[Status] NVARCHAR(20) NOT NULL DEFAULT 'Pending',
	UserId INT NOT NULL,
	CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
	MetadataJson NVARCHAR(MAX),
	CONSTRAINT FK_Task_User FOREIGN KEY (UserId) REFERENCES [User](Id) ON DELETE NO ACTION,
	CONSTRAINT CK_Task_Status CHECK ([Status] IN ('Pending', 'InProgress', 'Done')),
	CONSTRAINT CK_Task_Metadata CHECK(MetadataJson IS NULL OR ISJSON(MetadataJson) = 1)
)

GO

CREATE TABLE Logs(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Message] NVARCHAR(MAX) NULL,
	MessageTemplate NVARCHAR(MAX) NULL,
	[Level] NVARCHAR(16) NULL,
	[TimeStamp] DATETIME NULL,
	Exception NVARCHAR(MAX) NULL,
	Properties NVARCHAR(MAX) NULL,
)

GO

-- Indice en la tabla Task por UserId para optimizar consultas de tarea por Usuario
CREATE INDEX IX_Task_UserId ON Task(UserId)

GO

-- Indice en la tabla Task por Status para optimizar consultas de tarea por Estado
CREATE INDEX IX_Task_Status ON Task([Status])

GO

-- Indice en la tabla User por Email para optimizar consultas de Usuario por Email
CREATE INDEX IX_User_Email ON [User](Email)

