using Pong.Actors;

namespace Pong.Controllers;

public abstract class Controller
{
    private Actor? _actor;

    protected Actor Actor => _actor!;

    public void SetControlledActor(Actor actor)
    {
        _actor = actor;
    }
    public abstract Direction? GetDirection();
}