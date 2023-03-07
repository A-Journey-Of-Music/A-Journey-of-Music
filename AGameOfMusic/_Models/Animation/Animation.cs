using System.Collections.Generic;

namespace AGameOfMusic;

public class Animation
{

    public string _name { get; set; }

    private readonly List<Frame> _frames;
    private bool _active = true;

    private float _duration;
    private float _frameTime;

    public Animation(string name, float duration)
    {
        _frames = new();
        _name = name;
        _duration = duration;
        _frameTime = duration;
    }

    private void resetFrameTime(){
        _frameTime = _duration;
    }

    public void AddFrame(Frame frame)
    {
        _frames.Add(frame);
    }

    public void Start()
    {
        _active = true;
    }

    public void Stop()
    {
        _active = false;
    }

    public void Update()
    {

    }

    public void Draw()
    {
        while (_active)
        {
            foreach (var frame in _frames)
            {   
                do{
                    _frameTime -= Globals.ElapsedSeconds;
                    frame.Draw();
                }while(_frameTime > 0);
                this.resetFrameTime();
            }
        }
    }
}