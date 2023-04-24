DROP SCHEMA `contadigital` ;
CREATE SCHEMA `contadigital` ;

use contadigital;

create table User(
    iduser char(36) not null primary key,
    cpf CHAR(11) not null,
    name CHAR(30) NOT NULL,
    status boolean not null default 1
);

create table Bank(
    idbank char(36) not null primary key,
    age CHAR(5) not null
);

create table TypeTransaction(
    idtypetransaction char(36) not null primary key,
    description CHAR(30) not null,
    credit boolean not null
);

create table Account(
    idaccount char(36) not null primary key,
    idbank char(36) not null,
    number int(8) not null,
    balance double not null,
    datecreate date not null,
    lastblocked date null, 
    status boolean not null default 1,
    blocked boolean not null default 0,
    FOREIGN KEY (idbank) REFERENCES Bank(idbank)
);

create table UserAccount(
    iduseraccount char(36) not null primary key,
    iduser char(36) not null,
    idaccount char(36) not null,
    password CHAR(8) not null,
    lastpassword CHAR(8) null,
    lastaccess date  null,
    FOREIGN KEY (iduser) REFERENCES User(iduser),
    FOREIGN KEY (idaccount) REFERENCES Account(idaccount)
);

create table AccountMov(
    idaccountmov char(36) not null primary key,
    idaccount char(36) not null,
    idaccountDestination char(36) null,
    idtypetransaction char(36) not null,
    value double not null,
    datecreate date not null,
    FOREIGN KEY (idaccount) REFERENCES Account(idaccount),
    FOREIGN KEY (idtypetransaction) REFERENCES TypeTransaction(idtypetransaction)
);

insert into `TypeTransaction` (idtypetransaction, description, credit) values('519fd5fe-e53d-4b9a-8121-67ecea98aae8','withdraw', false);
insert into `TypeTransaction` (idtypetransaction, description, credit) values('309974a4-ff91-421f-bb4d-709029bf8654','received', true);
insert into `TypeTransaction` (idtypetransaction, description, credit) values('ee4c20fb-ceca-4d1d-95b8-8f0e314e2899','deposit', true);
insert into `TypeTransaction` (idtypetransaction, description, credit) values('460d4b8a-5018-4143-8297-b8020c1af947','pix', false);
insert into `TypeTransaction` (idtypetransaction, description, credit) values('511aa6dd-6714-438c-aa9e-a1453cd852d0','ted', false);
insert into `TypeTransaction` (idtypetransaction, description, credit) values('f0888c08-cd8c-47dc-a69a-df63b8a033f8','doc', false);

insert into `Bank` (idbank, age) values('3f2fbbf2-68e8-4cee-90b3-d4c3efefd814','720');