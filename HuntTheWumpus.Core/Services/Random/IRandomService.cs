using HuntTheWumpus.Core.Common;

namespace HuntTheWumpus.Core.Services.Random;

public interface IRandomService
{
    Vector2 Next(Vector2 maxValues);
    int Next(int max);
}