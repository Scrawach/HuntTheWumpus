namespace HuntTheWumpus.Core.Rules;

public interface IGameRule
{
    bool IsHappened { get; }
    
    GameResult Process();
}