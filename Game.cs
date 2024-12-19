using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace az_tanks_revived;

public class Game : Microsoft.Xna.Framework.Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Maze _maze;

    public Game()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        // Встановлення розміру вікна
        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 920;
        _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {
        base.Initialize();

        // Ініціалізація лабіринту
        _maze = new Maze(GraphicsDevice, 10, 15, 50);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);

        _spriteBatch.Begin();

        // Малюємо лабіринт
        _maze.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}