using az_tanks_revived.GameObjects.Static;
using az_tanks_revived.HitboxSystem;
using az_tanks_revived.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace az_tanks_revived.GameObjects.Entity;

public class Projectile: Entity, ICollidable
{
    private Tank owner;
    private float initialSpeed;
    private float boundsRadius = 10f;
    private Rectangle textureBounds = new Rectangle((int)-12.5f, (int)-12.5f, 25, 25);
    public CircleHitbox Bounds
    {
        get
        {
            return new CircleHitbox(
                Transform.Position.X, // Центруємо хітбокс за X
                Transform.Position.Y, // Центруємо хітбокс за Y
                boundsRadius  // Радіус кола
            );
        }
    }
    public Projectile (Vector2 position, Vector2 velocity) {
        Transform.Position = position;
        Velocity = velocity;
        initialSpeed = velocity.Length();
    }
    public Projectile (Tank owner, Vector2 position, Vector2 velocity) {
        this.owner = owner;
        Transform.Position = position;
        Velocity = velocity;
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        Texture2D circleTexture = AssetManager.Instance.GetCircleTexture(50, Color.Black);
        Texture2D pixel = AssetManager.Instance.GetPixelTexture();
        Texture2D hitbox = AssetManager.Instance.GetCircleTexture((int)boundsRadius, Color.Red, filled: false);
        spriteBatch.Draw(
            circleTexture,
            new Rectangle(
                (int)(Transform.Position.X + textureBounds.X), 
                (int)(Transform.Position.Y + textureBounds.Y), 
                textureBounds.Width, 
                textureBounds.Height),
            null,
            Color.Black,
            Transform.Rotation,
            Vector2.Zero,
            SpriteEffects.None,
            0f
        );
        spriteBatch.Draw(
            pixel,
            new Rectangle((int)Transform.Position.X, (int)Transform.Position.Y, 1, 1),
            null,
            Color.Red,
            Transform.Rotation,
            Vector2.Zero,
            SpriteEffects.None,
            0f
        );
        spriteBatch.Draw(
            hitbox,
            new Rectangle((int)(Transform.Position.X - boundsRadius), (int)(Transform.Position.Y - boundsRadius), (int)(2 * boundsRadius), (int)(2 * boundsRadius)),
            null,
            Color.Red,
            Transform.Rotation,
            Vector2.Zero,
            SpriteEffects.None,
            0f
        );
    }
    public Hitbox GetHitbox() => Bounds;
    public void OnCollision(GameObject other)
    {
        switch (other)
        {
            case Tank tank:
                tank.Destroy();
                Destroy();
                break;
    
            case Wall wall:
                Transform.Position -= Velocity;
                Vector2 normal = wall.GetNormal(Transform.Position);
                Velocity -= 2 * Vector2.Dot(Velocity, normal) * normal;
                Velocity = Vector2.Normalize(Velocity) * initialSpeed;
                break;
    
            default:
                break;
        }
    }

    private void Destroy()
    {
        textureBounds = Rectangle.Empty;
        // boundsRadius = 0;
    }
}
