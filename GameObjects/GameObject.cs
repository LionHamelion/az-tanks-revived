using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace az_tanks_revived;

public abstract class GameObject
{
    public Transform Transform { get; set; }
    protected GameObject()
    {
        Transform = new Transform();
    }
    public virtual void Update(GameTime gameTime) { }
    public virtual void Draw(SpriteBatch spriteBatch) { }
}
