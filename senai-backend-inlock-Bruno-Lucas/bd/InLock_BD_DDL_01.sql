CREATE DATABASE InLock_Games_Manha;

GO


USE InLock_Games_Manha;
GO

CREATE TABLE Estudios (
	IdEstudio INT PRIMARY KEY IDENTITY,
	NomeEstudio VARCHAR (255)
);

GO

CREATE TABLE Jogos (
	IdJogo INT PRIMARY KEY IDENTITY,
	NomeJogo VARCHAR (255),
	Descricao VARCHAR (255),
	DataLancamento DATE,
	Valor VARCHAR (255),
	IdEstudio INT FOREIGN KEY REFERENCES Estudios (IdEstudio)
);
GO

CREATE TABLE TiposUsuario (
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR (255)
)
GO

CREATE TABLE Usuarios (
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR (255),
	Senha VARCHAR (255),
	IdTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuario(IdTipoUsuario)
)