using HuntTheWumpus.Core.Common;
using HuntTheWumpus.Core.Rooms;
using HuntTheWumpus.Core.Services.Random;

namespace HuntTheWumpus.Core.Services.World;

public class PlaceRules
{
    private static readonly IRoom BatRoom = new BatRoom();
    private static readonly IRoom PitRoom = new PitRoom();
    private static readonly IRoom EmptyRoom = new EmptyRoom();
    
    private readonly IRandomService _random;

    public PlaceRules(IRandomService random) =>
        _random = random;

    public IRoom PlaceRoom(Vector2 coords)
    {
        var value = _random.Next(10);

        return value switch
        {
            < 1 => BatRoom,
            < 2 => PitRoom,
            _ => EmptyRoom
        };
    }
}