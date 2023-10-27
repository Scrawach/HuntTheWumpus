using HuntTheWumpus.Core.Services.Actors;
using HuntTheWumpus.Core.Services.Random;
using HuntTheWumpus.Core.Services.World;

namespace HuntTheWumpus.Core.Services;

public interface ICoreMechanics
{
    IWorldService World { get; }
    IRandomService Random { get; }
    IActorsProvider Actors { get; }
}