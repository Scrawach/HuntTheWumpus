using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Entities;
using HuntTheWumpus.Core.Services;

namespace HuntTheWumpus.Core.Commands.Concrete;

public class DieCommand : CommandBase
{
    public readonly Actor Actor;

    public DieCommand(Actor actor) =>
        Actor = actor;

    public override CommandStatus Execute(ICoreMechanics mechanics) =>
        Success();

    public override string ToString() =>
        $"[{Actor} died]";
}