USE Formula1
GO
DROP TABLE IF EXISTS Equipes
GO
CREATE TABLE Equipes (
    IdEquipe int primary key identity(1,1),
    NomeEquipe VARCHAR(100) NOT NULL,
);
GO
DROP TABLE IF EXISTS Pilotos
GO
Create table Pilotos
(
	IdPiloto int primary key identity(1,1),
	NomePiloto VARCHAR(100) NOT NULL,
    NacionalidadePiloto VARCHAR(50) NOT NULL,
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
	NomeEquipe 
)
Select 
      [NomeEquipe]
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