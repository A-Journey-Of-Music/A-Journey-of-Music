using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AGameOfMusic;

public class Frame{
    
    private readonly Texture2D _texture;
    private Vector2 _position;

    public Frame(Texture2D texture){
        _texture = texture;
        _position = Vector2.Zero;
    }

    public void Draw(){
        Globals.SpriteBatch.Draw(_texture, _position, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None,0);
    }

}