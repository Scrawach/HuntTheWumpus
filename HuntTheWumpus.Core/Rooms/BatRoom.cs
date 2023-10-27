using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Commands.Concrete;
using HuntTheWumpus.Core.Entities;

namespace HuntTheWumpus.Core.Rooms;

public class BatRoom : IRoom
{
    public ICommand Interaction(Actor target) =>
        new TeleportToRandomRoomCommand(target);
}