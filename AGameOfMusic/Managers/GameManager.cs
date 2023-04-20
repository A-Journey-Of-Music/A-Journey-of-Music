using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
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
        _borderThreshhold = 20;
        _screenHeight = height;
        _screenWidth = width;
        //TileMap-Code
        _map = new TmxMap("Content/1.tmx");
        _tileset = Globals.Content.Load<Texture2D>("Blockworld_Tileset");
        _tmm = new TileMapManager(_map,_tileset,48,48,48);
        
        _playerCharacterKeyboard = new(Globals.Content.Load<Texture2D>("mozart_idle"), new(_screenWidth/2,_screenHeight/2));
        _playerCharacterKeyboard.AddAnimation("run", new(Globals.Content.Load<Texture2D>("mozart_run"),6,0.1f));
        _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("Europe_Sky"), 0.0f, 0.0f, _screenHeight, _screenWidth));
        _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("Europe_Clouds"), 0.1f, 0.2f, _screenHeight, _screenWidth));
        _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("Europe_Mountains"), 0.2f, 0.5f, _screenHeight, _screenWidth));
        _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("Europe_BackBackBuildings"), 0.3f, 1.0f, _screenHeight, _screenWidth));
        _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("Europe_BackBuildings"), 0.4f, 1.3f, _screenHeight, _screenWidth));
        _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("Europe_Floor"), 0.5f, 1.2f, _screenHeight, _screenWidth));
    }

    public void Update()
    {
        InputManager.Update();
        _playerCharacterKeyboard.Update(_screenHeight, _screenWidth, _borderThreshhold);
        _bgm.Update(InputManager.Movement);
        _tmm.Update(InputManager.Movement, _screenWidth);
    }
    public void Draw()
    {
        //_tmm.Draw();
        //Fix Background and Position
        //_bgm.Draw();
        _playerCharacterKeyboard.Draw();
        _tmm.Draw(_screenHeight);
    }
}