CREATE TABLE IF NOT exists myc_cliente (
	id 						int NOT null AUTO_INCREMENT,
	cpfcnpj 				varchar(14) UNIQUE NOT NULL,
	nome 					varchar(60) NOT NULL,
	idtipo					tinyint NOT NULL,
	datahorainclusao		datetime NOT NULL,
	datahoraatualizacao   	datetime NOT NULL,
	datafichacadastral		datetime NOT NULL,
	idrating				tinyint NULL, 
	exposicaomidia			tinyint NULL, 
	email 					varchar(50),
	pessoapep 				bit,
PRIMARY KEY (id),
INDEX nome (nome)
);