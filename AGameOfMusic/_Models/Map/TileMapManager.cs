using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TiledSharp;

namespace AGameOfMusic;

public class TileMapManager
{
    private SpriteBatch spriteBatch = new SpriteBatch(Globals.GraphicsDevice);
    private TmxMap map;
    private Texture2D tileset;
    public Collision collisions {get; set;}
    int tilesetTilesWide;
    int tileWidth;
    int tileHeight;

    private float mapPosition;

    private Vector2 cameraPosition = new Vector2(0,0);

    private Matrix matrix;

    public TileMapManager(TmxMap _map, Texture2D _tileset, int _tilesetTilesWide, int _tileWidth, int _tileHeight)
    {
        map = _map;
        tileset = _tileset;
        tilesetTilesWide = _tilesetTilesWide;
        tileWidth = _tileWidth;
        tileHeight = _tileHeight;
        collisions = new Collision(map, tilesetTilesWide);
        mapPosition = 0;
    }

    public void Update(float playerPosition, int screenWidth)
    {
        // Update the matrix used for drawing
        mapPosition = -playerPosition + (screenWidth / 2);

        // Ensure that the map stays within the bounds of the screen

        if (mapPosition > 0)
        {
            mapPosition = 0;
        }
        else if (mapPosition < -(map.Width * 48) + screenWidth)
        {
            mapPosition = -(map.Width * 48) + screenWidth;
        }


        // Create a translation matrix based on the map position
        matrix = Matrix.CreateTranslation(mapPosition, 0, 0);
    }

    public void Draw(float screenHeight,float screenWidth, Vector2 playerPosition)
    {
        spriteBatch.Begin(
            SpriteSortMode.Deferred,
            samplerState: SamplerState.PointClamp,
            effect: null,
            blendState: null,
            rasterizerState: null,
            depthStencilState: null,
            transformMatrix: matrix);

        // Calculate the camera position based on the player's position
        cameraPosition = new Vector2(playerPosition.X*2 - screenWidth / 2, 0);

        foreach (var layer in map.Layers)
        {
            if (layer.GetType() == typeof(TmxLayer))
            {
                var tileLayer = (TmxLayer)layer;

                for (var j = 0; j < tileLayer.Tiles.Count; j++)
                {
                    int gid = tileLayer.Tiles[j].Gid;

                    if (gid == 0)
                    {
                        //do nothing
                    }
                    else
                    {
                        int tileFrame = gid - 1;
                        int column = tileFrame % tilesetTilesWide;
                        int row = (int)Math.Floor((double)tileFrame / (double)tilesetTilesWide);
                        float x = (j % map.Width) * map.TileWidth - cameraPosition.X;
                        float y = (float)Math.Floor(j / (double)map.Width) * map.TileHeight - cameraPosition.Y;
                        y += screenHeight - (map.Height * map.TileHeight);
                        Rectangle tilesetRec = new Rectangle((tileWidth) * column, (tileHeight) * row, tileWidth, tileHeight);
                        spriteBatch.Draw(tileset, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec, Color.White);
                    }
                }
            }
        }

        spriteBatch.End();
    }
}
