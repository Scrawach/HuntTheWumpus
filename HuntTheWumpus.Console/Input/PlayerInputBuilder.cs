using HuntTheWumpus.Console.Input.Parser;
using HuntTheWumpus.Core.Commands.Concrete;
using HuntTheWumpus.Core.Services;

namespace HuntTheWumpus.Console.Input;

public class PlayerInputBuilder
{
    public static PlayerInput Create(ICoreMechanics mechanics) =>
        new(
            new BaseAndDirectionParser("Movement", "move", mechanics.World, (actor, direction) => new PlayerMoveCommand(actor, actor.Position + direction)),
            new BaseAndDirectionParser("Shoot", "shoot", mechanics.World, (actor, direction) => new AttackCommand(actor.Position + direction))
        );
}