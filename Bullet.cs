using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace az_tanks_revived;

public class Bullet : GameObject, ICollidable
{
    private Texture2D _pixel;
    public Rectangle _bounds = new Rectangle (45, 120, 25, 25);
    public Color WallColor { get; set; } = Color.Red;
    private Vector2 _direction = new Vector2 (2f, 0.2f);
    public Bullet(GraphicsDevice graphicsDevice)
    {
        _pixel = new Texture2D(graphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });

        Position = new Vector2(_bounds.X, _bounds.Y);
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
            _pixel, 
            new Rectangle((int)Position.X, (int)Position.Y, _bounds.Width, _bounds.Height), 
            null, 
            WallColor, 
            Rotation, 
            Vector2.Zero, 
            SpriteEffects.None, 
            0f
        );
    }

    public override void Update(GameTime gameTime)
    {
        Position += _direction;
        _bounds = new Rectangle ((int)Position.X, (int)Position.Y, 25, 25);
    }

    public Rectangle GetHitbox() => _bounds;

    public void OnCollision(GameObject other)
    {
        _direction = -_direction;
    }
}
