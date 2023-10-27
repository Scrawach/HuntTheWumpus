using HuntTheWumpus.Core.Services.Actors;
using HuntTheWumpus.Core.Services.Random;
using HuntTheWumpus.Core.Services.World;

namespace HuntTheWumpus.Core.Services;

public class CoreMechanics : ICoreMechanics
{
    public CoreMechanics(IWorldService world, IRandomService random, IActorsProvider actors)
    {
        World = world;
        Random = random;
        Actors = actors;
    }

    public IWorldService World { get; }
    public IRandomService Random { get; }
    public IActorsProvider Actors { get; }
}