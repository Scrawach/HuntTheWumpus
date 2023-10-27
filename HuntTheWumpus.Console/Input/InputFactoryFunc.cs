using HuntTheWumpus.Core.Commands.Abstract;
using HuntTheWumpus.Core.Common;
using HuntTheWumpus.Core.Entities;

namespace HuntTheWumpus.Console.Input;

public delegate ICommand InputFactoryFunc(Actor actor, Vector2 position);