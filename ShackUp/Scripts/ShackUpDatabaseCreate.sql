USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='ShackUp')
DROP DATABASE ShackUp
GO

CREATE DATABASE ShackUP
GO