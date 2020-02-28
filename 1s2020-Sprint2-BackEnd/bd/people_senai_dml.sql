
use people_senai_bk

go

insert into TipoUsuario(TipoUsuario)values('Administrador'),('Comum');

go

insert into pessoas(IdTipoUsuario,Nome,Sobrenome,Email,Senha)values(2,'Catarina','Strada','Catarina@email.com','1234567'),
(2,'Tadeu','Vitelli','Tadeu@email.com','1234567'),
(1,'Alfredo','Pessanha','adm@email.com','1234567');

