using HuntTheWumpus.Core.Common;
using HuntTheWumpus.Core.Rooms;

namespace HuntTheWumpus.Core.Services.World;

public interface IWorldService
{
    Vector2 Size { get; }
    IRoom GetRoom(Vector2 coords);
    bool IsMovable(Vector2 coords);
}