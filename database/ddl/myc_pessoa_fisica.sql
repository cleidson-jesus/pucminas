CREATE TABLE IF NOT EXISTS myc_pessoa_fisica (
	id							int NOT NULL,
	idgenero					tinyint NULL,
	datanascimento				datetime NOT NULL, 
	idcidadenascimento		    smallint NOT NULL,
	numerodocidentificacao	    varchar(15) NOT NULL, 
	renda 						decimal(15,2) NULL, 
PRIMARY KEY (id),
FOREIGN KEY (id)
  REFERENCES myc_cliente(id)
);