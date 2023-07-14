using System;
using Microsoft.Xna.Framework;
using Pong.Actors;

namespace Pong.Controllers;

public class AiController : Controller
{
    private readonly Actor _ball;
    private readonly PongGame _game;
    private Point? _lastBallPosition;

    private int? _predictedBallY;
    private bool _myTurn;
    public AiController(PongGame game, Actor ball)
    {
        _myTurn = false;
        _game = game;
        _ball = ball;
        _predictedBallY = null;
    }
    public override Direction? GetDirection()
    {
        if (!_lastBallPosition.HasValue)
        {
            _lastBallPosition = _ball.Position;
            return null;
        }
        else
        {
            if (_ball.Position.X - _lastBallPosition.Value.X > 0)
            {
                Direction? direction = null;
                if (!_predictedBallY.HasValue)
                {
                    _predictedBallY = GetProjectedBallY();
                }

                if (_predictedBallY - (Actor.Position.Y + Actor.Size.Y / 2) > 5)
                {
                    direction = Direction.Down;
                }

                if ((Actor.Position.Y + Actor.Size.Y/2) - _predictedBallY  > 5)
                {
                    direction = Direction.Up;
                }
                _lastBallPosition = _ball.Position;
                return direction;
            }
            else
            {
                _predictedBallY = null;
                _lastBallPosition = null;
                return null;
            }
        }
    }

    private int GetProjectedBallY()
    {
        var slope = (_ball.Position.Y - _lastBallPosition!.Value.Y) / (float)(_ball.Position.X - _lastBallPosition.Value.X);
        var yIntercept = _ball.Position.Y - slope * _ball.Position.X;

        var yPrediction = slope * Actor.Position.X + yIntercept;

        var lowerWall = _game.Dimentsions.Y - _ball.Size.Y;
        
        if (yPrediction < 0 || yPrediction > lowerWall)
        {
            var distanceToWall = yPrediction < 0 ? -yPrediction : yPrediction - lowerWall;
            var remainingDistance = distanceToWall % lowerWall;
            yPrediction = yPrediction < 0 ? remainingDistance : lowerWall - remainingDistance;
        }


        var error = Random.Shared.Next(-100, 100);
        
        return (int)(yPrediction+error);
    }
}