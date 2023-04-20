using Microsoft.Xna.Framework;

namespace AGameOfMusic;
public class PlayerCamera
{
    public Vector2 Position { get; set; }

    public PlayerCamera(Vector2 position)
    {
        Position = position;
    }

    public Matrix GetViewMatrix()
    {
        return Matrix.CreateTranslation(new Vector3(-Position, 0f));
    }
}
