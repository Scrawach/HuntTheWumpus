using HuntTheWumpus.Core.Services;

namespace HuntTheWumpus.Core.Commands.Abstract;

public interface ICommand
{
    IEnumerable<ICommand> Children { get; }
    CommandStatus Execute(ICoreMechanics mechanics);
}