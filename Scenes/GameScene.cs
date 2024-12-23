using az_tanks_revived.GameObjects.Entity;
using az_tanks_revived.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace az_tanks_revived.Scenes;

public class GameScene: IScene {
    private Maze _maze;
    private GraphicsDevice graphicsDevice;
    private SceneManager sceneManager;
    private Projectile _projectile, _projectile2;
    private Tank _tank;
    public GameScene(ContentManager contentManager, GraphicsDevice graphicsDevice, SceneManager sceneManager) {
        this.graphicsDevice = graphicsDevice;
        this.sceneManager = sceneManager;
    }
    public void Load() {
        _maze = new Maze(4, 3, 225);
        _projectile = new Projectile(new Vector2(100, 100), new Vector2(-4f, -4f));
        _projectile2 = new Projectile(new Vector2(51, 51), new Vector2(3f, 2.1f));
        _tank = new Tank(new Vector2(550, 400), new Vector2(0, 0));
    }
    public void Update(GameTime gameTime) {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape)) {
            sceneManager.RemoveScene();
        }
        _maze.Update(gameTime);
        _projectile.Update(gameTime);
        _projectile2.Update(gameTime);
        _tank.Update(gameTime);
        CollisionManager.Instance.CheckCollisions();
    }
    public void Draw(SpriteBatch spriteBatch) {
        _maze.Draw(spriteBatch);
        _projectile.Draw(spriteBatch);
        _projectile2.Draw(spriteBatch);
        _tank.Draw(spriteBatch);
    }
    public void Unload() {}
}