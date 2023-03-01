using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AGameOfMusic;

public class GameManager{

    private readonly PlayerCharacterKeyboard _playerCharacterKeyboard;
    public GameManager(){
        _playerCharacterKeyboard = new(Globals.Content.Load<Texture2D>("adventurer-idle-00"), new(300,300));
    }

    public void Update(){
        InputManager.Update();
        _playerCharacterKeyboard.Update();
    }
    public void Draw(){
        _playerCharacterKeyboard.Draw();
    }
}