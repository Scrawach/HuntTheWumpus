using HuntTheWumpus.Core.Common;
using HuntTheWumpus.Core.Rooms;
using HuntTheWumpus.Core.Services.World;

namespace HuntTheWumpus.Core.Extensions;

public static class WorldExtensions
{
    public static IEnumerable<Vector2> RoomPositions(this IWorldService world)
    {
        for (var x = 0; x < world.Size.X; x++)
        for (var y = 0; y < world.Size.Y; y++)
            yield return new Vector2(x, y);
    }

    public static IEnumerable<Vector2> EmptyRoomPositions(this IWorldService world) =>
        world.RoomPositions().Where(roomPosition => world.GetRoom(roomPosition) is EmptyRoom);
}