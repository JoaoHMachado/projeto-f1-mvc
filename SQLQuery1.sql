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