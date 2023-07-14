using Microsoft.Xna.Framework;

namespace Pong.Actors;

public abstract class Actor
{
    private Point _position;
    private readonly Point _size;
    private readonly float _speed;


    public Point Size => _size;
    public Point Position => _position;
    protected float Speed => _speed;

    public Rectangle Area => new Rectangle(_position, _size);
    
    protected Actor(Point size, Point startPosition, float speed)
    {
        _size = size;
        _position = startPosition;
        _speed = speed;
    }

    protected void AddYPosition(int y)
    {
        _position.Y += y;
    }
    protected void AddXPosition(int x)
    {
        _position.X += x;
    }

    protected void AddPosition(int x, int y)
    {
        AddXPosition(x);
        AddXPosition(y);
    }

    protected void AddPosition(Point delta)
    {
        AddPosition(delta.X, delta.Y);
    }
    
    protected void SetYPosition(int y)
    {
        _position.Y = y;
    }
    protected void SetXPosition(int x)
    {
        _position.X = x;
    }

    protected void SetPosition(int x, int y)
    {
        SetPosition(new Point(x, y));
    }
    protected void SetPosition(Point newPosition)
    {
        _position = newPosition;
    }
    public abstract void Update(GameTime gameTime);
}