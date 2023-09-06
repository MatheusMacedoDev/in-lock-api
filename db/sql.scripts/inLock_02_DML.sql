USE inlock_games;
GO

INSERT INTO Studio([Name])
VALUES ('Blizzard'),('Rockstar Studios'),('Square Enix');
GO

INSERT INTO Game(IdStudio, [Name], [Description], ReleaseDate, Price)
VALUES (1,'Diablo 3','� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.','2012-09-24','99')
	  ,(2,'Red Dead Redemption II','Jogo eletr�nico de a��o-aventura western.','2012-09-27','120');
GO

INSERT INTO UserType(TypeName)
VALUES ('Comum'),('Administrador');
GO

INSERT INTO [User](IdUserType, Email, [Password])
VALUES (1,'cliente@cliente.com','cliente')
      ,(2,'admin@admin.com','admin');
GO

