using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Common;
using HuntTheWumpus.Core.Entities;
using HuntTheWumpus.Core.Services;

namespace HuntTheWumpus.Core.Commands.Concrete;

public class MoveCommand : CommandBase
{
    public readonly Actor Actor;
    public readonly Vector2 Target;

    public MoveCommand(Actor actor, Vector2 target)
    {
        Actor = actor;
        Target = target;
    }

    public override CommandStatus Execute(ICoreMechanics mechanics)
    {
        var isMovable = mechanics.World.IsMovable(Target);

        if (!isMovable || Actor.IsDead) 
            return Failure();
        
        Actor.Position = Target;
        return Success();
    }

    public override string ToString() =>
        $"[Move {Actor} to {Target}]";
}