using System;

namespace az_tanks_revived.HitboxSystem;

public class RectHitbox : Hitbox
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }

    public RectHitbox(float x, float y, float width, float height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public float Left => X;
    public float Right => X + Width;
    public float Top => Y;
    public float Bottom => Y + Height;

    public static RectHitbox Empty => new RectHitbox(0, 0, 0, 0);

    public override bool Intersects(Hitbox other)
    {
        return other switch
        {
            RectHitbox rect => Intersects(rect),
            CircleHitbox circle => circle.Intersects(this), // Використовуємо коло для обробки
            _ => false
        };
    }

    private bool Intersects(RectHitbox other)
    {
        return this.Right > other.Left &&
               this.Left < other.Right &&
               this.Bottom > other.Top &&
               this.Top < other.Bottom;
    }
    public RectHitbox GetIntersection(RectHitbox rectA, RectHitbox rectB)
    {
        int x1 = Math.Max((int)rectA.Left, (int)rectB.Left);
        int y1 = Math.Max((int)rectA.Top, (int)rectB.Top);
        int x2 = Math.Min((int)rectA.Right, (int)rectB.Right);
        int y2 = Math.Min((int)rectA.Bottom, (int)rectB.Bottom);

        if (x1 < x2 && y1 < y2)
        {
            // Повертаємо прямокутник перекриття
            return new RectHitbox(x1, y1, x2 - x1, y2 - y1);
        }

        // Перекриття немає
        return null;
    }
}
