using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AGameOfMusic;

public class PlayerCharacterKeyboard : Sprite
{
    private const float GRAVITY = 500f;
    private Vector2 velocity;
    public PlayerCharacterKeyboard(Texture2D tex) : base(tex)
    {
        _anims.AddAnimation("idle", new(tex, 5, 0.1f));
    }

    public void AddAnimation(string name, Animation anim)
    {
        _anims.AddAnimation(name, anim);
    }

    private Vector2 isWithinBounds(Vector2 position, int _screenHeight, int _screenWidth, int _borderThreshhold)
    {
        if (position.X < 0 + _borderThreshhold)
            position.X = 0 + _borderThreshhold;
        if (position.X > _screenWidth - _borderThreshhold)
            position.X = _screenWidth - _borderThreshhold;
        return position;
    }

    private void applyGravity(int _screenHeight, int _screenWidth, int _borderThreshhold){
        velocity.Y += GRAVITY * (float)Globals.ElapsedSeconds;
        // Update the player's position based on their velocity
        position += velocity * (float)Globals.ElapsedSeconds;
        
        // Keep the player within the bounds of the screen
        position = isWithinBounds(position, _screenHeight, _screenWidth, _borderThreshhold);
        
        
        // Check if the player has hit the bottom of the screen
        if (position.Y >= _screenHeight - _borderThreshhold + _screenHeight / 2)
        {
            // Stop applying gravity
            velocity.Y = 0;
            
            // Set the player's position to the bottom corner of the screen
            position.Y = _screenHeight - _borderThreshhold + _screenHeight / 2;
        }
        
        
    }

    private void isColliding(Collision collision){
        collision.HandleCollisions(new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height), ref position);
    }

    public void Update(int _screenHeight, int _screenWidth, int _borderThreshhold, Collision collision)
    {
        _anims.Update("idle");
        if (InputManager.Direction != Vector2.Zero)
        {
            var dir = Vector2.Normalize(InputManager.Direction);
            position += dir * speed * Globals.ElapsedSeconds;
            if (dir.X != 0)
            {
                _camera._position = new Vector2(position.X - _screenWidth / 2, _camera._position.Y);
            }
            position = isWithinBounds(position, _screenHeight, _screenWidth, _borderThreshhold);
            _anims.Update("run");
        }
        applyGravity(_screenHeight, _screenWidth, _borderThreshhold);
        //isColliding(collision);
    }
}