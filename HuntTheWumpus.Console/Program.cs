using HuntTheWumpus.Console;
using HuntTheWumpus.Core;
using HuntTheWumpus.Core.Common;

var settings = new GameSettings()
{
    WorldSize = new Vector2(5, 5)
};

var game = new Game();
game.Initialize(settings);

var worldTextView = new WorldTextView(game.Mechanics.World, game.Mechanics.Actors);
var gameEndScreen = new GameEndScreen(game);
var playerTurnMaker = new PlayerInput(game.Mechanics.World);

Console.WriteLine(worldTextView);
while (game.Result.IsProcess)
{
    foreach (var command in game.Update(playerTurnMaker)) 
        Console.WriteLine($"Executed {command}");

    Console.Clear();
    Console.WriteLine(worldTextView);
}
Console.WriteLine(gameEndScreen);