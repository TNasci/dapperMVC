create database cadastroComex;

create table pessoa (
	id_pessoa int IDENTITY(1,1) primary key, 
	nome_pessoa varchar(255), 
	telefone_pessoa varchar(30), 
	cpf_pessoa varchar(30),
	);

	
create table enderecoPessoa (
	id_endereco int primary key,
	id_pessoa int, 
	cep varchar(15),
	logradouro varchar(255),
	complemento varchar(30),
	bairro varchar(255),
	cidade varchar(255),
	estado varchar(5)
);



insert into pessoa values
('Thiago', '+5511960678289', '40576384828')

insert into pessoa values
('Valéria', '+5511984659438', '09820541492')

insert into enderecoPessoa values
(2, 1, '06755260', 'av. josé andré de moraes', 'apto 2 bloco b', 'jd.monte alegra', 'taboão da serra', 'SP')

select * from pessoa 


select * from enderecoPessoa 
