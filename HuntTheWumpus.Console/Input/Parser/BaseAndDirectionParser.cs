using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Common;
using HuntTheWumpus.Core.Entities;
using HuntTheWumpus.Core.Services.World;

namespace HuntTheWumpus.Console.Input.Parser;

public class BaseAndDirectionParser : IInputCommand
{
    private const string LeftCommand = "left";
    private const string UpCommand = "up";
    private const string RightCommand = "right";
    private const string DownCommand = "down";

    private readonly string _baseCommand;
    private readonly IWorldService _world;
    private readonly InputFactoryFunc _factory;

    public BaseAndDirectionParser(string name, string command, IWorldService world, InputFactoryFunc factory)
    {
        _baseCommand = command;
        _world = world;
        _factory = factory;
        Name = name;
    }

    public string Name { get; }
    
    public string Description => $"Write " +
                                 $"\"{_baseCommand} {UpCommand}\", " +
                                 $"\"{_baseCommand} {DownCommand}\", " +
                                 $"\"{_baseCommand} {LeftCommand}\", " +
                                 $"\"{_baseCommand} {RightCommand}\"";

    public bool TryParse(string? line, Actor actor, out ICommand command)
    {
        command = default;
        
        if (string.IsNullOrWhiteSpace(line))
            return false;

        var pieces = line.Split(" ");

        if (pieces.Length != 2 || pieces[0] != _baseCommand)
            return false;

        var (isValidDirection, direction) = ConvertToVector(pieces[1]);

        if (!isValidDirection) 
            return isValidDirection;
        
        if (_world.IsMovable(actor.Position + direction))
        {
            command = _factory(actor, direction);
        }
        else
        {
            System.Console.WriteLine($"It's wall!");
            return false;
        }

        return isValidDirection;
    }
    
    private static (bool, Vector2) ConvertToVector(string? value) =>
        value?.ToLower() switch
        {
            "up" => (true, Vector2.Down),
            "down" => (true, Vector2.Up),
            "left" => (true, Vector2.Left),
            "right" => (true, Vector2.Right),
            _ => (false, Vector2.Zero)
        };
}