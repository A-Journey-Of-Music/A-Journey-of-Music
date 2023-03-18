using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AGameOfMusic;

public class Sprite{
    protected readonly Texture2D texture;
    protected readonly Vector2 origin;

    private readonly Animation _anim;
    protected Vector2 position;
    protected int speed;

    public Sprite(Texture2D tex, Vector2 pos){
        texture = tex;
        position = pos;
        _anim = new("idle", texture, 4, 0.2f);
        speed = 300;
        origin = new(tex.Width/2, tex.Height/2);
    }

    public void Update(){
        _anim.Update();
    }

    public virtual void Draw(){
        _anim.Draw(position);
    }
}