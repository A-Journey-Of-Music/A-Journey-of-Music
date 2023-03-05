using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AGameOfMusic;

public class GameManager
{
    private readonly PlayerCharacterKeyboard _playerCharacterKeyboard;
    private readonly BGManager _bgm = new();
    public GameManager()
    {
        _playerCharacterKeyboard = new(Globals.Content.Load<Texture2D>("adventurer-idle-00"), new(300, 300));
        _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("Pixelcity01_layer01"), 0.0f, 0.0f));
        _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("Pixelcity01_layer02"), 0.1f, 0.2f));
        _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("Pixelcity01_layer03"), 0.2f, 0.5f));
        _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("Pixelcity01_layer04"), 0.3f, 1.0f));
        _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("Pixelcity01_layer05"), 0.3f, 1.0f));
        _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("Pixelcity01_layer06"), 0.4f, 1.7f));
    }

    public void Update()
    {
        InputManager.Update();
        _playerCharacterKeyboard.Update();
        _bgm.Update(InputManager.Movement);
    }
    public void Draw()
    {
        _playerCharacterKeyboard.Draw();
        _bgm.Draw();
    }
}