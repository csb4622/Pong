using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace Pong.Actors;

public class Ball: Actor
{
    private Vector2 _velocity;
    private readonly PongGame _game;
    
    
    
    public Ball(Point size, Point startPosition, float speed, Point startVelocity, PongGame game) : base(size, startPosition, speed)
    {
        _game = game;
        _velocity = new Vector2(startVelocity.X, startVelocity.Y);
    }

    public void Reset(Point velocity)
    {
        SetPosition(new Point(_game.Dimentsions.X/2-15, _game.Dimentsions.Y/2-15));
        _velocity = new Vector2(velocity.X, velocity.Y);
    }
    
    public override void Update(GameTime gameTime)
    {
        if (Position.X <= 0)
        {
            _game.AwardPlayerTwoPoint();
        }
        if (Position.X >= _game.Dimentsions.X-Size.X)
        {
            Debug.WriteLine("{0} {1}", Position.X, Position.Y);
            _game.AwardPlayerOnePoint();
        }
        if (Position.Y <= 0)
        {
            _velocity.Y = -_velocity.Y;
        }
        if (Position.Y >= _game.Dimentsions.Y-Size.Y)
        {
            _velocity.Y = -_velocity.Y;
        }
        
        AddXPosition((int)(Speed*gameTime.ElapsedGameTime.Milliseconds*_velocity.X));
        AddYPosition((int)(Speed*gameTime.ElapsedGameTime.Milliseconds*_velocity.Y));
    }

    public void Bounce(Actor paddle)
    {
        _velocity.X = -_velocity.X;
        var distanceFromCenter = (Position.Y + Size.Y/2) - (paddle.Position.Y + paddle.Size.Y/2) ;
        _velocity.Y = distanceFromCenter/100.0f;
    }


}