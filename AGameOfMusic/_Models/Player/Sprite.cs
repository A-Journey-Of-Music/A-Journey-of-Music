using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AGameOfMusic;

public class Sprite{
    protected readonly Texture2D texture;
    protected readonly Vector2 origin;
    protected readonly AnimationManager _anims = new();
    protected Vector2 position = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width/2,GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height/2);
    protected int speed;
    protected PlayerCamera _camera;
    private SpriteBatch _spriteBatch = new SpriteBatch(Globals.GraphicsDevice);

    public Sprite(Texture2D tex, Vector2 pos){
        texture = tex;
        position = pos;
        speed = 300;
        origin = new(tex.Width/2, tex.Height/2);
        _camera = new PlayerCamera(position);
    }

    public Vector2 getPlayerPosition(){
        return position;
    }


    public virtual void Draw(){
        _spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix());
        _anims.Draw(position, _spriteBatch);
        _spriteBatch.End();
    }
}