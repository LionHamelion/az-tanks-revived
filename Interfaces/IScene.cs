using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace az_tanks_revived.Interfaces;

public interface IScene {
    void Load();
    void Update(GameTime gameTime);
    void Draw(SpriteBatch spriteBatch);
    void Unload();
}