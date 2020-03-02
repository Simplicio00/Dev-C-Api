use InLock_Games_Manha

go

INSERT INTO TiposUsuario VALUES
(
	'Administrador'
),
(
	'Cliente'
);
GO

INSERT INTO Usuarios VALUES 
(
	'admin@admin.com','admin',1
),
(
	'cliente@cliente.com','cliente',2
);
GO

INSERT INTO Estudios VALUES 
(
	'Blizzard'
),
(
	'Rockstar Studios'
),
(
	'Square Enix'
);
GO

INSERT INTO Jogos VALUES 
(
	'Diablo3', 
	'é um jogo que tem bastante ação e é viciante, seja você um novato ou um fã', 
	'2012-05-15', 
	'R$99,00',
	1
),
(
	'Red Dead Redemption II',
	'jogo eletrônico de ação-aventura western',
	'2018-10-26',
	'R$120,00',
	2
);
GO