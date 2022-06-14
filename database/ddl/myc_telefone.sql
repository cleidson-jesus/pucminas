CREATE TABLE IF NOT EXISTS myc_telefone (
	id							int NOT NULL auto_increment, 
	idcliente					int NOT NULL,
	idtipo						tinyint NULL, 
	ddd							SMALLINT NOT NULL, 
	numero						int NOT NULL, 
	enviosms					bit	NULL, 
PRIMARY KEY (id),
INDEX numero(ddd,numero),
FOREIGN KEY (idcliente)
  REFERENCES myc_cliente(id)
);