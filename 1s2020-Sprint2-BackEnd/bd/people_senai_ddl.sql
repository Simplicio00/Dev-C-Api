create database people_senai_bk

go

use people_senai_bk

go

create  table TipoUsuario(IdTipoUsuario int primary key identity, TipoUsuario varchar(250) not null unique);

go

create table Pessoas(
IdPessoa int primary key identity, 
IdTipoUsuario int foreign key references TipoUsuario(IdTipoUsuario), 
Nome varchar(20) not null, 
Sobrenome varchar(50) not null,
Email varchar(250) not null unique, 
Senha varchar(250) not null
);