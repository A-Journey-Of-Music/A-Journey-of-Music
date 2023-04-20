using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace AGameOfMusic;


public static class InputManager
{
     private const float GRAVITY = 9.81f; // Acceleration due to gravity in m/s^2
    private const float JUMP_FORCE = 250f; // The force applied when jumping
    private static Vector2 velocity;
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
        //GamePad
        GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);
        if(capabilities.IsConnected){
            GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);
            if(capabilities.HasDPadLeftButton && capabilities.HasDPadRightButton){
                if(gamepadState.IsButtonDown(Buttons.DPadLeft)){
                    _direction.X--;
                    Movement = _speed;
                }
                if(gamepadState.IsButtonDown(Buttons.DPadRight)){
                    _direction.X++;
                    Movement = -_speed;
                }
            }
        }

        //Keyboard
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
        if (keyboardState.IsKeyDown(Keys.Space))
        {
            Jump();
            // Apply gravity to the player
            velocity.Y += GRAVITY * (float)Globals.ElapsedSeconds;

        // Update the player's position based on their velocity
            _direction += velocity * (float)Globals.ElapsedSeconds;
        }

        MouseClicked = (Mouse.GetState().LeftButton == ButtonState.Pressed) && (_lastMouseState.LeftButton == ButtonState.Released);
        _lastMouseState = Mouse.GetState();
    }

    public static void Jump()
    {
        // Only allow jumping if the player is on the ground (velocity.Y == 0)
        if (velocity.Y == 0)
        {
            // Apply an upward force to the player
            velocity.Y -= JUMP_FORCE;
        }
    }
}