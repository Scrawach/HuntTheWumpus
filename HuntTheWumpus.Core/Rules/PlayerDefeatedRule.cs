using HuntTheWumpus.Core.Entities;

namespace HuntTheWumpus.Core.Rules;

public class PlayerDefeatedRule : IGameRule
{
    private readonly Actor _player;

    public PlayerDefeatedRule(Actor player) =>
        _player = player;

    public bool IsHappened => 
        _player.IsDead;

    public GameResult Process() =>
        GameResult.PlayerDefeated();
}