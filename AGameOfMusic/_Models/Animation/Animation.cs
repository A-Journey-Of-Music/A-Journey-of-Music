using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AGameOfMusic;


public class Animation
{
    private readonly Texture2D _texture;
    private readonly List<Rectangle> _sourceRectangles = new();
    private readonly int _frames;
    private int _frame;
    private readonly float _frameTime;
    private float _frameTimeLeft;
    private bool _active = true;

    public Animation(Texture2D texture, int framesX, float frameTime)
    {
        _texture = texture;
        _frameTime = frameTime;
        _frameTimeLeft = _frameTime;
        _frames = framesX;
        _frame = 0;
        var frameWidth = _texture.Width / framesX;
        var frameHeight = _texture.Height;

        for(int i = 0; i < _frames; i++){
            _sourceRectangles.Add(new( i * frameWidth,0,frameWidth, frameHeight));
        }
    }

    public void Stop(){
        _active = false;
    }

    public void Start(){
        _active = true;
    }

    public void Reset(){
        _frame = 0;
        _frameTimeLeft = _frameTime;
    }

    public void Update(){
        if(!_active) return;
        _frameTimeLeft -= Globals.ElapsedSeconds;
        if(_frameTimeLeft <= 0){
            _frameTimeLeft += _frameTime;
            _frame = (_frame + 1) % _frames;
        }
    }

    public void Draw(Vector2 position){
        Globals.SpriteBatch.Draw(_texture, position, _sourceRectangles[_frame], Color.White, 0, Vector2.Zero ,Vector2.One, SpriteEffects.None, 1);
    }
}