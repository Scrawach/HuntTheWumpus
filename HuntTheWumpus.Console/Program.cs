using HuntTheWumpus.Console;
using HuntTheWumpus.Core;
using HuntTheWumpus.Core.AI;

var game = new Game();
game.Initialize();

var worldTextView = new WorldTextView(game.Mechanics.World, game.Mechanics.Actors);
var gameEndScreen = new GameEndScreen(game);
var playerTurnMaker = new EmptyIntellect();

while (game.Result.IsProcess)
{
    foreach (var command in game.Update(playerTurnMaker)) 
        Console.WriteLine($"Executed {command}");

    Console.WriteLine(worldTextView);
    await Task.Delay(200);
    Console.Clear();
}
Console.WriteLine(gameEndScreen);