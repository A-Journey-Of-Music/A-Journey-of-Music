using TiledCS;
using Microsoft.Xna.Framework;

namespace AGameOfMusic;
public class Map{

    private TiledMap _tiledMap;
    private TiledTileSet _tileSet;

    public Map(TiledMap tm, TiledTileset ts){
        _tiledMap = tm;
        _tiledSet = ts;
    }

    public void Update(GameTime gameTime){
    }

    public void Draw(GameTime gameTime) {
    }   
}