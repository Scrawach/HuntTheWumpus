using HuntTheWumpus.Core.Common;

namespace HuntTheWumpus.Core.Entities;

public class Wumpus : Actor
{
    public Wumpus(Vector2 position) 
        : base("Wumpus", position) { }
}