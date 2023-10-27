namespace HuntTheWumpus.Core.Rules;

public class GameRules
{
    private readonly IGameRule[] _rules;

    public GameRules(params IGameRule[] rules) =>
        _rules = rules;

    public GameResult Process()
    {
        foreach (var rule in _rules)
            if (rule.IsHappened)
                return rule.Process();
        
        return GameResult.Process();
    }
}