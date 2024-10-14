CREATE DATABASE ChessServer_DB
USE ChessServer_DB

CREATE TABLE Users
(
	UserId int IDENTITY(1,1) NOT NULL,
	Username nvarchar(50),
	Password nvarchar(64) NOT NULL,
	Email nvarchar(50),
	Rating int
)

CREATE TABLE Games
(
	GameId int IDENTITY(1,1) NOT NULL,
	Player1ID int,
	Player2ID int,
	StartTime smalldatetime,
	EndTime smalldatetime,
	Status varchar(20),
	WinnerId int NULL
)

CREATE TABLE Moves
(
	MoveId int IDENTITY(1,1),
	GameId int,
	PlayerId int,
	MoveNote varchar(10)
)

ALTER TABLE Users ADD CONSTRAINT PK_Users PRIMARY KEY (UserId)
ALTER TABLE Games ADD CONSTRAINT PK_Games PRIMARY KEY (GameId)
ALTER TABLE Games ADD CONSTRAINT PK_Moves PRIMARY KEY (MoveId)

ALTER TABLE Games ADD CONSTRAINT FK_Games_Users1 FOREIGN KEY (Player1ID) REFERENCES Users(UserId)
ALTER TABLE Games ADD CONSTRAINT FK_Games_Users2 FOREIGN KEY (Player2ID) REFERENCES Users(UserId)
ALTER TABLE Games ADD CONSTRAINT FK_Games_Winner FOREIGN KEY (WinnerId) REFERENCES Users(UserId)
ALTER TABLE Moves ADD CONSTRAINT FK_Moves_Games FOREIGN KEY (GameId) REFERENCES Games(GameId)
ALTER TABLE Moves ADD CONSTRAINT FK_Moves_Users FOREIGN KEY (PlayerID) REFERENCES Users(UserId)

ALTER TABLE Users ADD CONSTRAINT UQ_Username UNIQUE (Username)
ALTER TABLE Users ADD CONSTRAINT UQ_Enail UNIQUE (Email)
ALTER TABLE Users ADD CONSTRAINT DF_Rating DEFAULT 1200 FOR Rating

