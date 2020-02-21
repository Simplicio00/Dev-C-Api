use people_senai_bk

go

select Nome, Sobrenome from Pessoas;


create procedure PorNome
@espc varchar(200) as
select Nome, Sobrenome from Pessoas
where Nome like @espc;

drop procedure PorNome;

exec PorNome 'Catarina';