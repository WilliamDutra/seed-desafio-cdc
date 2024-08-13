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