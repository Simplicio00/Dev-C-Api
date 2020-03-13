USE Gufi_Manha;


--DQL



select NomeUsuario from Usuario;

select NomeFantasia,Endereco from Instituicao;

select TituloTipoEvento from TipoEvento;

select NomeEvento, DataEvento, Descricao from Evento;

select * from Evento where Evento.AcessoLivre = 1;

select Usuario.NomeUsuario, Evento.NomeEvento, Evento.DataEvento, Evento.Descricao, Presenca.Situacao from Presenca
inner join Usuario on Usuario.IdUsuario = Presenca.IdUsuario
inner join Evento on Evento.IdEvento = Presenca.IdEvento
where
NomeUsuario like '%Hugo%';


select usuario.NomeUsuario, TipoUsuario.TituloTipoUsuario from Usuario
inner join TipoUsuario on TipoUsuario.IdTipoUsuario = Usuario.IdTipoUsuario;



declare @AcessoLivre as bit
if @AcessoLivre = 1
begin
print 'Publico'
end
else
begin
print 'Privado'
end



select Evento.NomeEvento, Evento.AcessoLivre, TipoEvento.TituloTipoEvento, Instituicao.NomeFantasia, 
case AcessoLivre when 0 then 'Privado' when 1 then 'Livre' end as AcessoLivre
from Evento
inner join TipoEvento on TipoEvento.IdTipoEvento = Evento.IdTipoEvento
inner join Instituicao on Instituicao.IdInstituicao = Evento.IdInstituicao
where (AcessoLivre = 1)
;
