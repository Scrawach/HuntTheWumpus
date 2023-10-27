using HuntTheWumpus.Core.Common;

namespace HuntTheWumpus.Core.Entities;

public class Actor
{
    public Actor(string name, Vector2 position)
    {
        Name = name;
        Position = position;
    }

    public string Name { get; }
    
    public Vector2 Position { get; set; }
    
    public bool IsDead { get; set; }

    public override string ToString() =>
        $"{Name}";
}