using Microsoft.Xna.Framework;
using System;
using TiledSharp;

public class Collision
{
    private TmxMap map;
    private int tilesetTilesWide;
    private Rectangle[,] tileRectangles;

    public Collision(TmxMap _map, int _tilesetTilesWide)
    {
        map = _map;
        tilesetTilesWide = _tilesetTilesWide;

        // Initialize an array of rectangles that represent each tile in the map
        tileRectangles = new Rectangle[map.Width, map.Height];
        for (int x = 0; x < map.Width; x++)
        {
            for (int y = 0; y < map.Height; y++)
            {
                TmxLayerTile tile = map.Layers[0].Tiles[x + y * map.Width];
                if (tile.Gid != 0)
                {
                    int tileFrame = tile.Gid - 1;
                    int column = tileFrame % tilesetTilesWide;
                    int row = (int)Math.Floor((double)tileFrame / (double)tilesetTilesWide);
                    tileRectangles[x, y] = new Rectangle(x * map.TileWidth, y * map.TileHeight, map.TileWidth, map.TileHeight);
                }
            }
        }
    }

    public void HandleCollisions(Rectangle playerRectangle, ref Vector2 playerPosition)
    {
        // Check for collisions with each tile in the map
        for (int x = 0; x < map.Width; x++)
        {
            for (int y = 0; y < map.Height; y++)
            {
                if (tileRectangles[x, y] != Rectangle.Empty && playerRectangle.Intersects(tileRectangles[x, y]))
                {
                    // Handle the collision
                    Rectangle intersection = Rectangle.Intersect(playerRectangle, tileRectangles[x, y]);
                    if (intersection.Width > intersection.Height)
                    {
                        // Collision is from the top or bottom
                        if (playerPosition.Y < tileRectangles[x, y].Top)
                        {
                            playerPosition.Y = tileRectangles[x, y].Top - playerRectangle.Height;
                        }
                        else if (playerPosition.Y > tileRectangles[x, y].Top)
                        {
                            playerPosition.Y = tileRectangles[x, y].Bottom;
                        }
                    }
                    else
                    {
                        // Collision is from the left or right
                        if (playerPosition.X < tileRectangles[x, y].Left)
                        {
                            playerPosition.X = tileRectangles[x, y].Left - playerRectangle.Width;
                        }
                        else if (playerPosition.X > tileRectangles[x, y].Left)
                        {
                            playerPosition.X = tileRectangles[x, y].Right;
                        }
                    }
                }
            }
        }
    }
}
