using Microsoft.Xna.Framework;

namespace az_tanks_revived;

public class Transform
{
    public Vector2 Position { get; set; } = Vector2.Zero; // Координати (x, y)
    public float Rotation { get; set; } = 0f; // Кут повороту (у радіанах)
    public Vector2 Scale { get; set; } = Vector2.One; // Масштабування (за замовчуванням 1x1)
    public static Vector2 Up => new Vector2(0, -1);
    public static Vector2 Down => new Vector2(0, 1);
    public static Vector2 Left => new Vector2(-1, 0);
    public static Vector2 Right => new Vector2(1, 0);
    public Transform() { }

    public Transform(Vector2 position, float rotation = 0f, Vector2 scale = default)
    {
        Position = position;
        Rotation = rotation;
        Scale = scale == default ? Vector2.One : scale;
    }
}
