CREATE TABLE IF NOT EXISTS myc_pessoa_juridica (
	id_cliente					int NOT NULL,
	data_fundacao				datetime NOT NULL, 
	id_porte					tinyint NOT NULL,
	id_setor_atividade_cnae		SMALLINT NULL,
PRIMARY KEY (id_cliente),
FOREIGN KEY (id_cliente)
  REFERENCES myc_cliente(id)
);