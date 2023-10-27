using HuntTheWumpus.Core.AI;
using HuntTheWumpus.Core.Commands;
using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Common;
using HuntTheWumpus.Core.Entities;
using HuntTheWumpus.Core.Extensions;
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
    
    public GameResult Result { get; private set; }

    public void Initialize(GameSettings settings)
    {
        var random = new RandomService(new Random());
        var defaultRules = new PlaceRules(random);
        var actors = new ActorsProvider();
        var world = new WorldBuilder()
            .WithSize(settings.WorldSize)
            .UseRules(defaultRules)
            .Build();

        var mechanics = new CoreMechanics(world, random, actors);
        
        _player = new Hunter(random.From(world.EmptyRoomPositions().ToArray()));
        actors.Add(_player);
        
        _wumpusAi = new WumpusIntellect(mechanics);
        _wumpus = new Wumpus(random.From(world.RoomPositions().ToArray()));
        actors.Add(_wumpus);

        Mechanics = mechanics;
        _executor = new CommandExecutor(mechanics);
        
        Result = GameResult.Process();
    }
    
    public IEnumerable<ICommand> Update(ITurnMaker player)
    {
        foreach (var makeTurn in Turns(player))
        foreach (var command in _executor.Execute(makeTurn()))
        {
            yield return command;

            if (_player.IsDead)
                Result = GameResult.PlayerDefeated();

            if (_wumpus.IsDead)
                Result = GameResult.WumpusDefeated();
        }
    }

    private IEnumerable<Func<ICommand>> Turns(ITurnMaker playerTurn) =>
        new[]
        {
            () => playerTurn.MakeTurn(_player),
            () => _wumpusAi.MakeTurn(_wumpus)
        };
}