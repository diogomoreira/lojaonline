CREATE TABLE loja_categorias (
	codigo SERIAL,
	nome VARCHAR(50) NOT NULL,
	PRIMARY KEY (codigo)
);

CREATE TABLE loja_produtos (
	codigo SERIAL,
	nome VARCHAR(255) NOT NULL,
	preco NUMERIC(8,2) NOT NULL,
	cod_categoria INT8 NOT NULL,
	PRIMARY KEY (codigo),
	FOREIGN KEY(cod_categoria) REFERENCES loja_categorias(codigo)
);