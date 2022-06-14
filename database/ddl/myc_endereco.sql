CREATE TABLE IF NOT EXISTS myc_endereco (
	id							int NOT NULL auto_increment, 
	idcliente					int NOT NULL,
	cep 						int NOT NULL,
	logradouro					varchar(60) NOT NULL, 
	numero						varchar(10) NOT NULL,
PRIMARY KEY (id),
INDEX idcliente(idcliente),
FOREIGN KEY (idcliente)
  REFERENCES myc_cliente(id)
);