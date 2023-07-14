using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong;

public static class ScoreHelper
{
    public static void DrawScore(SpriteBatch spriteBatch, Texture2D texture, Point position, int value)
    {
        switch (value)
        {
            case 0:
                DrawZero(spriteBatch, texture, position);
                break;
            case 1:
                DrawOne(spriteBatch, texture, position);
                break;
            case 2:
                DrawTwo(spriteBatch, texture, position);
                break;
            case 3:
                DrawThree(spriteBatch, texture, position);
                break;
            case 4:
                DrawFour(spriteBatch, texture, position);
                break;
            case 5:
                DrawFive(spriteBatch, texture, position);
                break;
            case 6:
                DrawSix(spriteBatch, texture, position);
                break;
            case 7:
                DrawSeven(spriteBatch, texture, position);
                break;
            case 8:
                DrawEight(spriteBatch, texture, position);
                break;
            case 9:
                DrawNine(spriteBatch, texture, position);
                break;            
        }
    }

    private static void Draw(SpriteBatch spriteBatch, Texture2D texture, Point position)
    {
        spriteBatch.Draw(texture, new Rectangle(new Point(position.X*10, position.Y*10), new Point(10)), Color.LightGray);
    }
    
    private static void DrawZero(SpriteBatch spriteBatch, Texture2D texture, Point position)
    {
        for (var y = 0; y < 5; ++y)
        {
            Draw(spriteBatch, texture, new Point(position.X, position.Y+y));
            Draw(spriteBatch, texture, new Point(position.X+2, position.Y+y));
        }
        
        for (var x = 0; x < 3; ++x)
        {
            Draw(spriteBatch, texture, new Point(position.X+x, position.Y));
            Draw(spriteBatch, texture, new Point(position.X+x, position.Y+4));
        }
    }
    private static void DrawOne(SpriteBatch spriteBatch, Texture2D texture, Point position)
    {
        for (var y = 0; y < 5; ++y)
        {
            Draw(spriteBatch, texture, new Point(position.X+1, position.Y+y));
        }
    }
    private static void DrawTwo(SpriteBatch spriteBatch, Texture2D texture, Point position)
    {
        for (var x = 0; x < 3; ++x)
        {
            Draw(spriteBatch, texture, new Point(position.X+x, position.Y));
            Draw(spriteBatch, texture, new Point(position.X+x, position.Y+2));
            Draw(spriteBatch, texture, new Point(position.X+x, position.Y+4));
        }

        for (var y = 0; y < 5; ++y)
        {
            Draw(spriteBatch, texture, new Point(position.X + (y < 3 ? 2 : 0), position.Y+y));
        }
    }
    
    private static void DrawThree(SpriteBatch spriteBatch, Texture2D texture, Point position)
    {
        for (var x = 0; x < 3; ++x)
        {
            Draw(spriteBatch, texture, new Point(position.X + x, position.Y));
            if (x > 0)
            {
                Draw(spriteBatch, texture, new Point(position.X + x, position.Y + 2));
            }

            Draw(spriteBatch, texture, new Point(position.X + x, position.Y + 4));
        }
        for (var y = 0; y < 5; ++y)
        {
            Draw(spriteBatch, texture, new Point(position.X+2, position.Y+y));
        }
    }    
    
    private static void DrawFour(SpriteBatch spriteBatch, Texture2D texture, Point position)
    {
        for (var x = 0; x < 3; ++x)
        {
            Draw(spriteBatch, texture, new Point(position.X + x, position.Y+2));
        }
        for (var y = 0; y < 5; ++y)
        {
            Draw(spriteBatch, texture, new Point(position.X+2, position.Y+y));
            if (y < 3)
            {
                Draw(spriteBatch, texture, new Point(position.X, position.Y+y));
            }
        }
    }
    private static void DrawFive(SpriteBatch spriteBatch, Texture2D texture, Point position)
    {
        for (var x = 0; x < 3; ++x)
        {
            Draw(spriteBatch, texture, new Point(position.X+x, position.Y));
            Draw(spriteBatch, texture, new Point(position.X+x, position.Y+2));
            Draw(spriteBatch, texture, new Point(position.X+x, position.Y+4));
        }

        for (var y = 0; y < 5; ++y)
        {
            Draw(spriteBatch, texture, new Point(position.X + (y < 3 ? 0 : 2), position.Y+y));
        }
    }
    private static void DrawSix(SpriteBatch spriteBatch, Texture2D texture, Point position)
    {
        for (var x = 0; x < 3; ++x)
        {
            Draw(spriteBatch, texture, new Point(position.X + x, position.Y+2));
            Draw(spriteBatch, texture, new Point(position.X + x, position.Y+4));
        }
        for (var y = 0; y < 5; ++y)
        {
            Draw(spriteBatch, texture, new Point(position.X, position.Y+y));
            if (y > 2)
            {
                Draw(spriteBatch, texture, new Point(position.X+2, position.Y+y));
            }
        }
    }
    private static void DrawSeven(SpriteBatch spriteBatch, Texture2D texture, Point position)
    {
        for (var x = 0; x < 3; ++x)
        {
            Draw(spriteBatch, texture, new Point(position.X + x, position.Y));
        }
        for (var y = 0; y < 5; ++y)
        {
            Draw(spriteBatch, texture, new Point(position.X+2, position.Y+y));
        }
    }
    private static void DrawEight(SpriteBatch spriteBatch, Texture2D texture, Point position)
    {
        for (var y = 0; y < 5; ++y)
        {
            Draw(spriteBatch, texture, new Point(position.X, position.Y+y));
            Draw(spriteBatch, texture, new Point(position.X+2, position.Y+y));
        }
        
        for (var x = 0; x < 3; ++x)
        {
            Draw(spriteBatch, texture, new Point(position.X+x, position.Y));
            Draw(spriteBatch, texture, new Point(position.X+x, position.Y+2));
            Draw(spriteBatch, texture, new Point(position.X+x, position.Y+4));
        }
    }
    private static void DrawNine(SpriteBatch spriteBatch, Texture2D texture, Point position)
    {
        for (var x = 0; x < 3; ++x)
        {
            Draw(spriteBatch, texture, new Point(position.X + x, position.Y));
            Draw(spriteBatch, texture, new Point(position.X + x, position.Y+2));
        }
        for (var y = 0; y < 5; ++y)
        {
            Draw(spriteBatch, texture, new Point(position.X+2, position.Y+y));
            if (y < 3)
            {
                Draw(spriteBatch, texture, new Point(position.X, position.Y+y));
            }
        }
    }
    
}