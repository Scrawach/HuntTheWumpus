using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Common;
using HuntTheWumpus.Core.Entities;
using HuntTheWumpus.Core.Services;

namespace HuntTheWumpus.Core.Commands.Concrete;

public class WumpusMoveCommand : CommandBase
{
    public readonly Actor Actor;
    public readonly Vector2 Target;

    public WumpusMoveCommand(Actor actor, Vector2 target)
    {
        Actor = actor;
        Target = target;
    }

    public override CommandStatus Execute(ICoreMechanics mechanics)
    {
        AddChildren(new AttackCommand(Target));
        AddChildren(new MoveCommand(Actor, Target));
        return Success();
    }

    public override string ToString() =>
        $"[WumpusMove for {Actor} to {Target}]";
}