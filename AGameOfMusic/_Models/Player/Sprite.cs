using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AGameOfMusic;

public class Sprite{
    protected readonly Texture2D texture;
    protected readonly Vector2 origin;
    protected readonly AnimationManager _anims = new();
    protected Vector2 position;
    protected int speed;
    protected PlayerCamera _camera;
    private SpriteBatch _spriteBatch = new SpriteBatch(Globals.GraphicsDevice);

    public Sprite(Texture2D tex){
        texture = tex;
        position = new Vector2(Globals.GraphicsDevice.Viewport.Width/2, Globals.GraphicsDevice.Viewport.Height/2);
        speed = 300;
        origin = new(tex.Width/2, tex.Height/2);
        _camera = new PlayerCamera(position);
        // Adjust the camera position at the beginning of the game
        _camera._position = new Vector2(position.X - Globals.GraphicsDevice.Viewport.Width/2, _camera._position.Y);
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