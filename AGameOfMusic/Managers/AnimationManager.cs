using System.Collections.Generic;

namespace AGameOfMusic;

public class AnimationManager{
    private readonly List<Animation> _animations;

    public AnimationManager(){
        _animations = new();
    }

    public void AddAnimation(Animation animation){
        _animations.Add(animation);
    }

    public void Update(){
        foreach(var animation in _animations){
            animation.Update();
        }
    }

    public void Draw(){
        foreach(var animation in _animations){
            animation.Draw();
        }
    }


}