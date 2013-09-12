CREATE TABLE loja_categorias (
	codigo INT8 NOT NULL,
	nome VARCHAR(50) NOT NULL,
	PRIMARY KEY (codigo)
);

CREATE TABLE loja_produtos (
	codigo INT8 NOT NULL,
	nome VARCHAR(255) NOT NULL,
	preco NUMERIC(8,2) NOT NULL,
	cod_categoria INT8 NOT NULL,
	FOREIGN KEY(cod_categoria) REFERENCES loja_categorias(codigo)
);