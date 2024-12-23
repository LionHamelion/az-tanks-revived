using System;

namespace az_tanks_revived.HitboxSystem;

public class CircleHitbox : Hitbox
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Radius { get; set; }

    public CircleHitbox(float x, float y, float radius)
    {
        X = x;
        Y = y;
        Radius = radius;
    }

    public override bool Intersects(Hitbox other)
    {
        return other switch
        {
            RectHitbox rect => Intersects(rect),
            CircleHitbox circle => Intersects(circle),
            _ => false
        };
    }

    private bool Intersects(CircleHitbox other)
    {
        float dx = this.X - other.X;
        float dy = this.Y - other.Y;
        float distanceSquared = dx * dx + dy * dy;
        float radiusSum = this.Radius + other.Radius;
        return distanceSquared < radiusSum * radiusSum;
    }

    private bool Intersects(RectHitbox rect)
    {
        // Найближча точка на прямокутнику до центру кола
        float closestX = Math.Clamp(this.X, rect.Left, rect.Right);
        float closestY = Math.Clamp(this.Y, rect.Top, rect.Bottom);

        float dx = this.X - closestX;
        float dy = this.Y - closestY;

        // Якщо відстань до найближчої точки менша за радіус, є перетин
        return (dx * dx + dy * dy) < (this.Radius * this.Radius);
    }
}
