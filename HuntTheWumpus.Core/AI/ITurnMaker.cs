using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Entities;

namespace HuntTheWumpus.Core.AI;

public interface ITurnMaker
{
    ICommand MakeTurn(Actor actor);
}