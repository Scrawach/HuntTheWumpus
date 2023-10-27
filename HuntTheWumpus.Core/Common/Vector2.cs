namespace HuntTheWumpus.Core.Common;

public struct Vector2
{
    public static Vector2 Zero => new(0, 0);
    public static Vector2 Up => new(0, 1);
    public static Vector2 Down => new(0, -1);
    public static Vector2 Left => new(-1, 0);
    public static Vector2 Right => new(1, 0);
    
    public readonly int X;
    public readonly int Y;


    public Vector2(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString() =>
        $"({X}, {Y})";

    public static Vector2 operator +(Vector2 left, Vector2 right) =>
        new(left.X + right.X, left.Y + right.Y);

    public static bool operator ==(Vector2 left, Vector2 right) =>
        left.X == right.X && left.Y == right.Y;

    public static bool operator !=(Vector2 left, Vector2 right) =>
        !(left == right);
}