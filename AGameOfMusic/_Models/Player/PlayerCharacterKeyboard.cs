using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AGameOfMusic;

public class PlayerCharacterKeyboard : Sprite
{
    public PlayerCharacterKeyboard(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        _anims.AddAnimation(Vector2.Zero, new(tex, 4, 1, 0.1f));
    }

    private Vector2 isWithinBounds(Vector2 position, int _screenHeight, int _screenWidth, int _borderThreshhold)
    {
        if (position.X < 0 + _borderThreshhold)
            position.X = 0 + _borderThreshhold;
        if (position.Y < 0 + _borderThreshhold)
            position.Y = 0 + _borderThreshhold;
        if (position.X > _screenWidth - _borderThreshhold)
            position.X = _screenWidth - _borderThreshhold;
        if (position.Y > _screenHeight - _borderThreshhold)
            position.Y = _screenHeight - _borderThreshhold;

        return position;
    }

    public void Update(int _screenHeight, int _screenWidth, int _borderThreshhold)
    {
        if (InputManager.Direction != Vector2.Zero)
        {
            var dir = Vector2.Normalize(InputManager.Direction);
            position += dir * speed * Globals.ElapsedSeconds;
            position = isWithinBounds(position, _screenHeight, _screenWidth, _borderThreshhold);
        }else{
            _anims.Update(InputManager.Direction);
        }
    }
}