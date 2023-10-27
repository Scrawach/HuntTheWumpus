using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Common;
using HuntTheWumpus.Core.Entities;
using HuntTheWumpus.Core.Services;

namespace HuntTheWumpus.Core.Commands.Concrete;

public class MoveWithInteractCommand : CommandBase
{
    public readonly Actor Actor;
    public readonly Vector2 Target;

    public MoveWithInteractCommand(Actor actor, Vector2 target)
    {
        Actor = actor;
        Target = target;
    }

    public override CommandStatus Execute(ICoreMechanics mechanics)
    {
        AddChildren(new MoveCommand(Actor, Target));
        AddChildren(new InteractRoomCommand(Actor, Target));
        return Success();
    }

    public override string ToString() =>
        $"[Move and interact]: {Actor} on {Target}";
}