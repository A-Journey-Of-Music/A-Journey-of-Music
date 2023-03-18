using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace AGameOfMusic;

public class AnimationManager{
    private readonly Dictionary<object, Animation> _animations = new();
    private object _lastKey;

    public void AddAnimation(object key, Animation animation){
        _animations.Add(key, animation);
        _lastKey ??= key;
    }

    public void Update(object key){
        if(_animations.ContainsKey(key)){
            _animations[key].Start();
            _animations[key].Update();
            _lastKey = key;
        }else{
            _animations[_lastKey].Stop();
            _animations[_lastKey].Reset();
        }
    }

    public void Draw(Vector2 position){
        _animations[_lastKey].Draw(position);
    }
}