using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Common;
using HuntTheWumpus.Core.Services;

namespace HuntTheWumpus.Core.Commands.Concrete;

public class AttackCommand : CommandBase
{
    public readonly Vector2 Target;

    public AttackCommand(Vector2 target) =>
        Target = target;

    public override CommandStatus Execute(ICoreMechanics mechanics)
    {
        foreach (var actor in mechanics.Actors.All)
        {
            if (actor.Position == Target)
                AddChildren(new DieCommand(actor));
        }

        return Success();
    }
}