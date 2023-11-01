using HuntTheWumpus.Core.Commands;
using HuntTheWumpus.Core.Commands.Abstract;

namespace HuntTheWumpus.Core;

public class GameExecutor
{
    private readonly IEnumerable<Func<ICommand>> _turnMakers;
    private readonly CommandExecutor _executor;
    
    public GameExecutor(IEnumerable<Func<ICommand>> turnMakers, CommandExecutor executor)
    {
        _turnMakers = turnMakers;
        _executor = executor;
    }

    public IEnumerable<ICommand> Execute() =>
        _turnMakers.SelectMany(maker => _executor.Execute(maker.Invoke()));
}