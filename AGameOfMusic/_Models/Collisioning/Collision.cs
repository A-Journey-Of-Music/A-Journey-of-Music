using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using TiledSharp;

public class Collision
{
    private TmxMap _map;
    private int _tileSize;

    public Collision(TmxMap map, int tileSize){
        _map = map;
        _tileSize = tileSize;

    }

    public bool isColliding(Vector2 position)
    {
        int tileX = (int)(position.X / _tileSize);
        int tileY = (int)(position.Y / _tileSize);

        if (tileX < 0 || tileX >= _map.Width || tileY < 0 || tileY >= _map.Height)
        {
            // position is outside of the map
            return true;
        }

        foreach (var layer in _map.Layers)
    {
        if (layer.Visible)
        {
            var tile = layer.Tiles[tileX + tileY * _map.Width];
            if (tile.Gid != 0)
            {
                // tile is marked as collidable
                return true;
            }
        }
    }

    return false;
    }

}
