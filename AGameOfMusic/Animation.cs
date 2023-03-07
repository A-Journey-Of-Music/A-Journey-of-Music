using System.Collections.Generic;

namespace AGameOfMusic;

public class Animation{
    
    public string _name {get; set;}

    private readonly List<Frame> _frames;

    public Animation(string name){
        _frames = new();
        _name = name;
    }

    public void AddFrame(Frame frame){
        _frames.Add(frame);
    }

    public void Update(){

    }

    public void Draw(){
        foreach (var frame in _frames)
        {
            frame.Draw();
        }
    }
}