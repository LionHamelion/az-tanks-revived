using az_tanks_revived.HitboxSystem;
using az_tanks_revived.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace az_tanks_revived.GameObjects.Static;

public class Wall : StaticObject, ICollidable
{
    private Texture2D _pixel;
    public RectHitbox Bounds { get; private set; }
    public Color WallColor { get; set; } = Color.SlateGray;

    public Wall(RectHitbox bounds)
    {
        _pixel = AssetManager.Instance.GetPixelTexture();

        Bounds = bounds;
        Transform.Position = new Vector2(bounds.X, bounds.Y);
    }

    public Hitbox GetHitbox() => Bounds;

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
            _pixel, 
            new Rectangle((int)Transform.Position.X, (int)Bounds.Y, (int)Bounds.Width, (int)Bounds.Height), 
            null, 
            WallColor, 
            Transform.Rotation, 
            Vector2.Zero, 
            SpriteEffects.None, 
            0f
        );
    }

    public void OnCollision(GameObject other) {}

    public Vector2 GetNormal(Vector2 collisionPoint)
    {
        if (collisionPoint.Y <= Bounds.Y)
        {
            return new Vector2(0, -1); // Top side
        }
        else if (collisionPoint.Y >= Bounds.Y + Bounds.Height)
        {
            return new Vector2(0, 1); // Bottom side
        }
        else if (collisionPoint.X <= Bounds.X)
        {
            return new Vector2(-1, 0); // Left side
        }
        else if (collisionPoint.X >= Bounds.X + Bounds.Width)
        {
            return new Vector2(1, 0); // Right side
        }


        return Vector2.Zero; // Default case, should not happen if collision detection is correct
    }
}
