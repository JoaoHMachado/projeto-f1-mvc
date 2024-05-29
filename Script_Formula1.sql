USE MASTER
Go
DROP DATABASE IF EXISTS Formula1
GO
CREATE DATABASE Formula1
GO
USE Formula1
GO
DROP TABLE IF EXISTS Equipes
GO
-- Tabela Equipes
CREATE TABLE Equipes (
    EquipeID INT ,
    NomeEquipe VARCHAR(100) NOT NULL,
    Construtor VARCHAR(100) NOT NULL,
	NomeChefe VARCHAR(100) NOT NULL,
	NomePiloto1 VARCHAR(100) NOT NULL,
    NacionalidadePiloto1 VARCHAR(50) NOT NULL,
	NomePiloto2 VARCHAR(100) NOT NULL,
    NacionalidadePiloto2 VARCHAR(50) NOT NULL,
	Modelo VARCHAR(100) NOT NULL,
	Motor VARCHAR(100) NOT NULL

);
GO
-- Inserir informações na tabela Equipes
INSERT INTO Equipes (EquipeID, NomeEquipe, Construtor, NomeChefe, NomePiloto1, NacionalidadePiloto1, NomePiloto2, NacionalidadePiloto2, Modelo, Motor)
VALUES
    (1, 'Oracle Red Bull Racing', 'Red Bull Racing-Honda RBPT', 'Christian Horner', 'Max Verstappen', 'Holandês', 'Sergio Pérez', 'Mexicano', 'RB20', 'Honda RBPT'),
    (2, 'Mercedes-AMG Petronas F1 Team', 'Mercedes', 'Toto Wolff', 'Lewis Hamilton', 'Britânico', 'George Russell', 'Britânico', 'F1 W15', 'Mercedes'),
    (3, 'McLaren F1 Team', 'McLaren-Mercedes', 'Andrea Stela', 'Lando Norris', 'Britânico', 'Oscar Piastri', 'Australiano', 'MCL38', 'Mercedes'),
    (4, 'Visa Cash App RB F1 Team', 'RB-Honda RBPT', 'Laurent Mekies', 'Daniel Ricciardo', 'Australiano', 'Yuki Tsunoda', 'Japonês', 'VCARB 01', 'Honda RBPT'),
    (5, 'Stake F1 Team Kick Sauber', 'Kick-Sauber-Ferrari', 'Alessandro Alunni Bravi', 'Guanyu Zhou', 'Chines', 'Valtteri Bottas', 'Finlandês', 'C44', 'Ferrari'),
    (6, 'Aston Martin Aramco F1 Team', 'Aston Martin Aramco-Mercedes', 'Mike Krack', 'Fernando Alonso', 'Espanhol', 'Lance Stroll', 'Canadense', 'AMR24', 'Mercedes'),
    (7, 'MoneyGram Haas F1 Team', 'Haas-Ferrari', 'Ayao Komatsu', 'Kevin Magnussen', 'Dinamarquês', 'Nico Hülkenberg', 'Alemão', 'VF-24', 'Ferrari'),
    (8, 'BWT Alpine F1 Team', 'Alpine-Renault', 'Bruno Famin', 'Pierre Gasly', 'Francês', 'Esteban Ocon', 'Francês', 'A524','Renault'),
    (9, 'Williams Racing', 'Williams-Mercedes', 'James Vowles', 'Logan Sargeant', 'Estadunidense', 'Alexander Albon', 'Anglo-tailandês', 'FW46', 'Mercedes'),
    (10, 'Scuderia Ferrari HP', 'Ferrari', 'Frederic Vasseur', 'Carlos Sainz Jr', 'Espanhol', 'Charles Leclerc', 'Monegasco', 'SF-24', 'Ferrari');
GO
alter table FORMULA1.dbo.Equipes add QtdGrandesPremios				varchar(100) NULL
alter table FORMULA1.dbo.Equipes add QtdTitulosConstrutores			varchar(100) NULL
alter table FORMULA1.dbo.Equipes add QtdTitulosPilotos				varchar(100) NULL
alter table FORMULA1.dbo.Equipes add QtdVitorias					varchar(100) NULL
alter table FORMULA1.dbo.Equipes add QtdPodios						varchar(100) NULL
alter table FORMULA1.dbo.Equipes add QtdPolePosition				varchar(100) NULL
alter table FORMULA1.dbo.Equipes add QtdVoltasRapidas				varchar(100) NULL
Go
Create procedure SP_Update_DadosEquipesViaWikipedia
(
	 @IdEquipe				int
	,@GrandesPremios		varchar(100)
	,@TitulosConstrutores	varchar(100)
	,@TitulosPilotos		varchar(100)
	,@Vitorias				varchar(100)
	,@Podios				varchar(100)
	,@PolePosition			varchar(100)
	,@VoltasRapidas			varchar(100)
)
AS 
BEGIN
	IF(CHARINDEX ( '[' , @GrandesPremios, 1 ) > 1)
	BEGIN
		SET @GrandesPremios	  	 =  SUBSTRING(@GrandesPremios		, 1, (LEN(@GrandesPremios		) - LEN(SUBSTRING(@GrandesPremios	  	, CHARINDEX ( '[' , @GrandesPremios, 1 )		, 100))))
	END
	IF(CHARINDEX ( '[' , @TitulosConstrutores, 1 ) > 1)
	BEGIN
		SET @TitulosConstrutores =  SUBSTRING(@TitulosConstrutores	, 1, (LEN(@TitulosConstrutores	) - LEN(SUBSTRING(@TitulosConstrutores	, CHARINDEX ( '[' , @TitulosConstrutores, 1 )	, 100))))
	END
	IF(@TitulosConstrutores like '0 %')
	BEGIN
		SET @TitulosConstrutores = LEFT(@TitulosConstrutores,1)
	END
	IF(CHARINDEX ( '[' , @TitulosPilotos, 1 ) > 1)
	BEGIN
		SET @TitulosPilotos		 =  SUBSTRING(@TitulosPilotos		, 1, (LEN(@TitulosPilotos		) - LEN(SUBSTRING(@TitulosPilotos	  	, CHARINDEX ( '[' , @TitulosPilotos, 1 )		, 100))))
	END
	IF(@TitulosPilotos like '0 %')
	BEGIN
		SET @TitulosPilotos = LEFT(@TitulosPilotos,1)
	END
	IF(CHARINDEX ( '[' , @Vitorias, 1 ) > 1)
	BEGIN
		SET @Vitorias			 =  SUBSTRING(@Vitorias	  			, 1, (LEN(@Vitorias	  			) - LEN(SUBSTRING(@Vitorias	  			, CHARINDEX ( '[' , @Vitorias, 1 )				, 100))))
	END
		IF(CHARINDEX ( '[' , @Podios, 1 ) > 1)
	BEGIN
		SET @Podios				 =  SUBSTRING(@Podios	  			, 1, (LEN(@Podios	  			) - LEN(SUBSTRING(@Podios	  			, CHARINDEX ( '[' , @Podios, 1 )				, 100))))
	END
		IF(CHARINDEX ( '[' , @PolePosition, 1 ) > 1)
	BEGIN
		SET @PolePosition		 =  SUBSTRING(@PolePosition	  		, 1, (LEN(@PolePosition	  		) - LEN(SUBSTRING(@PolePosition	  		, CHARINDEX ( '[' , @PolePosition, 1 )				, 100))))
	END
		IF(CHARINDEX ( '[' , @VoltasRapidas, 1 ) > 1)
	BEGIN
		SET @VoltasRapidas		 =  SUBSTRING(@VoltasRapidas		, 1, (LEN(@VoltasRapidas		) - LEN(SUBSTRING(@VoltasRapidas	  	, CHARINDEX ( '[' , @VoltasRapidas, 1 )				, 100))))
	END
	UPDATE
		FORMULA1.dbo.Equipes 
	set 
		 QtdGrandesPremios		 = TRIM(REPLACE(REPLACE(@GrandesPremios	  		, ')', ''),'(',''))
		,QtdTitulosConstrutores	 = TRIM(@TitulosConstrutores	)
		,QtdTitulosPilotos		 = TRIM(@TitulosPilotos			)
		,QtdVitorias			 = TRIM(@Vitorias				)
		,QtdPodios				 = TRIM(@Podios					)
		,QtdPolePosition		 = TRIM(@PolePosition			)
		,QtdVoltasRapidas		 = TRIM(@VoltasRapidas			)
	where 														
		EquipeID = @IdEquipe
END

