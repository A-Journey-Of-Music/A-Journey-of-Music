using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AGameOfMusic;

public static class Globals
{
    public static float ElapsedSeconds { get; set; }
    public static ContentManager Content { get; set; }
    public static GraphicsDevice GraphicsDevice{get; set;}
    public static SpriteBatch SpriteBatch { get; set; }
    public static Point WindowSize{ get; set; }
    public static void Update(GameTime gt)
    {
        ElapsedSeconds = (float)gt.ElapsedGameTime.TotalSeconds;
    }
}