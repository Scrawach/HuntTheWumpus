using HuntTheWumpus.Core.Entities;

namespace HuntTheWumpus.Core.Rules;

public class WumpusDefeatedRule : IGameRule
{
    private readonly Actor _wumpus;

    public WumpusDefeatedRule(Actor wumpus) =>
        _wumpus = wumpus;

    public bool IsHappened => 
        _wumpus.IsDead;
    
    public GameResult Process() =>
        GameResult.WumpusDefeated();
}