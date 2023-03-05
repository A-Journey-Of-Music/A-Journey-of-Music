using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AGameOfMusic;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    GameManager _gameManager;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        //Custom Window resizing
        _graphics.PreferredBackBufferWidth=1920;
        _graphics.PreferredBackBufferHeight= 1080;
        _graphics.ApplyChanges();
        // TODO: Add your initialization logic here
        Globals.Content = Content;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Globals.SpriteBatch = _spriteBatch;
        // TODO: use this.Content to load your game content here
        _gameManager = new(_graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
        Globals.Update(gameTime);
        _gameManager.Update();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack);
        _gameManager.Draw();
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
