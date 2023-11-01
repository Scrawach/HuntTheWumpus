using HuntTheWumpus.Core.AI;
using HuntTheWumpus.Core.Commands;
using HuntTheWumpus.Core.Entities;
using HuntTheWumpus.Core.Extensions;
using HuntTheWumpus.Core.Rules;
using HuntTheWumpus.Core.Services;
using HuntTheWumpus.Core.Services.Actors;
using HuntTheWumpus.Core.Services.Random;
using HuntTheWumpus.Core.Services.World;

namespace HuntTheWumpus.Core;

public class GameBuilder
{
    public static ICoreMechanics CreateMechanics(GameSettings settings)
    {
        var random = new RandomService(new Random());
        var defaultRules = new PlaceRules(random);
        var actors = new ActorsProvider();
        var world = new WorldBuilder()
            .WithSize(settings.WorldSize)
            .UseRules(defaultRules)
            .Build();

        return new CoreMechanics(world, random, actors);
    }

    public static Game CreateGame(ICoreMechanics mechanics, ITurnMaker playerAi)
    {
        var random = mechanics.Random;
        var world = mechanics.World;
        var actors = mechanics.Actors;
        
        var hunter = new Hunter(random.From(world.EmptyRoomPositions().ToArray()));
        actors.Add(hunter);
        
        var wumpus = new Wumpus(random.From(world.RoomPositionsExcept(hunter.Position).ToArray()));
        actors.Add(wumpus);
        
        var wumpusAi = new WumpusIntellect(mechanics);

        return new Game
        (
            new GameExecutor
            (
                new[]
                {
                    () => playerAi.MakeTurn(hunter),
                    () => wumpusAi.MakeTurn(wumpus)
                },
                new CommandExecutor(mechanics)
            ),
            new GameRules
            (
                new PlayerDefeatedRule(hunter),
                new WumpusDefeatedRule(wumpus)
            )
        );
    }
}