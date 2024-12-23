using az_tanks_revived.Interfaces;
using Microsoft.Xna.Framework;

namespace az_tanks_revived.GameObjects.Entity;

public abstract class Entity : GameObject
{
    public Vector2 Velocity { get; set; } // Вектор руху: швидкість по X і Y
    public Entity () {
        if (this is ICollidable collidable) {
            CollisionManager.Instance.AddEntity(collidable);
        }
    }
    public override void Update(GameTime gameTime)
    {
        // Оновлення позиції на основі швидкості
        Transform.Position += Velocity;
    }
}