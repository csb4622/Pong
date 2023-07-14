namespace Pong;

public static class Program
{
    public static void Main(params string[] args)
    {
        using var game = new PongGame();
        game.Run();        
    }
}