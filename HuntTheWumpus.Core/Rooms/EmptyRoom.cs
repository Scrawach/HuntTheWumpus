using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Commands.Concrete;
using HuntTheWumpus.Core.Entities;

namespace HuntTheWumpus.Core.Rooms;

public class EmptyRoom : IRoom
{
    private static readonly ICommand Empty = new EmptyCommand();
    
    public ICommand Interaction(Actor target) =>
        Empty;
}