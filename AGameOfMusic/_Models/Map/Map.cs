using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace AGameOfMusic;
public class Map{

    private TiledMap _tiledMap;
    private TiledMapRenderer _tiledMapRenderer;
    

    public Map(TiledMap tm){
        _tiledMap = tm;
        _tiledMapRenderer = new TiledMapRenderer(Globals.GraphicsDevice, _tiledMap);
    }

    public void Update(GameTime gameTime){
        _tiledMapRenderer.Update(gameTime);
    }

    public void Draw(GameTime gameTime) {
        _tiledMapRenderer.Update(gameTime);
    }   
}