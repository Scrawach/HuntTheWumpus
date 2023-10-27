using HuntTheWumpus.Core.AI;
using HuntTheWumpus.Core.Commands;
using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Common;
using HuntTheWumpus.Core.Entities;
using HuntTheWumpus.Core.Services;
using HuntTheWumpus.Core.Services.Actors;
using HuntTheWumpus.Core.Services.Random;
using HuntTheWumpus.Core.Services.World;

namespace HuntTheWumpus.Core;

public class Game
{
    private ITurnMaker _wumpusAi;
    private CommandExecutor _executor;
    private Wumpus _wumpus;
    private Hunter _player;
    
    public ICoreMechanics Mechanics { get; private set; }
    
    public bool IsGameOver { get; private set; }

    public void Initialize()
    {
        var random = new RandomService(new Random());
        var defaultRules = new PlaceRules(random);
        var actors = new ActorsProvider();
        var world = new WorldBuilder()
            .WithSize(new Vector2(5, 5))
            .UseRules(defaultRules)
            .Build();

        var mechanics = new CoreMechanics(world, random, actors);

        _player = new Hunter(new Vector2(2, 2));
        actors.Add(_player);
        
        _wumpusAi = new WumpusIntellect(mechanics);
        _wumpus = new Wumpus(new Vector2(4, 4));
        actors.Add(_wumpus);

        Mechanics = mechanics;
        _executor = new CommandExecutor(mechanics);
    }
    
    public IEnumerable<ICommand> Update(ITurnMaker player)
    {
        foreach (var makeTurn in Turns(player))
        foreach (var command in _executor.Execute(makeTurn()))
        {
            yield return command;

            if (IsWumpusEatPlayer())
                IsGameOver = true;
        }
    }

    private bool IsWumpusEatPlayer() =>
        _player.Position == _wumpus.Position;

    private IEnumerable<Func<ICommand>> Turns(ITurnMaker playerTurn) =>
        new[]
        {
            () => playerTurn.MakeTurn(_player),
            () => _wumpusAi.MakeTurn(_wumpus)
        };
}