using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TiledSharp;

namespace AGameOfMusic;

public class Collision
{
    private bool[,] collisionMap;
    private int _tilesetTilesWide;
    private TmxMap _map;

    public Collision(TmxMap map, int tilesetTilesWide)
    {
        _map = map;
        _tilesetTilesWide = tilesetTilesWide;
        // Create the CollisionMap
        collisionMap = new bool[map.Width, map.Height];
        foreach (var layer in map.Layers)
        {
            if (layer.GetType() == typeof(TmxLayer))
            {
                var tileLayer = (TmxLayer)layer;
                for (var j = 0; j < tileLayer.Tiles.Count; j++)
                {
                    int gid = tileLayer.Tiles[j].Gid;
                    if (gid != 0)
                    {
                        // Get the tile's position in the CollisionMap
                        int x = j % map.Width;
                        int y = j / map.Width;

                        // Set the corresponding element in the CollisionMap to true or false, based on whether the tile is collidable or not
                        collisionMap[x, y] = IsTileCollidable(gid, tilesetTilesWide);
                    }else{
                        int x = j % map.Width;
                        int y = j / map.Width;
                        collisionMap[x, y] = false;
                    }
                }
            }
        }
    }

    private bool IsTileCollidable(int gid, int tilesetTilesWide)
    {
        // Determine whether the tile is collidable or not, based on its GID
        if(gid == 1){
            return true;
        }
        // You will need to modify this method to match the collision rules of your game
        // For example, you might use a specific GID value to represent collidable tiles, or you might use tile properties in Tiled to mark tiles as collidable
        return false;
    }

    public bool CanMoveToTile(int x, int y)
    {
        // Check whether the player can move onto the specified tile
        if (x < 0 || x >= collisionMap.GetLength(0) || y < 0 || y >= collisionMap.GetLength(1))
        {
            // The tile is outside the bounds of the CollisionMap, so the player cannot move onto it
            return false;
        }
        return !collisionMap[x, y];
    }

    public bool isColliding(Vector2 playerPosition)
    {
        if (playerPosition.X <= _map.Width)
        {
            // Calculate the player's current tile position
            int tileX = (int)(playerPosition.X / _tilesetTilesWide);
            int tileY = (int)(playerPosition.Y / _tilesetTilesWide);

            // Check if the tile is collidable
            if (collisionMap[tileY, tileX])
            {
                return true;
            }
            if (!collisionMap[tileY, tileX])
            {
                return false;
            }
        }

        return false;
    }

}
