using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace AGameOfMusic;

public static class InputManager
{
    private static MouseState _lastMouseState;
    private static Vector2 _direction;
    public static Vector2 Direction => _direction;
    public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();
    public static bool MouseClicked { get; private set; }
    private static readonly float _speed = 200f;
    public static float Movement { get; set; }
    public static void Update()
    {
        var keyboardState = Keyboard.GetState();
        Movement = 0;
        _direction = Vector2.Zero;

        if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up)) _direction.Y--;
        if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down)) _direction.Y++;
        if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
        {
            _direction.X--;
            Movement = _speed;
        }
        if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
        {
            _direction.X++;
            Movement = -_speed;
        }

        MouseClicked = (Mouse.GetState().LeftButton == ButtonState.Pressed) && (_lastMouseState.LeftButton == ButtonState.Released);
        _lastMouseState = Mouse.GetState();
    }
}