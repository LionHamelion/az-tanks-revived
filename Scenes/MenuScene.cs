using az_tanks_revived.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace az_tanks_revived.Scenes;

public class MenuScene : IScene
{
    private ContentManager contentManager;
    private GraphicsDevice graphicsDevice;
    private SceneManager sceneManager;
    public MenuScene(ContentManager contentManager, GraphicsDevice graphicsDevice, SceneManager sceneManager) {
        this.contentManager = contentManager;
        this.graphicsDevice = graphicsDevice;
        this.sceneManager = sceneManager;
    }
    public void Load()
    {

    }
    public void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Space)) {
            sceneManager.AddScene(new GameScene(contentManager, graphicsDevice, sceneManager));
        }
    }
    public void Draw(SpriteBatch spriteBatch)
    {

    }
    public void Unload()
    {
        
    }
}
