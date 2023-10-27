using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Services;

namespace HuntTheWumpus.Core.Commands.Concrete;

public class EmptyCommand : CommandBase
{
    public override CommandStatus Execute(ICoreMechanics mechanics) =>
        Success();

    public override string ToString() =>
        $"[Empty command]";
}