using System.Text;
using HuntTheWumpus.Core.Common;
using HuntTheWumpus.Core.Entities;
using HuntTheWumpus.Core.Rooms;
using HuntTheWumpus.Core.Services.Actors;
using HuntTheWumpus.Core.Services.World;

namespace HuntTheWumpus.Console.View;

public class WorldTextView
{
    private readonly IWorldService _world;
    private readonly IActorsProvider _actors;

    public WorldTextView(IWorldService world, IActorsProvider actors)
    {
        _world = world;
        _actors = actors;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        var size = _world.Size;

        for (var y = 0; y < size.Y; y++)
        {
            for (var x = 0; x < size.X; x++)
            {
                var room = _world.GetRoom(new Vector2(x, y));
                builder.Append(ConvertRoomToSymbol(room));
            }

            builder.Append('\n');
        }

        foreach (var actor in _actors.All)
        {
            var posX = actor.Position.X;
            var posY = actor.Position.Y;
            var position = posX + (size.X * posY + posY);
            builder[position] = ConvertActorToSymbol(actor);
        }

        return builder.ToString();
    }

    private static char ConvertActorToSymbol(Actor actor) =>
        actor switch
        {
            Hunter => 'H',
            Wumpus => 'W',
            _ => throw new Exception("Invalid actor")
        };

    private static char ConvertRoomToSymbol(IRoom room) =>
        room switch
        {
            BatRoom => 'B',
            PitRoom => 'P',
            EmptyRoom => '.',
            _ => throw new Exception("Invalid room!")
        };
}