using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace az_tanks_revived;

public class Wall : GameObject, ICollidable
{
    private Texture2D _pixel;
    public Rectangle Bounds { get; private set; }
    public Color WallColor { get; set; } = Color.Black;

    public Wall(GraphicsDevice graphicsDevice, Rectangle bounds)
    {
        _pixel = new Texture2D(graphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });

        Bounds = bounds;
        Position = new Vector2(bounds.X, bounds.Y);
    }
    public Rectangle GetHitbox() => Bounds;
    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
            _pixel, 
            new Rectangle((int)Position.X, (int)Position.Y, Bounds.Width, Bounds.Height), 
            null, 
            WallColor, 
            Rotation, 
            Vector2.Zero, 
            SpriteEffects.None, 
            0f
        );
    }
    public void OnCollision(GameObject other){}
}