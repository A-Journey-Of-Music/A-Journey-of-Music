using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AGameOfMusic;

public class PlayerCharacterKeyboard : Sprite{
    public PlayerCharacterKeyboard(Texture2D tex, Vector2 pos): base(tex,pos){
    }

    public void Update(){
        if(InputManager.Direction != Vector2.Zero){
            var dir = Vector2.Normalize(InputManager.Direction);
            position += dir * speed * Globals.ElapsedSeconds;
        }
    }
}