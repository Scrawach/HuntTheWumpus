using HuntTheWumpus.Core.AI;
using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Entities;

namespace HuntTheWumpus.Console.Input;

public class PlayerInput : ITurnMaker
{
    private readonly IInputCommand[] _inputCommands;

    public PlayerInput(params IInputCommand[] inputCommands) =>
        _inputCommands = inputCommands;

    public ICommand MakeTurn(Actor actor)
    {
        while (true)
        {
            System.Console.WriteLine("Available commands:");
            foreach (var command in _inputCommands) 
                System.Console.WriteLine($"{command.Name}: {command.Description}");

            System.Console.Write("\nYour answer: ");
            var input = System.Console.ReadLine();

            foreach (var command in _inputCommands)
                if (command.TryParse(input, actor, out var result))
                    return result;

            System.Console.WriteLine($"Invalid input!");
        }
    }
}