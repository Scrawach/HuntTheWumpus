using HuntTheWumpus.Core.Common;

namespace HuntTheWumpus.Core.Services.Random;

public class RandomService : IRandomService
{
    private readonly System.Random _random;

    public RandomService(System.Random random) =>
        _random = random;

    public Vector2 Next(Vector2 maxValues) =>
        new(
            _random.Next(maxValues.X),
            _random.Next(maxValues.Y)
        );

    public int Next(int max) =>
        _random.Next(max);
}