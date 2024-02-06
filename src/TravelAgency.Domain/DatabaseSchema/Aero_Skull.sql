create database Aero_Skull;
use Aero_Skull;
-- drop database Aero_Skull;

create table Agency
(
	id varchar(255) primary key,
    name varchar(255) not null,
    fax varchar(255) not null,
    address varchar(255) not null,
    email varchar(255) not null
);

create table User(
	id varchar(255) primary key,
    firstName varchar(255) not null,
    lastName varchar(255) not null,
    email varchar(255) not null,
    password varchar(255) not null,
    role varchar(255) 
);

create table Tourist
(
	id varchar(255) primary key,
    nationality varchar(255) not null,
    foreign key(id) references User(id)
);

create table Hotel
(
	id varchar(255) primary key,
    name varchar(255) not null, 
    category int
);

create table TouristGroup
(
	id varchar(255) primary key,
    name varchar(255)
);

create table Facility
(
	id varchar(255) primary key,
    name varchar(255),
    description varchar(255)
);

create table Excursion
(
	id varchar(255) primary key,
    departure_place varchar(255),
    arrival_place varchar(255),
    departure_date date,
    arrival_date date
);

create table Excursion_Associated_Hotel
(
	excursionId varchar(255),
    hotelId varchar(255),
    primary key(excursionId, hotelId),
    foreign key(excursionId) references Excursion(id),
    foreign key(hotelId) references Hotel(id)
);

create table Agency_Works_With_Tourist
(
	agencyId varchar(255), 
	touristId varchar(255),
    primary key (agencyId, touristId),
	foreign key (agencyId) references Agency(id),
    foreign key (touristId) references Tourist(id)
);

create table Agency_Works_With_Excursions
(
	agencyId varchar(255), 
	excursionId varchar(255),
    primary key (agencyId, excursionId),
	foreign key (agencyId) references Agency(id),
    foreign key (excursionId) references Excursion(id)
);

create table Agency_Works_With_Hotel
(
	agencyId varchar(255), 
	hotelId varchar(255),
    primary key (agencyId, hotelId),
	foreign key (agencyId) references Agency(id),
    foreign key (hotelId) references Hotel(id)
);

create table Hotel_Deals
(
	dealId varchar(255),
    hotelId varchar(255),
    primary key (dealId, hotelId),
    description varchar(255),
    price decimal(15,2),
    foreign key (hotelId) references Hotel(id)
);

create table Tourist_Belongs_to_Group
(
	groupId varchar(255),
    touristId varchar(255),
    primary key (groupId, touristId),
    foreign key (groupId) references TouristGroup(id),
    foreign key (touristId) references Tourist(id)
);

create table Package
(
	packageId varchar(255),
    excursionId varchar(255),
    packageCode varchar(255),
    name varchar(255),
    duration int,
    description varchar(255),
    primary key (packageId),
    foreign key (excursionId) references Excursion(id)
);

create table Package_Has_Facilities
(
	facilityId varchar(255), 
	packageId varchar(255),
    primary key (facilityId, packageId),
	foreign key (facilityId) references Facility(id),
    foreign key (packageId) references Package(packageId)
);

create table Group_Reservation
(
	agencyId varchar(255),
    groupId varchar(255),
    reservation_date date,
    packageId varchar(255),
    excursionId varchar(255),
    participants_amount int,
    price decimal(15, 2),
    aero_company varchar(255),
    departure_date date,
    primary key(agencyId, groupId, reservation_date),
    foreign key (agencyId) references Agency(id),
    foreign key (groupId) references TouristGroup(id),
    foreign key (packageId) references Package(packageId),
    foreign key (excursionId) references Excursion(id)
);

create table Individual_Reservation
(
	agencyId varchar(255),
    touristId varchar(255),
    reservation_date date,
    excursionId varchar(255),
    index(reservation_date), # this allows use the data type as a foreign key. why ?
    primary key(agencyId, touristId, reservation_date),
    foreign key (agencyId) references Agency(id),
    foreign key (excursionId) references Excursion(id),
    foreign key (touristId) references Tourist(id)
);

create table Individual_Reservation_Hotels
(
	agencyId varchar(255),
    touristId varchar(255),
    reservation_date date,
    hotelId varchar(255),
    primary key (agencyId, touristId, reservation_date, hotelId),
	foreign key (agencyId) references Agency(id),
    foreign key (reservation_date) references Individual_Reservation(reservation_date),
    foreign key (touristId) references Tourist(id),
    foreign key (hotelId) references Hotel(id),
    arrival_date date
);
