using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AGameOfMusic;

public class PlayerCharacterKeyboard : Sprite
{
    public PlayerCharacterKeyboard(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
    }

    public void Update(int _screenHeight, int _screenWidth, int _borderThreshhold)
    {
        if (InputManager.Direction != Vector2.Zero)
        {
            var dir = Vector2.Normalize(InputManager.Direction);
            position += dir * speed * Globals.ElapsedSeconds;
            
            if (position.X < 0+_borderThreshhold)
                position.X = 0+_borderThreshhold;
            if (position.Y < 0+_borderThreshhold)
                position.Y = 0+_borderThreshhold;
            if (position.X > _screenWidth-_borderThreshhold)
                position.X = _screenWidth-_borderThreshhold;
            if (position.Y > _screenHeight-_borderThreshhold)
                position.Y = _screenHeight-_borderThreshhold;
        }
    }
}