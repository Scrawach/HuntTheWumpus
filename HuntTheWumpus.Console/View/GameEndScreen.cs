using HuntTheWumpus.Core;

namespace HuntTheWumpus.Console.View;

public class GameEndScreen
{
    private readonly Game _game;

    public GameEndScreen(Game game) =>
        _game = game;

    public override string ToString()
    {
        if (_game.Result.IsPlayerDefeated)
            return "GAME OVER! Wumpus eat Player!";
        if (_game.Result.IsWumpusDefeated)
            return "CONGRATULATIONS! Player kill Wumpus!";
        if (_game.Result.IsProcess)
            return "The game is not played.";
        
        throw new Exception("Invalid Game Result!");
    }
}