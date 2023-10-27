using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Common;
using HuntTheWumpus.Core.Entities;
using HuntTheWumpus.Core.Services;

namespace HuntTheWumpus.Core.Commands.Concrete;

public class InteractRoomCommand : CommandBase
{
    public readonly Actor Actor;
    public readonly Vector2 Position;

    public InteractRoomCommand(Actor actor, Vector2 position)
    {
        Actor = actor;
        Position = position;
    }

    public override CommandStatus Execute(ICoreMechanics mechanics)
    {
        var room = mechanics.World.GetRoom(Position);
        AddChildren(room.Interaction(Actor));
        return Success();
    }

    public override string ToString() =>
        $"[Interact with Room{Position}]";
}