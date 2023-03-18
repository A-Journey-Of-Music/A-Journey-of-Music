using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AGameOfMusic;

public class Sprite{
    protected readonly Texture2D texture;
    protected readonly Vector2 origin;
    protected readonly AnimationManager _anims = new();
    protected Vector2 position;
    protected int speed;

    public Sprite(Texture2D tex, Vector2 pos){
        texture = tex;
        position = pos;
        speed = 300;
        origin = new(tex.Width/2, tex.Height/2);
    }


    public virtual void Draw(){
        _anims.Draw(position);
    }
}