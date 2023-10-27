using HuntTheWumpus.Core.Common;
using HuntTheWumpus.Core.Rooms;

namespace HuntTheWumpus.Core.Services.World;

public class WorldService : IWorldService
{
    private readonly IRoom[,] _map;

    public WorldService(IRoom[,] rooms)
    {
        _map = rooms;
        Size = new Vector2(rooms.GetLength(0), rooms.GetLength(1));
    }
    
    public WorldService(Vector2 size)
    {
        _map = new IRoom[size.X, size.Y];
        Size = size;
    }

    public Vector2 Size { get; }
    
    public IRoom GetRoom(Vector2 coords) =>
        _map[coords.X, coords.Y];

    public bool IsMovable(Vector2 coords) =>
        IsNotWall(coords);

    private bool IsNotWall(Vector2 coords) =>
        coords.X >= 0 && coords.X < _map.GetLength(0) && 
        coords.Y >= 0 && coords.Y < _map.GetLength(1);
}