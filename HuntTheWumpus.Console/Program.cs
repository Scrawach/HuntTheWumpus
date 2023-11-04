using HuntTheWumpus.Console.Input;
using HuntTheWumpus.Console.View;
using HuntTheWumpus.Core;
using HuntTheWumpus.Core.Common;

var settings = new GameSettings()
{
    WorldSize = new Vector2(5, 5)
};

var mechanics = GameBuilder.CreateMechanics(settings);
var game = GameBuilder.CreateGame(mechanics, PlayerInputBuilder.Create(mechanics));
var worldTextView = new WorldTextView(mechanics.World, mechanics.Actors);

while (game.Status.IsProcess)
{
    Console.WriteLine(worldTextView);

    foreach (var command in game.Update()) 
        Console.WriteLine($"Executed {command}");

    Console.Clear();
}
Console.WriteLine(new GameEndScreen(game));