using HuntTheWumpus.Core;

namespace HuntTheWumpus.Console.View;

public class GameEndScreen
{
    private readonly Game _game;

    public GameEndScreen(Game game) =>
        _game = game;

    public override string ToString()
    {
        if (_game.Status.IsPlayerDefeated)
            return "GAME OVER! Wumpus eat Player!";
        if (_game.Status.IsWumpusDefeated)
            return "CONGRATULATIONS! Player kill Wumpus!";
        if (_game.Status.IsProcess)
            return "The game is not played.";
        
        throw new Exception("Invalid Game Result!");
    }
}