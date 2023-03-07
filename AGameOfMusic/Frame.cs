using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AGameOfMusic;

public class Frame{
    
    private readonly Texture2D _texture;
    private Vector2 _position;
    private float _duration;

    public Frame(Texture2D texture, float duration){
        _texture = texture;
        _position = Vector2.Zero;
        _duration = duration;
    }

    public void Update(){

    }

    public void Draw(){
        Globals.SpriteBatch.Draw(_texture, _position, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None,0);
    }

}