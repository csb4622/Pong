using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Actors;
using Pong.Controllers;

namespace Pong;

public class PongGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private readonly Paddle _playerOne;
    private readonly Paddle _playerTwo;
    private readonly Ball _ball;
    private readonly Point _dimensions;
    private Texture2D _texture;
    private int _playerOneScore;
    private int _playerTwoScore;

    public Point Dimentsions => _dimensions;
    
    public PongGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
        _dimensions = new Point(1024, 768);

        var initialDirection = Random.Shared.Next(0, 2);
        
        _ball = new Ball(new Point(30,30), new Point(_dimensions.X/2-15, _dimensions.Y/2-15), .9f, new Point((initialDirection == 0 ? -1 : 1), 0), this);
        _playerOne = new Paddle(this, new InputController(), new Point(30, 150), new Point(5, _dimensions.Y/2-75), .5f, _ball);
        _playerTwo = new Paddle(this, new AiController(this, _ball),new Point(30, 150), new Point(_dimensions.X-35, _dimensions.Y/2-75), .5f, _ball);
        Reset();
    }

    public void Reset()
    {
        _playerOneScore = 0;
        _playerTwoScore = 0;
    }

    public void AwardPlayerOnePoint()
    {
        _playerOneScore++;
        _ball.Reset(new Point(-1,0));
    }
    
    public void AwardPlayerTwoPoint()
    {
        _playerTwoScore++;
        _ball.Reset(new Point(1,0));
    }    
    
    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _texture = new Texture2D(GraphicsDevice, 1, 1);
        _texture.SetData(new[] { Color.White });
        
        _graphics.PreferredBackBufferWidth = 1024;
        _graphics.PreferredBackBufferHeight = 768;
        _graphics.ApplyChanges();
    }

    protected override void Update(GameTime gameTime)
    {
        Keyboard.GetState();
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        if (_playerOneScore == 10 || _playerTwoScore == 10)
        {
            Exit();
        }

        // TODO: Add your update logic here
        _playerOne.Update(gameTime);
        _playerTwo.Update(gameTime);
        _ball.Update(gameTime);


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        
        // TODO: Add your drawing code here
        _spriteBatch.Begin();


        for (var i = 0; i < _dimensions.Y; i+=10)
        {
            _spriteBatch.Draw(_texture, new Rectangle((_dimensions.X/2-5), i, 10, 5 ), Color.LightGray);    
        }
        
        ScoreHelper.DrawScore(_spriteBatch, _texture, new Point(2, 1), _playerOneScore);
        ScoreHelper.DrawScore(_spriteBatch, _texture, new Point(97, 1), _playerTwoScore);
        
        _spriteBatch.Draw(_texture, new Rectangle(_playerOne.Position, _playerOne.Size), Color.White);
        _spriteBatch.Draw(_texture, new Rectangle(_playerTwo.Position, _playerTwo.Size), Color.White);
        _spriteBatch.Draw(_texture, new Rectangle(_ball.Position, _ball.Size), Color.White);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}