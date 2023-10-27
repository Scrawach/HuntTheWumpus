using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Entities;

namespace HuntTheWumpus.Console.Input;

public interface IInputCommand
{
    string Name { get; }
    string Description { get; }
    bool TryParse(string? line, Actor actor, out ICommand command);
}