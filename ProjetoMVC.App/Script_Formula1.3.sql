USE Formula1
GO
DROP TABLE if exists Pilotos
DROP TABLE if exists Carros
DROP TABLE if exists Chefes
DROP TABLE if exists Conquistas
DROP TABLE if exists Equipes
    GO
DROP TABLE IF EXISTS Equipes
    GO
CREATE TABLE Equipes (
                         IdEquipe int primary key identity(1,1),
                         NomeEquipe VARCHAR(100) NOT NULL,
                         SlugEquipe varchar(200) unique,
                         UrlFotoScuderia VARCHAR(200) ,
                         UrlFotoPilotos Varchar(200),
                         UrlImagemExibicao Varchar(200),
                         CorScuderia varchar(200)
);
GO
DROP TABLE IF EXISTS Pilotos
    GO
Create table Pilotos
(
    IdPiloto int primary key identity(1,1),
    NomePiloto VARCHAR(100) NOT NULL,
    NacionalidadePiloto VARCHAR(50) NOT NULL,
    UrlFotoPiloto VARCHAR(50) NULL,
    IdEquipe int,
    FOREIGN KEY (IdEquipe) REFERENCES Equipes(IdEquipe)
)
    GO
DROP TABLE IF EXISTS Carros
    GO
Create table Carros
(
    IdCarro INT primary key identity(1,1),
    ModeloCarro VARCHAR(100) NOT NULL,
    FabricanteMotor VARCHAR(100) NOT NULL,
    IdEquipe int,
    FOREIGN KEY (IdEquipe) REFERENCES Equipes(IdEquipe)
)
    GO
Drop table if exists Chefes
    GO
CREATE TABLE Chefes (
                        IdChefe INT primary key identity(1,1),
                        NomeChefe VARCHAR(100) NOT NULL,
                        IdEquipe int,
                        FOREIGN KEY (IdEquipe) REFERENCES Equipes(IdEquipe)
);
GO
Drop table if exists Conquistas
    Go
Create table Conquistas
(
    IdConquista				INT primary key identity(1,1)
    ,QtdGrandesPremios			varchar(100) NULL
    ,QtdTitulosConstrutores		varchar(100) NULL
    ,QtdTitulosPilotos			varchar(100) NULL
    ,QtdVitorias				varchar(100) NULL
    ,QtdPodios					varchar(100) NULL
    ,QtdPolePosition			varchar(100) NULL
    ,QtdVoltasRapidas			varchar(100) NULL
    ,IdEquipe int
        FOREIGN KEY (IdEquipe) REFERENCES Equipes(IdEquipe)
);
GO
USE Formula1
Go
insert into Equipes
(
	NomeEquipe, SlugEquipe
)
Select
    [NomeEquipe], REPLACE(LOWER(CONSTRUTOR), ' ', '-')
from
    [Formula1].[dbo].[Equipes2]
    GO
insert into Pilotos
(
  NomePiloto
,NacionalidadePiloto
,IdEquipe
)
Select
    [NomePiloto1]
        ,[NacionalidadePiloto1]
        ,[EquipeID]
from
    [Formula1].[dbo].[Equipes2]
    GO
insert into Pilotos
(
  NomePiloto
,NacionalidadePiloto
,IdEquipe
)
Select
    [NomePiloto2]
        ,[NacionalidadePiloto2]
        ,[EquipeID]
from
    [Formula1].[dbo].[Equipes2]
insert into Carros
(
  ModeloCarro
,FabricanteMotor
,IdEquipe
)
Select
    [Modelo]
        ,[Motor]
        ,[EquipeID]
from
    [Formula1].[dbo].[Equipes2]
    go
insert into Chefes
(
  NomeChefe
,IdEquipe
)
Select
    [NomeChefe]
        ,[EquipeID]
from
    [Formula1].[dbo].[Equipes2]
    go
insert into Conquistas
(
  QtdGrandesPremios
,QtdTitulosConstrutores
,QtdTitulosPilotos
,QtdVitorias
,QtdPodios
,QtdPolePosition
,QtdVoltasRapidas
,IdEquipe
)
Select
    QtdGrandesPremios
     ,QtdTitulosConstrutores
     ,QtdTitulosPilotos
     ,QtdVitorias
     ,QtdPodios
     ,QtdPolePosition
     ,QtdVoltasRapidas
     ,[EquipeID]
from
    [Formula1].[dbo].[Equipes2]
    Go

UPDATE EQUIPES SET UrlImagemExibicao = '/img/LF1_RedBull.png', UrlFotoPilotos = '/img/Pilotos_RedBull.jpg',  CorScuderia = '3px 5px 5px 1px #0008ff', UrlFotoScuderia = '/img/Scuderia_RedBull.jpg' WHERE IDEQUIPE = 1
UPDATE EQUIPES SET UrlImagemExibicao = '/img/LF1_Mercedes.png', UrlFotoPilotos = '/img/Pilotos_Mercedes.jpg',  CorScuderia = '3px 5px 5px 1px #00fffb', UrlFotoScuderia = '/img/Scuderia_Mercedes.jpg' WHERE IDEQUIPE = 2
UPDATE EQUIPES SET UrlImagemExibicao = '/img/RF1_Mclaren.png', UrlFotoPilotos = '/img/Pilotos_McLaren.jpg',  CorScuderia = '3px 5px 5px 1px #ff5900', UrlFotoScuderia = '/img/Scuderia_McLaren.jpg' WHERE IDEQUIPE = 3
UPDATE EQUIPES SET UrlImagemExibicao = '/img/RF1_VisaRB.png', UrlFotoPilotos = '/img/Pilotos_VisaRB.jpg',  CorScuderia = '3px 5px 5px 1px #0062ff', UrlFotoScuderia = '/img/Scuderia_VisaRB.jpg' WHERE IDEQUIPE = 4
UPDATE EQUIPES SET UrlImagemExibicao = '/img/RF1_Stake.png', UrlFotoPilotos = '/img/Pilotos_Stake.jpg',  CorScuderia = '3px 5px 5px 1px #00ff40', UrlFotoScuderia = '/img/Scuderia_Stake.jpg' WHERE IDEQUIPE = 5
UPDATE EQUIPES SET UrlImagemExibicao = '/img/LF1_AstonMartin.png', UrlFotoPilotos = '/img/Pilotos_AstonMartin.jpg',  CorScuderia = '3px 5px 5px 1px #83c3a7', UrlFotoScuderia = '/img/Scuderia_AstonMartin.jpg' WHERE IDEQUIPE = 6
UPDATE EQUIPES SET UrlImagemExibicao = '/img/RF1_Haas.png', UrlFotoPilotos = '/img/Pilotos_Haas.jpg',  CorScuderia = '3px 5px 5px 1px #000000', UrlFotoScuderia = '/img/Scuderia_Haas.jpg' WHERE IDEQUIPE = 7
UPDATE EQUIPES SET UrlImagemExibicao = '/img/LF1_Alpine.png', UrlFotoPilotos = '/img/Pilotos_Alpine.jpg',  CorScuderia = '3px 5px 5px 1px #0055ff', UrlFotoScuderia = '/img/Scuderia_Alpine.jpg' WHERE IDEQUIPE = 8
UPDATE EQUIPES SET UrlImagemExibicao = '/img/LF1_Williams.png', UrlFotoPilotos = '/img/Pilotos_Willians.jpg',  CorScuderia = '3px 5px 5px 1px #0055ff', UrlFotoScuderia = '/img/Scuderia_Willians.jpg' WHERE IDEQUIPE = 9
UPDATE EQUIPES SET UrlImagemExibicao = '/img/RF1_Ferrari.png', UrlFotoPilotos = '/img/Pilotos_Ferrari.jpg',  CorScuderia = '3px 5px 5px 1px #ff0000', UrlFotoScuderia = '/img/Scuderia_Ferrari.jpg' WHERE IDEQUIPE = 10



update Pilotos set UrlFotoPiloto = '/img/Pilotos_RedBull.jpg' WHERE idequipe = 1
update Pilotos set UrlFotoPiloto = '/img/Pilotos_Mercedes.jpg' WHERE idequipe = 2
update Pilotos set UrlFotoPiloto = '/img/Pilotos_McLaren.jpg' WHERE idequipe = 3
update Pilotos set UrlFotoPiloto = '/img/Pilotos_VisaRB.jpg' WHERE idequipe = 4
update Pilotos set UrlFotoPiloto = '/img/Pilotos_Stake.jpg' WHERE idequipe = 5
update Pilotos set UrlFotoPiloto = '/img/Pilotos_AstonMartin.jpg' WHERE idequipe = 6
update Pilotos set UrlFotoPiloto = '/img/Pilotos_Haas.jpg' WHERE idequipe = 7
update Pilotos set UrlFotoPiloto = '/img/Pilotos_Alpine.jpg' WHERE idequipe = 8
update Pilotos set UrlFotoPiloto = '/img/Pilotos_Willians.jpg' WHERE idequipe = 9
update Pilotos set UrlFotoPiloto = '/img/Pilotos_Ferrari.jpg' WHERE idequipe = 10
    go



/*
INSERT INTO Equipes ( 
    NomeEquipe, 
	SlugEquipe ,
	UrlFotoScuderia ,
	UrlFotoPilotos ,
	UrlImagemExibicao ,
	CorScuderia)
	select 'Equipe Léo Tiriba', 'leo-tiriba-f1', '/img/F1_LeoTiriba.png', '/img/F1_LeoTiriba.png', '/img/F1_LeoTiriba.png', '3px 5px 5px 1px #ff0055'
	
insert into Pilotos
(
	 NomePiloto 
    ,NacionalidadePiloto 
	,IdEquipe 
)
Select 
	   'Leo Tiriba'
      ,'Brasileiro'
	  ,11 
GO 
insert into Carros
(
	ModeloCarro 
	,FabricanteMotor 
	,IdEquipe
)
Select 
	 'Subaru'
    ,'2.0'
	,11 
go
insert into Chefes
(
	  NomeChefe 
	 ,IdEquipe
)
Select 
	 'é o Proprio Léo tiriba'
	,11 
go
insert into Conquistas
(
	 QtdGrandesPremios			
	,QtdTitulosConstrutores		
	,QtdTitulosPilotos			
	,QtdVitorias				
	,QtdPodios					
	,QtdPolePosition			
	,QtdVoltasRapidas			
	,IdEquipe 
)
Select 
	  QtdGrandesPremios		
	 ,QtdTitulosConstrutores	
	 ,QtdTitulosPilotos		
	 ,QtdVitorias			
	 ,QtdPodios				
	 ,QtdPolePosition		
	 ,QtdVoltasRapidas		
	,11
from
	[Formula1].[dbo].[Equipes2] Where EquipeID = 1
Go
*/
/*
SELECT 'DROP TABLE ' + NAME FROM SYS.TABLES

DROP if exists TABLE Pilotos
DROP if exists TABLE Carros
DROP if exists TABLE Chefes
DROP if exists TABLE Conquistas
DROP if exists TABLE Equipes
*/
select * from Equipes2
select * from Equipes
select * from Pilotos
select * from Carros
select * from Chefes
select * from Conquistas