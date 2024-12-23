using az_tanks_revived.Interfaces;
using Microsoft.Xna.Framework;

namespace az_tanks_revived.GameObjects.Static;

public abstract class StaticObject : GameObject
{
    public StaticObject () {
        if (this is ICollidable collidable) {
            CollisionManager.Instance.AddStatic(collidable);
        }
    }
}