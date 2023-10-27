using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Entities;
using HuntTheWumpus.Core.Services;

namespace HuntTheWumpus.Core.Commands.Concrete;

public class TeleportToRandomPlaceCommand : CommandBase
{
    public readonly Actor Actor;

    public TeleportToRandomPlaceCommand(Actor actor) =>
        Actor = actor;
    
    public override CommandStatus Execute(ICoreMechanics mechanics)
    {
        var randomCoords = mechanics.Random.Next(mechanics.World.Size);
        AddChildren(new MoveWithInteractCommand(Actor, randomCoords));
        return Success();
    }

    public override string ToString() =>
        $"[Teleport {Actor} to random place]";
}