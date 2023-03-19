using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AGameOfMusic;

public class Tile : Sprite{
    protected readonly Rectangle _rectangle;
    public Tile(Texture2D tex, Vector2 pos, Rectangle rectangle) : base(tex,pos){
        _rectangle = rectangle;
    }

    public override void Draw(){
        Globals.SpriteBatch.Draw(texture, position, _rectangle, Color.White, 0f, origin, 1f, SpriteEffects.None, 0f);
    }
}