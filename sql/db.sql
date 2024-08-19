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
	autor_id varchar(150) not null
);