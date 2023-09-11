USE inlock_games;

SELECT * FROM UserType;

SELECT * FROM [User];

SELECT * FROM Studio;

SELECT * FROM Game;

SELECT Game.[Name] AS Jogo, Studio.[Name] AS Estúdio From Game
INNER JOIN Studio
ON Game.IdStudio = Studio.Id;

SELECT * FROM Game JOIN Studio ON Game.IdStudio = Studio.Id;

SELECT Studio.[Name] AS Estúdio, Game.[Name] AS Jogo FROM Studio
LEFT JOIN Game
ON Studio.Id = Game.IdStudio;

SELECT * FROM [User] WHERE Email = 'cliente@cliente.com' AND [Password] = 'cliente';

SELECT * FROM Game WHERE Id = 4;

SELECT * FROM Studio WHERE Id = 2;

SELECT Studio.Id, Studio.[Name], Game.[Name] FROM Studio
LEFT JOIN Game
ON Studio.Id = Game.IdStudio;



