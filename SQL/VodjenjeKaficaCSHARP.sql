use master;
go
drop database if exists VodjenjeKaficaCSHARP;
go
create database VodjenjeKaficaCSHARP;
go

use VodjenjeKaficaCSHARP;

create table Dobavljaci(
Sifra int not null primary key identity(1,1),
Naziv varchar(50) not null,
Grad varchar(20) not null,
Adresa varchar(50) not null,
Oib char(11) not null
);


create table Artikli(
Sifra int not null primary key identity(1,1),
NazivArtikla varchar(50) not null
);


create table Nabave(
Sifra int not null primary key identity(1,1),
BrojNabave int not null,
DatumNabave datetime not null,
Dobavljac int not null
);


create table Stavke(
SifraNabave int not null,
SifraArtikla int not null,
KolicinaArtikla int not null,
Cijena decimal(18,2) not null
);


alter table Nabave add foreign key (Dobavljac) references Dobavljaci(Sifra);
alter table Stavke add foreign key (SifraNabave) references Nabave(Sifra);
alter table Stavke add foreign key (SifraArtikla) references Artikli(Sifra);

-- INSERT NAREDBE

--select * from dobavljaci;
insert into Dobavljaci (Naziv, Grad, Adresa, Oib)values
('Bijelic.doo','Osijek','Sv.Roka1',96752332364),
('Atlantic.doo','Osijek','M.Gupca1',48037484195),
('Roto.doo','Osijek','Gunduliceva1',82770989192);

--select * from artikli;
insert into Artikli (NazivArtikla)values
('Coca-Cola 0.25 l'),
('Coca-ColaZero 0.25 l'),
('Fanta 0.25 l'),
('Sprite 0.25 l'),
('Schweppes 0.25 l'),
('Pan 0.5 l'),
('Tuborg 0.5 l'),
('Kozel 0.5 l'),
('Budweiser 0.5 l'),
('Osjecko 0.5 l'),
('Cedevita naranca 19 g'),
('Cedevita limun 19 g'),
('Cedevita grejp 19 g');