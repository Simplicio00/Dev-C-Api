SELECT IdUsuario, Email, Senha, TiposUsuario.IdTipoUsuario, Titulo FROM Usuarios
INNER JOIN TiposUsuario ON TiposUsuario.IdTipoUsuario = Usuarios.IdTipoUsuario;

SELECT IdEstudio, NomeEstudio FROM Estudios;

SELECT IdJogo, NomeJogo, Descricao, DataLancamento, Valor, Estudios.IdEstudio, NomeEstudio FROM Jogos
INNER JOIN Estudios on Estudios.IdEstudio = Jogos.IdEstudio;

SELECT IdUsuario, Email, Senha, TiposUsuario.IdTipoUsuario, Titulo FROM Usuarios
INNER JOIN TiposUsuario ON TiposUsuario.IdTipoUsuario = Usuarios.IdTipoUsuario
WHERE Email = @Email AND Senha = @Senha; 

SELECT IdJogo, NomeJogo, Descricao, DataLancamento, Valor, Estudios.IdEstudio, NomeEstudio FROM Jogos
INNER JOIN Estudios on Estudios.IdEstudio = Jogos.IdEstudio
WHERE IdJogo = @ID;

SELECT IdEstudio, NomeEstudio FROM Estudios
WHERE IdEstudio = @ID;

SELECT Estudios.IdEstudio, NomeEstudio, Jogos.IdJogo, Jogos.NomeJogo, Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor FROM Estudios
LEFT JOIN Jogos on Jogos.IdEstudio = Estudios.IdEstudio;