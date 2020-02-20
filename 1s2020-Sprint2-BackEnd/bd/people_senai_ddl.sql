create database people_senai_bk

go

use people_senai_bk

go

create table Pessoas(IdPessoa int primary key identity, Nome varchar(20) not null, Sobrenome varchar(50) not null);