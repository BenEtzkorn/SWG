USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='DvdLibrary')
DROP DATABASE DvdLibrary
GO

CREATE DATABASE DvdLibrary
GO

USE DvdLibrary
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Dvds')
DROP TABLE Dvds
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Ratings')
DROP TABLE Ratings
GO

CREATE TABLE Ratings(
	rating varchar(5) not null primary key,
)
GO

CREATE TABLE Dvds(
	dvdId int IDENTITY(1,1) primary key,
	title varchar(50) not null,
	releaseYear char(4) not null,
	director varchar(50) not null,
	rating varchar(5) not null foreign key references Ratings(rating),
	notes varchar(250)
)
GO