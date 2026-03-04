GO
use OlympiadDB;

insert into Countries (Name) values ('Japan');
insert into Countries (Name) values ('France');
insert into Countries (Name) values ('China');
insert into Countries (Name) values ('Ukraine');
insert into Countries (Name) values ('Russian');


insert into Cities(Name,CountryId) values ('Paris',2);
insert into Cities(Name,CountryId) values ('Tokio',1);
insert into Cities(Name,CountryId) values ('Kyoto',1);
insert into Cities(Name,CountryId) values ('Pekin',3);
insert into Cities(Name,CountryId) values ('Kyiv',4);
insert into Cities(Name,CountryId) values ('Moscow',5);
insert into Cities(Name,CountryId) values ('Sochi',5);

SELECT * FROM Athletes