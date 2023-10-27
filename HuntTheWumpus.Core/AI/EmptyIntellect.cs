using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Commands.Concrete;
using HuntTheWumpus.Core.Entities;

namespace HuntTheWumpus.Core.AI;

public class EmptyIntellect : ITurnMaker
{
    public ICommand MakeTurn(Actor actor) =>
        new EmptyCommand();
}