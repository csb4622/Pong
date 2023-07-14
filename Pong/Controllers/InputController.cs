using Microsoft.Xna.Framework.Input;

namespace Pong.Controllers;

public class InputController: Controller
{
    public override Direction? GetDirection()
    {
        if (Keyboard.IsPressed(Keys.Up) || Keyboard.IsPressed(Keys.W))
        {
            return Direction.Up;
        }
        if (Keyboard.IsPressed(Keys.Down) || Keyboard.IsPressed(Keys.S))
        {
            return Direction.Down;
        }
        return null;
    }
}