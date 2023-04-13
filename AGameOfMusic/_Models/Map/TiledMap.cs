using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TiledCS;

namespace AGameOfMusic;

public class TiledMap
{
    private TmxMap map;
    private Dictionary<string, Texture2D> tilesetTextures;
    private int tileWidth;
    private int tileHeight;
    private int mapWidth;
    private int mapHeight;
    private int[,] tileData;

    public TiledMap(string mapPath, GraphicsDevice graphicsDevice)
    {
        map = new TmxMap(mapPath);
        tileWidth = map.TileWidth;
        tileHeight = map.TileHeight;
        mapWidth = map.Width;
        mapHeight = map.Height;
        tilesetTextures = new Dictionary<string, Texture2D>();
        tileData = new int[mapWidth, mapHeight];

        foreach (var tileset in map.Tilesets)
        {
            string tilesetPath = tileset.Image.Source;
            Texture2D texture = Texture2D.FromFile(graphicsDevice, tilesetPath);
            tilesetTextures.Add(tileset.Name, texture);
        }

        for (int layerIndex = 0; layerIndex < map.Layers.Count; layerIndex++)
        {
            var layer = map.Layers[layerIndex];
            if (layer is TmxTileLayer tileLayer)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    for (int x = 0; x < mapWidth; x++)
                    {
                        int tileIndex = tileLayer.GetTile(x, y).Gid;
                        if (tileIndex != 0)
                        {
                            tileData[x, y] = tileIndex;
                        }
                    }
                }
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        int startX = (int)Math.Max(0, position.X / tileWidth - 10);
        int startY = (int)Math.Max(0, position.Y / tileHeight - 10);
        int endX = (int)Math.Min(mapWidth, position.X / tileWidth + 10);
        int endY = (int)Math.Min(mapHeight, position.Y / tileHeight + 10);

        for (int y = startY; y < endY; y++)
        {
            for (int x = startX; x < endX; x++)
            {
                int tileIndex = tileData[x, y];
                if (tileIndex != 0)
                {
                    var tileset = map.GetTilesetFromTileId(tileIndex);
                    var texture = tilesetTextures[tileset.Name];
                    int tilesetIndex = tileIndex - tileset.FirstGid;
                    int column = tilesetIndex % (texture.Width / tileWidth);
                    int row = tilesetIndex / (texture.Width / tileWidth);
                    var tileLocation = new Rectangle(column * tileWidth, row * tileHeight, tileWidth, tileHeight);
                    var positionInPixels = new Vector2(x * tileWidth, y * tileHeight);
                    spriteBatch.Draw(texture, positionInPixels, tileLocation, Color.White);
                }
            }
        }
    }
}
