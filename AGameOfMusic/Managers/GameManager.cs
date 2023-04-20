using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;

namespace AGameOfMusic;

public class GameManager
{
    private readonly PlayerCharacterKeyboard _playerCharacterKeyboard;
    private readonly BGManager _bgm = new();
    private readonly TmxMap _map;
    private readonly Texture2D _tileset;
    private readonly TileMapManager _tmm;
    private readonly int _screenHeight;
    private readonly int _screenWidth;
    private readonly int _borderThreshhold;

    public GameManager(int height, int width)
    {
        _borderThreshhold = 64;
        _screenHeight = height;
        _screenWidth = width;
        //TileMap-Code
        _map = new TmxMap("Content/tilemaps/test/1.tmx");
        _tileset = Globals.Content.Load<Texture2D>("tilesets/blockworld/Blockworld_Tileset");
        _tmm = new TileMapManager(_map, _tileset, 48, 48, 48);
        
        _playerCharacterKeyboard = new(Globals.Content.Load<Texture2D>("sprites/kiss/kiss_idle"));
        _playerCharacterKeyboard.AddAnimation("run", new(Globals.Content.Load<Texture2D>("sprites/kiss/kiss_run"), 6, 0.1f));
        _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("backgrounds/kiss/Kiss_Sky"), 0.0f, 0.0f, _screenHeight, _screenWidth));
        _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("backgrounds/kiss/Kiss_Clouds"), 0.1f, 0.2f, _screenHeight, _screenWidth));
        _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("backgrounds/kiss/Kiss_BackBackBuildings"), 0.2f, 0.5f, _screenHeight, _screenWidth));
        _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("backgrounds/kiss/Kiss_BackBuildings"), 0.3f, 1.0f, _screenHeight, _screenWidth));
        _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("backgrounds/kiss/Kiss_Buildings"), 0.4f, 1.3f, _screenHeight, _screenWidth));
        _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("backgrounds/kiss/Kiss_Floor"), 0.5f, 1.2f, _screenHeight, _screenWidth));
    }

    public void Update()
    {
        InputManager.Update();
        _playerCharacterKeyboard.Update(_screenHeight, _screenWidth, _borderThreshhold, _tmm.collisions);
        _bgm.Update(InputManager.Movement);
        _tmm.Update(InputManager.Movement, _screenWidth);
    }
    public void Draw()
    {
        // Draw background using the original SpriteBatch
        _bgm.Draw();
        Globals.SpriteBatch.End();
        // Begin drawing the tilemap using a new SpriteBatch
        _tmm.Draw(_screenHeight, _screenWidth, _playerCharacterKeyboard.getPlayerPosition());
        // Draw player character after the tilemap
        _playerCharacterKeyboard.Draw();
        Globals.SpriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack);

    }
}