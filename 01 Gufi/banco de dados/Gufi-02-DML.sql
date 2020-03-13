USE Gufi_Manha;

SELECT * FROM TipoUsuario;

--inserção de dados no banco Gufi

--dml

insert into TipoUsuario(TituloTipoUsuario)values('Administrador'),('Comum');

insert into TipoEvento(TituloTipoEvento)values('C#'),('React'),('SQL');

insert into Instituicao(CNPJ,NomeFantasia,Endereco)values(11111111111111,'Escola SENAI de informática', 'Alameda Barão De Limeira, 538');


insert into Usuario(NomeUsuario,Email,Senha,Genero,DataNascimento,IdTipoUsuario)
values('Administrador','adm@adm.com','adm123','Não Informado','06/02/2020',1),('Hugo Pelaipe de Oliveira','Hugo@email.com','hugo123','Masculino','06/12/1983',2),('Antonia Maria Brás de Souza','antonia@email.com','maria123','Feminino','25/01/1940',2);


insert into Evento(NomeEvento,DataEvento,Descricao,AcessoLivre,IdInstituicao,IdTipoEvento)
values('Introdução ao C#','07/02/2020','Conceitos sobre programação orientada à objeto',1,1,1),
('Ciclo de vida','07/02/2020','Como utilizar o cliclo de vida com React Js',0,1,2),
('Optimização do banco de dados','07/02/2020','Aplicação de índices clusterizados e não clusterizados',1,1,3);

insert into Presenca(IdUsuario,IdEvento,Situacao) 
values(2,2,'Agendada'),(2,3,'Confirmada'),(3,1,'Não Compareceu');