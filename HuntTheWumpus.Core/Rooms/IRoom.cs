using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Entities;

namespace HuntTheWumpus.Core.Rooms;

public interface IRoom
{
    ICommand Interaction(Actor target);
}