CREATE DATABASE Filmes_manha;

USE Filmes_manha;

CREATE TABLE Generos(
	IdGenero	INT PRIMARY KEY IDENTITY
	,Nome		VARCHAR (255) NOT NULL UNIQUE
);

CREATE TABLE Filmes(
	IdFilme		INT PRIMARY KEY IDENTITY
	,Titulo		VARCHAR (255) NOT NULL UNIQUE
	,IdGenero	INT FOREIGN KEY REFERENCES Generos (IdGenero)
);

USE Filmes_manha

go

INSERT INTO Generos	(Nome)
VALUES				('Ação')
					,('Drama')

					go
INSERT INTO Filmes	(Titulo, IdGenero)
VALUES				('A vida é bela', 2)
					,('Rambo', 1);

					select Generos.Nome, Filmes.Titulo from Filmes
					inner join Generos on Generos.IdGenero = Filmes.IdGenero
