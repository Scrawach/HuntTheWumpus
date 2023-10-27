using HuntTheWumpus.Core.AI;
using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Commands.Concrete;
using HuntTheWumpus.Core.Common;
using HuntTheWumpus.Core.Entities;
using HuntTheWumpus.Core.Services.World;

namespace HuntTheWumpus.Console;

public class PlayerInput : ITurnMaker
{
    private readonly IWorldService _world;

    public PlayerInput(IWorldService world) =>
        _world = world;

    public ICommand MakeTurn(Actor actor)
    {
        while (true)
        {
            System.Console.WriteLine("Select direction: Up, Down, Left, Right");
            System.Console.Write("Your answer: ");

            var input = System.Console.ReadLine();
            var (isValidInput, direction) = ConvertToVector(input);

            if (isValidInput)
            {
                var nextPosition = actor.Position + direction;

                if (_world.IsMovable(actor.Position + direction))
                    return new MoveWithInteractCommand(actor, nextPosition);
                
                System.Console.WriteLine($"This is wall!");
            }
            else
            {
                System.Console.WriteLine("Invalid direction input!");
            }
        }
    }

    private static (bool, Vector2) ConvertToVector(string? value) =>
        value?.ToLower() switch
        {
            "up" => (true, Vector2.Down),
            "down" => (true, Vector2.Up),
            "left" => (true, Vector2.Left),
            "right" => (true, Vector2.Right),
            _ => (false, Vector2.Zero)
        };
}