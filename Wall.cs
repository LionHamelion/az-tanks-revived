
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace az_tanks_revived;

public class Wall
{
    private Texture2D _pixel;
    public Rectangle Bounds { get; set; } // Координати та розміри стіни
    public Color WallColor { get; set; } = Color.Black;

    public Wall(GraphicsDevice graphicsDevice, Rectangle bounds)
    {
        _pixel = new Texture2D(graphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White }); // Піксель як основа для стіни
        Bounds = bounds;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_pixel, Bounds, WallColor);
    }
}