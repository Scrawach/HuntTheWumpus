using HuntTheWumpus.Core.Common;
using HuntTheWumpus.Core.Rooms;

namespace HuntTheWumpus.Core.Services.World;

public class WorldBuilder
{
    private PlaceRules _rules;
    private Vector2 _size;
    
    public WorldBuilder WithSize(Vector2 size)
    {
        _size = size;
        return this;
    }

    public WorldBuilder UseRules(PlaceRules rules)
    {
        _rules = rules;
        return this;
    }

    public IWorldService Build()
    {
        var map = new IRoom[_size.X, _size.Y];
        
        for (var x = 0; x < map.GetLength(0); x++)
        for (var y = 0; y < map.GetLength(1); y++)
            map[x, y] = _rules.PlaceRoom(new Vector2(x, y));

        return new WorldService(map);
    }
}