--Respostas

--1. Com base no diagrama, escreva um comando SQL que liste a quantidade de processos por
--Status com sua descrição.

select  count(c.nroProcesso) as total,  p.dsStatus
from tb_Processo as c
join tb_Status as p on c.IdStatus = p.IdStatus
group by p.dsStatus


--2. Com base no modelo acima, construa um comando SQL que liste a maior data de andamento
--por número de processo, com processos encerrados no ano de 2013.

SELECT Max(tb_Andamento.dtAndamento) as MaiorDataAndamento, tb_Processo.nroProcesso 
from tb_Andamento, tb_Processo
where tb_Processo.IdProcesso = tb_Andamento.IdProcesso and YEAR(tb_Processo.DtEncerramento ) = 2013
group by tb_Processo.nroProcesso


--3. Com base no modelo acima, construa um comando SQL que liste a quantidade de Data de
--Encerramento agrupada por ela mesma onde a quantidade da contagem seja maior que 5.

select count(DtEncerramento) as total, DtEncerramento  from tb_Processo group by  DtEncerramento having COUNT(DtEncerramento) > 5


--4. Possuímos um número de identificação do processo, onde o mesmo contém 12 caracteres
--com zero à esquerda, contudo nosso modelo e dados ele é apresentado como bigint. Como
--fazer para apresenta-lo com 12 caracteres considerando os zeros a esquerda?

select RIGHT(replicate('0', 12) + convert(varchar, nroProcesso), 12) as nroProcesso from tb_Processo



