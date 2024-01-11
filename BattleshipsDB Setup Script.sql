create database BattleshipsDB;
go

use BattleshipsDB;
go

create table Players (
	username nvarchar(50) primary key,
	[password] nvarchar(50)
);

create table Games (
	id int primary key identity(1,1),
	title nvarchar(50),
	complete bit,
	creatorFK nvarchar(50) not null references players(username),
	opponentFK nvarchar(50) not null references players(username)
);

create table Attacks (
	id int primary key identity(1,1),
	coordinate nvarchar(50),
	hit bit,
	gameFK int not null references games(id)
);

create table Ships (
	id int primary key identity(1,1),
	title nvarchar(50),
	size int
);

create table GameShipConfigurations (
	id int primary key identity(1,1),
	coordinate nvarchar(50),
	playerFK nvarchar(50) not null references players(username),
	gameFK int not null references games(id)
);

INSERT INTO Ships (title, size) VALUES ('Destroyer', 2);
INSERT INTO Ships (title, size) VALUES ('Submarine', 3);
INSERT INTO Ships (title, size) VALUES ('Cruiser', 3);
INSERT INTO Ships (title, size) VALUES ('Battleship', 4);
INSERT INTO Ships (title, size) VALUES ('Carrier', 5);
