create table autor
(
	id varchar(150) primary key,
	nome varchar(150) not null,
	email varchar(500) not null,
	descricao varchar(400)
);

create table categoria
(
	id varchar(150) primary key,
	nome varchar(150) not null,
	descricao varchar(255)
);

create table livro
(
	id varchar(150) primary key,
	isbn varchar(150) not null,
	titulo varchar(100) not null,
	resumo varchar(500) not null,
	sumario text,
	numero_paginas int not null,
	data_publicacao date,
	categoria_id varchar(150) not null,
	autor_id varchar(150) not null,
	preco money not null
);


create table pais
(
	id varchar(150) primary key,
	nome varchar(100) not null,
	sigla varchar(10) not null
);

create table estado
(
	id varchar(150) primary key,
	nome varchar(100) not null,
	sigla varchar(10) not null,
	pais_id varchar(150) not null
);

create table pedido
(
	id varchar(150) primary key,
	email varchar(100) not null,
	nome varchar(100) not null,
	sobrenome varchar(100) not null,
	documento varchar(20) not null,
	telefone varchar(15) not null,
	logradouro varchar(255) not null,
	cep varchar(10) not null,
	cidade varchar(100) not null,
	estado_id varchar(150) not null,
	pais_id varchar(150) not null,
	complemento varchar(100) null,
	cupom_id varchar(150) not null,
	total money not null
);

create table item_pedido 
(
	id varchar(150) primary key,
	pedido_id varchar(150) not null,
	quantidade int not null,
	preco money not null,
	total money not null
);

create table cupom 
(
	id varchar(150) primary key,
	nome varchar(50) not null,
	valor decimal not null,
	validade date not null
);

