USE JarvisDB

INSERT INTO Utilizador 
(idUtilizador, Nome, DataNascimento, Username, Password, Email, Foto, Admin)
VALUES
	(1,'Ana Silva', '1996-11-1','anaSilvaa','lala', 'as@gmail.com',null,0);

INSERT INTO Alergia
(Utilizador_idUtilizador, Alimento_idAlimento)
VALUES
	(1,15),
	(1,16);

INSERT INTO Preferencia
(Utilizador_idUtilizador, Alimento_idAlimento)
VALUES
	(1,9),
	(1,17);

INSERT INTO Alimento_Alternativo
(Alimento_idAlimento, Alimento_idAlimentoAlt)
VALUES
	(10,17),
	(6,18);

INSERT INTO Receita 
(idReceita, Nome, Descricao, Duracao, Dificuldade, Classificacao)
VALUES
	(1,'Massa fresca caseira','Receita tradicional de massa caseira',45,'M�dio',3.8),
	(2,'Tortellini com presunto e mozzarella','Tortellinis recheados com presunto, queijo mozzarella e tomate seco.',65,'Dif�cil',4.1);

INSERT INTO Instru��o
(idInstru��o, Descri��o, Ordem, Receita_idReceita)
VALUES
	(1,'Coloque a farinha numa bancada ou t�bua e fa�a um buraco no meio. Coloque os ovos, o sal e o azeite.',1,1),
	(2,'Bata com a ajuda de um garfo sem desfazer as �paredes� de farinha.',2,1),
	(3,'Comece a juntar lentamente a farinha com a ponta dos dedos.',3,1),
	(4,'Agregue a farinha formando uma bola de massa. Trabalhe com as m�os: enrole a massa da periferia para o centro e vice-versa, de forma a esmagar e a estender a massa com a palma da m�o. � um passo demorado e requer algum trabalho de bra�os.',4,1),
	(5,'Forme uma bola de massa com textura sedosa e sem grumos. Depois, envolva-a em pel�cula aderente e deixe-a descansar no m�nimo 30 minutos no frigor�fico.',5,1),
	(6,'Retire a massa do frigor�fico e comece a trabalh�-la com o rolo sobre uma superf�cie limpa e polvilhada com farinha.',6,1),
	(7,'Dobre a massa em formato de �envelope� e volte a estender com o rolo. Repita o processo at� obter alguma elasticidade',7,1),
	(8,'A massa come�a a aproximar-se da espessura pretendida. Corte pequenas por��es com a faca e continue a estender.',8,1),
	(9,'A massa est� pronta quando ganhar alguma transpar�ncia.',9,1),
	(10,'Corte-a em forma de rect�ngulo, descartando as pontas irregulares. Dobre-a em fole (largura entre 4 a 5 cm).',10,1),
	(11,'Escolha a a medida e corte-a em tiras.',11,1),
	(12,'A massa est� pronta. Polvilhe-a com farinha e solte as tiras para que n�o colem antes de serem cozidas. A massa deve ser cozida quase de imediato, numa panela com bastante �gua a ferver 4 a 5 minutos at� que fique al dente.',12,1),
	(13,'Para os tortellini: salpique a bancada de trabalho com farinha e misture a� a farinha e o sal. Abra uma cova e acrescente o azeite e os ovos. Amasse bem com as m�os, at� obter uma massa consistente e homog�nea. Deixe descansar 15 minutos.',1,2),
	(14,'Com um rolo, estenda a massa at� ficar muito fina. Corte-a em pequenos c�rculos com cerca de 8cm, usando um corta-massas ou um copo.',2,2),
	(15,'Para o recheio: pique finamente as chalotas e os dentes de alho e salteie-os no azeite quente at� a chalota come�ar a murchar. Adicione o queijo Mozzarella cortado em cubos, o presunto e o tomate seco laminado.',3,2),
	(16,'Envolva bem e tempere com metade do sal, pimenta e a salva cortada em tro�os finos. Retire do lume, deixe arrefecer um pouco e recheie os tortellini. Reserve.',4,2),
	(17,'Coloque um pouco de recheio no centro dos c�rculos de massa e feche-os, unindo as pontas. Passe com um pouco de �gua nos bordos e pressione para prender melhor.',5,2),
	(18,'Lamine o manjeric�o e a salva, coloque-os num tacho pequeno e adicione o azeite e a mostarda em gr�o. Envolva bem e leve ao lume at� levantar fervura. Retire e reserve.',6,2),
	(19,'Coza a massa em �gua a ferver temperada com sal durante 3 minutos ou at� ficar al dente. Retire, escorra e coloque os tortellini num prato fundo. Regue-os com o molho de ervas quente. Sirva de imediato.',7,2);

INSERT INTO Alimento
(idAlimento, Nome, ValorNutricional, Validade)
VALUES
	(1,'Farinha sem fermento',3.51,'2019-11-01'),
	(2,'Ovos',64.35,'2019-06-07'),
	(3,'Sal fino',0,'2019-12-01'),
	(4,'Azeite',70.72,'2019-06-30'),
	(5,'Farinha',3.67,'2019-11-01'),
	(6,'Chalota',45.6,'2019-06-15'),
	(7,'Alho',5.65,'2019-06-15'),
	(8,'Queijo mozzarella de b�fala',63.6,'2019-06-06'),
	(9,'Presunto',81,'2019-06-15'),
	(10,'Tomate Seco',23.43,'2019-06-08'),
	(11,'Pimenta',7.65,'2019-12-01'),
	(12,'Salva',4.89,'2019-06-06'),
	(13,'Mangeric�o',22,'2019-06-07'),
	(14,'Gr�os de mostarda',7.37,'2019-07-20'),
	(15,'Leite de soja',54,'2019-06-19'),
	(16,'Tortilla',237,'2019-06-10'),
	(17,'Tomate',22,'2019-06-07'),
	(18,'Cebola',33,'2019-06-10');

INSERT INTO Receita_Alimento
(Receita_idReceita, Alimento_idAlimento, Quantidade)
VALUES
	(1,1,'300 gramas'), 
	(1,2,'3 unidades'), 
	(1,3,'q.b.'),
	(1,4,'1 colher de sopa'), 
	(1,5,'q.b.'),
	(2,6,'2 unidades'),
	(2,7,'2 dentes'),
	(2,4,'7 colheres de sopa'),
	(2,8,'250 gramas'),
	(2,9,'300 gramas'),
	(2,10,'100 gramas'),
	(2,3,'1 colher de sobremesa'),
	(2,11,'q.b.'),
	(2,12,'1 colher de sopa, 1 p�'),
	(2,13,'2 p�s'),
	(2,14,'1 colher de sobremesa');

INSERT INTO Despensa
(Utilizador_idUtilizador, Alimento_idAlimento)
VALUES
	(1,17),
	(1,9),
	(1,5),
	(1,2),
	(1,3),
	(1,4),
	(1,7);

INSERT INTO Hist�rico
(Utilizador_idUtilizador, Receita_idReceita)
VALUES
	(1,1);

INSERT INTO Avaliacao
(idAvaliacao, Classificacao, Receita_idReceita, Utilizador_idUtilizador)
VALUES
	(1,4,1,1);

INSERT INTO Ementa
(idEmenta, Data, Utilizador_idUtilizador)
VALUES
	(1,'2019-05-30',1);

INSERT INTO Ementa_Receita
(Ementa_idEmenta, Receita_idReceita)
VALUES
	(1,2);

INSERT INTO ListaCompras
(Utilizador_idUtilizador, Alimento_idAlimento)
VALUES
	(1,8),
	(1,11),
	(1,12),
	(1,14);