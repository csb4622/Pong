using Microsoft.Xna.Framework;
using Pong.Controllers;

namespace Pong.Actors;

public class Paddle: Actor
{
    private readonly Controller _controller;
    private readonly Ball _ball;
    private readonly PongGame _game;
   
    
    public Paddle(PongGame game, Controller controller, Point size, Point startPosition, float speed, Ball ball) : base(size, startPosition, speed)
    {
        _game = game;
        _ball = ball;
        _controller = controller;
        _controller.SetControlledActor(this);
    }

    public override void Update(GameTime gameTime)
    {
        if (Area.Intersects(_ball.Area))
        {
            _ball.Bounce(this);
        }
        var newDirection = _controller.GetDirection();

        
        if (newDirection.HasValue)
        {
            AddYPosition((int)(Speed * gameTime.ElapsedGameTime.Milliseconds * (newDirection == Direction.Up ? -1 : 1)));
        }

        if ((Position.Y + Size.Y / 2) < 0)
        {
            SetYPosition(0-Size.Y/2);
        }
        if ((Position.Y + Size.Y / 2) > _game.Dimentsions.Y-1)
        {
            SetYPosition((_game.Dimentsions.Y-1)-Size.Y/2);
        }        
    }
}