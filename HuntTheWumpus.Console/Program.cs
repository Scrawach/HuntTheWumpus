using HuntTheWumpus.Console;
using HuntTheWumpus.Core;
using HuntTheWumpus.Core.AI;

var game = new Game();
game.Initialize();

var worldTextView = new WorldTextView(game.Mechanics.World, game.Mechanics.Actors);
var playerTurnMaker = new EmptyIntellect();

while (!game.IsGameOver)
{
    foreach (var command in game.Update(playerTurnMaker)) 
        Console.WriteLine($"Executed {command}");

    Console.WriteLine(worldTextView);
    await Task.Delay(200);
    Console.Clear();
}
Console.WriteLine($"GAME OVER!");