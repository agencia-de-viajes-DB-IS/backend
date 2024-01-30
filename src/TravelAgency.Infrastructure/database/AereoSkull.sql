create database Aereo_Skull;

use Aereo_Skull;

create table Agency
(
	IdA int not null primary key auto_increment,
    fax varchar(255) not null,
    directionA varchar(255) not null,
    email varchar(255) not null,
    nameA varchar(255) not null
);

create table Tourist
(
	IdT int primary key not null auto_increment,
    nameT varchar(255) not null,
    nationality varchar(255) not null
);

create table Agency_Works_With_Tourist
(
	IdA int, 
	IdT int,
    primary key ( IdA, IdT),
	foreign key (IdA) references Agency(IdA),
    foreign key (IdT) references Tourist(IdT)
);

create table Hotel
(
	IdH int primary key not null auto_increment,
    nameH varchar(255) not null, 
    category int
);

create table Hotel_Deals
(
	IdHD int not null auto_increment,
    IdH int,
    primary key (IdHD, IdH),
    foreign key (IdH) references Hotel(IdH),
    descriptionHD varchar(255),
    priceHD decimal(15,2)
);

create table Groupp
(
	IdTG int primary key not null auto_increment,
    nameG varchar(255)
);

create table Tourist_Group
(
	IdTG int,
    IdT int,
    primary key (IdTG, IdT),
    foreign key (IdTG) references Groupp(IdTG),
    foreign key (IdT) references Tourist(IdT)
);

create table Excursion
(
	idE int primary key not null auto_increment,
    departure_place varchar(255),
    arrival_place varchar(255),
    departure_date date,
    arrival_date date
);

create table Excursion_Associated_Hotel
(
	idE int,
    idH int,
    primary key(idE, idH),
    foreign key(idE) references Excursion(idE),
    foreign key(idH) references Hotel(idH)
);

create table Agency_Works_With_Excursions
(
	IdA int, 
	IdE int,
    primary key ( IdA, IdE),
	foreign key (IdA) references Agency(IdA),
    foreign key (IdE) references Excursion(IdE),
    price_per_agency_per_excursion decimal(15, 2)
);

create table Agency_Works_With_Hotel
(
	IdA int, 
	IdH int,
    primary key ( IdA, IdH),
	foreign key (IdA) references Agency(IdA),
    foreign key (IdH) references Hotel(IdH),
    price_per_agency_per_hotel decimal(15, 2)
);

create table Package
(
	idP int not null auto_increment,
    idE int,
    foreign key (IdE) references Excursion(IdE),
    primary key (IdP, idE),
    coode varchar(255),
    nameP varchar(255),
    duration int,
    descriptionP varchar(255)
);

create table Facility
(
	idF int primary key not null auto_increment,
    nameF varchar(255),
    descriptionF varchar(255)
);

create table Package_Facilities
(
	IdF int, 
	IdP int,
    primary key ( IdF, IdP),
	foreign key (IdF) references Facility(IdF),
    foreign key (IdP) references Package(IdP)
);

create table Group_Reservation
(
	idA int,
    idTG int,
    reservation_date date,
    primary key( idA, idTG, reservation_date),
    idP int,
    foreign key (idP) references Package(idP),
    foreign key (idA) references Agency(idA),
    foreign key (idTG) references Groupp(idTG),
    participants_size int,
    price_GR decimal(15, 2),
    aereo_company varchar(255),
    departure_date date
);

create table Individual_Reservation
(
	idA int,
    idT int,
    reservation_date date,
    index(reservation_date),
    primary key(idA, idT, reservation_date),
    idE int,
    foreign key (idA) references Agency(idA),
    foreign key (idE) references Excursion(idE),
    foreign key (idT) references Tourist(idT)
);

create table Individual_Reservation_Hotels
(
	idA int,
    idT int,
    reservation_date date,
    idH int,
    primary key (idA, idT, reservation_date, idH),
	foreign key (idA) references Agency(idA),
    foreign key (reservation_date) references Individual_Reservation(reservation_date),
    foreign key (idT) references Tourist(idT),
    foreign key (idH) references Hotel(IdH),
    arrival_date date
);
