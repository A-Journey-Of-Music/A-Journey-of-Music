using Microsoft.Xna.Framework;

namespace AGameOfMusic;
public class PlayerCamera
{
    public Vector2 _position { get; set; }

    public PlayerCamera(Vector2 position)
    {
        _position = position;
    }

    public Matrix GetViewMatrix()
    {
        return Matrix.CreateTranslation(new Vector3(-_position, 0f));
    }
}
