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
	'� um jogo que tem bastante a��o e � viciante, seja voc� um novato ou um f�', 
	'2012-05-15', 
	'R$99,00',
	1
),
(
	'Red Dead Redemption II',
	'jogo eletr�nico de a��o-aventura western',
	'2018-10-26',
	'R$120,00',
	2
);
GO