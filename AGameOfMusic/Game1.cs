using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AGameOfMusic;

public class Game1 : Game
{
    Texture2D adventurerTexture;
    Vector2 adventurerPosition;
    float adventurerSpeed;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        adventurerPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
        _graphics.PreferredBackBufferHeight / 2);
        adventurerSpeed = 100f;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        adventurerTexture = Content.Load<Texture2D>("adventurer-idle-00");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.Up))
        {
            adventurerPosition.Y -= adventurerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (kstate.IsKeyDown(Keys.Down))
        {
            adventurerPosition.Y += adventurerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (kstate.IsKeyDown(Keys.Left))
        {
            adventurerPosition.X -= adventurerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (kstate.IsKeyDown(Keys.Right))
        {
            adventurerPosition.X += adventurerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (adventurerPosition.X > _graphics.PreferredBackBufferWidth - adventurerTexture.Width / 2)
        {
            adventurerPosition.X = _graphics.PreferredBackBufferWidth - adventurerTexture.Width / 2;
        }
        else if (adventurerPosition.X < adventurerTexture.Width / 2)
        {
            adventurerPosition.X = adventurerTexture.Width / 2;
        }

        if (adventurerPosition.Y > _graphics.PreferredBackBufferHeight - adventurerTexture.Height / 2)
        {
            adventurerPosition.Y = _graphics.PreferredBackBufferHeight - adventurerTexture.Height / 2;
        }
        else if (adventurerPosition.Y < adventurerTexture.Height / 2)
        {
            adventurerPosition.Y = adventurerTexture.Height / 2;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(adventurerTexture, adventurerPosition, null, Color.White, 0f, new Vector2(adventurerTexture.Width / 2, adventurerTexture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
