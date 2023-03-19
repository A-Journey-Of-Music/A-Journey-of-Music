using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AGameOfMusic;

class Map{
    private readonly Point _mapTileSize;
    private readonly Texture2D _tileset;
    private readonly Tile[,] _tiles;
    public Point TileSize{get; private set;}
    public Point MapSize{get; private set;}
    public Map(Point size, Texture2D tileset, int tilesetX, int tilesetY, Vector2 tileSize){
        _mapTileSize = size;
        _tiles = new Tile[_mapTileSize.X, _mapTileSize.Y];
        _tileset = tileset;
        
    }

    public void MapParser(){
        
    }
}