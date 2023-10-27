using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Entities;
using HuntTheWumpus.Core.Services;

namespace HuntTheWumpus.Core.Commands.Concrete;

public class TeleportToRandomRoomCommand : CommandBase
{
    public readonly Actor Actor;

    public TeleportToRandomRoomCommand(Actor actor) =>
        Actor = actor;
    
    public override CommandStatus Execute(ICoreMechanics mechanics)
    {
        var randomCoords = mechanics.Random.Next(mechanics.World.Size);
        AddChildren(new PlayerMoveCommand(Actor, randomCoords));
        return Success();
    }

    public override string ToString() =>
        $"[Teleport {Actor} to random place]";
}