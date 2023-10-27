using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Commands.Concrete;
using HuntTheWumpus.Core.Common;
using HuntTheWumpus.Core.Entities;
using HuntTheWumpus.Core.Services;
using HuntTheWumpus.Core.Services.Random;
using HuntTheWumpus.Core.Services.World;

namespace HuntTheWumpus.Core.AI;

public class WumpusIntellect : ITurnMaker
{
    private readonly ICoreMechanics _mechanics;

    public WumpusIntellect(ICoreMechanics mechanics) =>
        _mechanics = mechanics;

    public ICommand MakeTurn(Actor actor)
    {
        var isSleep = _mechanics.Random.Next(4) > 0;
        return isSleep 
            ? new EmptyCommand() 
            : ProcessMovement(actor, _mechanics.Random, _mechanics.World);
    }

    private static ICommand ProcessMovement(Actor actor, IRandomService random, IWorldService world)
    {
        var directions = GetAvailableDirectionFrom(actor.Position, world);
        var index = random.Next(directions.Count);
        return new MoveCommand(actor, actor.Position + directions[index]);
    }

    private static IReadOnlyList<Vector2> GetAvailableDirectionFrom(Vector2 point, IWorldService world)
    {
        var directions = new[] { Vector2.Left, Vector2.Up, Vector2.Right, Vector2.Down, };
        return directions.Where(direction => world.IsMovable(point + direction)).ToList();
    }
}