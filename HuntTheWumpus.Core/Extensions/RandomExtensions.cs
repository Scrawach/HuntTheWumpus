using HuntTheWumpus.Core.Common;
using HuntTheWumpus.Core.Services.Random;

namespace HuntTheWumpus.Core.Extensions;

public static class RandomExtensions
{
    public static Vector2 From(this IRandomService random, Vector2[] positions)
    {
        var index = random.Next(positions.Length);
        return positions[index];
    }
}