using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AGameOfMusic;

public class Layer
{
    private readonly Texture2D _texture;
    private Vector2 _position;
    private readonly float _depth;
    private readonly float _moveScale;

    public Layer(Texture2D texture, float depth, float moveScale)
    {
        _texture = texture;
        _depth = depth;
        _moveScale = moveScale;
        _position = Vector2.Zero;
    }

    public void Update(float movement)
    {
        _position.X += movement * _moveScale * Globals.ElapsedSeconds;
        _position.X %= _texture.Width;
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, _position, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, _depth);
    }
}