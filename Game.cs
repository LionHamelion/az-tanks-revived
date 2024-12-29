using System;
using az_tanks_revived.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace az_tanks_revived;

public class Game : Microsoft.Xna.Framework.Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private readonly SceneManager sceneManager;
    private const int FrameRate = 160;

    public Game()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        // Встановлення розміру вікна
        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 920;
        _graphics.ApplyChanges();

        sceneManager = new SceneManager();

        // Встановлення частоти кадрів
        TargetElapsedTime = TimeSpan.FromSeconds(1.0 / FrameRate);
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        AssetManager.Instance.Initialize(Content, GraphicsDevice);
        sceneManager.AddScene(new GameScene(Content, GraphicsDevice, sceneManager));
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);

        _spriteBatch.Begin();

        sceneManager.GetCurrentScene().Draw(_spriteBatch);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
    protected override void Update(GameTime gameTime)
    {
        sceneManager.GetCurrentScene().Update(gameTime);
    }
}