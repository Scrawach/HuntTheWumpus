using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Rules;

namespace HuntTheWumpus.Core;

public class Game
{
    private readonly GameExecutor _executor;
    private readonly GameRules _rules;

    public Game(GameExecutor executor, GameRules rules)
    {
        _executor = executor;
        _rules = rules;
    }

    public GameResult Status { get; private set; } = GameResult.Process();

    public IEnumerable<ICommand> Update()
    {
        foreach (var command in _executor.Execute())
        {
            yield return command;
            Status = _rules.Process();
        }
    }
}