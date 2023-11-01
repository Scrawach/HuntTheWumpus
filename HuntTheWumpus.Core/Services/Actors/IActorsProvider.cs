using HuntTheWumpus.Core.Entities;

namespace HuntTheWumpus.Core.Services.Actors;

public interface IActorsProvider
{
    IEnumerable<Actor> All { get; }
    void Add(Actor actor);
}