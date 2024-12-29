using System.Collections.Generic;
using System.Linq;
using az_tanks_revived.GameObjects.Entity;
using az_tanks_revived.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace az_tanks_revived.Scenes;

public class GameScene : IScene
{
    private Maze _maze;
    private GraphicsDevice graphicsDevice;
    private SceneManager sceneManager;
    private Projectile _projectile, _projectile2;
    private List<GameObject> gameObjects = new List<GameObject>();
    public void AddGameObject(GameObject gameObject)
    {
        gameObjects.Add(gameObject);
    }

    private Tank _tank;
    
    // Окремий ContentManager для цієї сцени
    private ContentManager contentManager;

    public GameScene(ContentManager contentManager, GraphicsDevice graphicsDevice, SceneManager sceneManager)
    {
        this.graphicsDevice = graphicsDevice;
        this.sceneManager = sceneManager;
        this.contentManager = new ContentManager(contentManager.ServiceProvider, "Content");
    }

    public void Load()
    {
        // Завантаження контенту для цієї сцени
        _maze = new Maze(4, 3, 225);
        // _projectile = new Projectile(new Vector2(100, 100), new Vector2(0f, -1f));
        // _projectile2 = new Projectile(new Vector2(51, 51), new Vector2(3f, 2.1f));
        _tank = new Tank(new Vector2(550, 400), new Vector2(0, 0), this);
        AddGameObject(_maze);
        // AddGameObject(_projectile);
        // AddGameObject(_projectile2);
        AddGameObject(_tank);

        // Завантаження ресурсів через ContentManager
        _maze.Load(contentManager);
        // _projectile.Load(contentManager);
        // _projectile2.Load(contentManager);
        _tank.Load(contentManager);
    }

    public void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            sceneManager.RemoveScene();
        }
        
        // Оновлення всіх елементів гри
        foreach (var obj in gameObjects.ToList()) // Створюємо копію
        {
            obj.Update(gameTime);
        }
        // Перевірка на зіткнення
        CollisionManager.Instance.CheckCollisions();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Малювання всіх елементів гри
        foreach (var obj in gameObjects.ToList()){
            obj.Draw(spriteBatch);
        }
    }

    public void Unload()
    {
        // Вивантаження контенту цієї сцени
        contentManager.Unload();
    }
}