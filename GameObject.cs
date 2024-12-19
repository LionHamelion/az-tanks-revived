using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace az_tanks_revived;

public abstract class GameObject : Transform
{
    protected GameObject()
    {
        if (this is ICollidable collidable)
        {
            CollisionManager.Instance.AddCollidable(collidable);
        }
    }
    public virtual void Update(GameTime gameTime) { }
    public abstract void Draw(SpriteBatch spriteBatch);
}
