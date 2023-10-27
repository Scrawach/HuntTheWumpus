using HuntTheWumpus.Console;
using HuntTheWumpus.Console.Input;
using HuntTheWumpus.Console.Input.Parser;
using HuntTheWumpus.Core;
using HuntTheWumpus.Core.Commands.Concrete;
using HuntTheWumpus.Core.Common;

var settings = new GameSettings()
{
    WorldSize = new Vector2(5, 5)
};

var game = new Game();
game.Initialize(settings);

var worldTextView = new WorldTextView(game.Mechanics.World, game.Mechanics.Actors);
var gameEndScreen = new GameEndScreen(game);
var playerTurnMaker = new PlayerInput
(
    new BaseAndDirectionParser("Movement", "move", game.Mechanics.World, (actor, direction) => new PlayerMoveCommand(actor, actor.Position + direction)),
    new BaseAndDirectionParser("Shoot", "shoot", game.Mechanics.World, (actor, direction) => new AttackCommand(actor.Position + direction))
);

Console.WriteLine(worldTextView);
while (game.Result.IsProcess)
{
    foreach (var command in game.Update(playerTurnMaker)) 
        Console.WriteLine($"Executed {command}");

    Console.Clear();
    Console.WriteLine(worldTextView);
}
Console.WriteLine(gameEndScreen);