using HuntTheWumpus.Console.Input;
using HuntTheWumpus.Console.Input.Parser;
using HuntTheWumpus.Console.View;
using HuntTheWumpus.Core;
using HuntTheWumpus.Core.Commands.Concrete;
using HuntTheWumpus.Core.Common;

var settings = new GameSettings()
{
    WorldSize = new Vector2(5, 5)
};

var mechanics = GameBuilder.CreateMechanics(settings);

var worldTextView = new WorldTextView(mechanics.World, mechanics.Actors);
var playerTurnMaker = new PlayerInput
(
    new BaseAndDirectionParser("Movement", "move", mechanics.World, (actor, direction) => new PlayerMoveCommand(actor, actor.Position + direction)),
    new BaseAndDirectionParser("Shoot", "shoot", mechanics.World, (actor, direction) => new AttackCommand(actor.Position + direction))
);

var game = GameBuilder.CreateGame(mechanics, playerTurnMaker);
var gameEndScreen = new GameEndScreen(game);

Console.WriteLine(worldTextView);
while (game.Status.IsProcess)
{
    foreach (var command in game.Update()) 
        Console.WriteLine($"Executed {command}");

    Console.Clear();
    Console.WriteLine(worldTextView);
}
Console.WriteLine(gameEndScreen);