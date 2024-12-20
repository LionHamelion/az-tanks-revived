using az_tanks_revived.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace az_tanks_revived.Scenes;

public class GameScene: IScene {
    private Maze _maze;
    private ContentManager contentManager;
    private GraphicsDevice graphicsDevice;
    private SceneManager sceneManager;
    public GameScene(ContentManager contentManager, GraphicsDevice graphicsDevice, SceneManager sceneManager) {
        this.contentManager = contentManager;
        this.graphicsDevice = graphicsDevice;
        this.sceneManager = sceneManager;
    }
    public void Load() {
        _maze = new Maze(graphicsDevice, 10, 15, 50);
    }
    public void Update(GameTime gameTime) {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape)) {
            sceneManager.RemoveScene();
        }
    }
    public void Draw(SpriteBatch spriteBatch) {
        _maze.Draw(spriteBatch);
    }
    public void Unload() {}
}