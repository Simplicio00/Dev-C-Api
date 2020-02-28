use people_senai_bk

go

select Nome, Sobrenome, Senha from Pessoas;

go

select TipoUsuario from TipoUsuario;

go


create procedure PorNome
@espc varchar(200) as
select Pessoas.Nome, Pessoas.Email, TipoUsuario.TipoUsuario from Pessoas
inner join TipoUsuario on TipoUsuario.IdTipoUsuario = Pessoas.IdTipoUsuario
where Nome like @espc;

exec PorNome 'Catarina';