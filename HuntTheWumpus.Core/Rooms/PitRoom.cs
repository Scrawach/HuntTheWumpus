using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Commands.Concrete;
using HuntTheWumpus.Core.Entities;

namespace HuntTheWumpus.Core.Rooms;

public class PitRoom : IRoom
{
    public ICommand Interaction(Actor target) =>
        new DieCommand(target);
}