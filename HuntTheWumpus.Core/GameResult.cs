namespace HuntTheWumpus.Core;

public struct GameResult
{
    public bool IsProcess { get; private init; }
    public bool IsPlayerDefeated { get; private init; }
    public bool IsWumpusDefeated { get; private init; }

    public static GameResult Process() =>
        new() { IsProcess = true };
    
    public static GameResult PlayerDefeated() =>
        new() { IsPlayerDefeated = true};

    public static GameResult WumpusDefeated() =>
        new() { IsWumpusDefeated = true};
}