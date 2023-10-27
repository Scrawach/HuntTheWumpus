using HuntTheWumpus.Core.Services;

namespace HuntTheWumpus.Core.Commands.Abstract;

public abstract class CommandBase : ICommand
{
    private readonly List<ICommand> _children = new List<ICommand>();

    public IEnumerable<ICommand> Children => _children;

    public CommandStatus Status = CommandStatus.Unknown();

    public abstract CommandStatus Execute(ICoreMechanics mechanics);

    protected void AddChildren(ICommand child) =>
        _children.Add(child);
    
    protected CommandStatus Success() => CommandStatus.Success();

    protected CommandStatus Failure() => CommandStatus.Failure();
}