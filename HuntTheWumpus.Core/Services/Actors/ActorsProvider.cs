using HuntTheWumpus.Core.Entities;

namespace HuntTheWumpus.Core.Services.Actors;

public class ActorsProvider : IActorsProvider
{
    private readonly List<Actor> _actors = new();

    public IEnumerable<Actor> All => _actors;

    public void Add(Actor actor) =>
        _actors.Add(actor);
}