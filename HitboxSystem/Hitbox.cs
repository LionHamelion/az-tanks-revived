using System;
using az_tanks_revived.Interfaces;
using Microsoft.Xna.Framework;

namespace az_tanks_revived.HitboxSystem;

public abstract class Hitbox
{
    public abstract bool Intersects(Hitbox other);
    public Vector2 GetContactPoint(RectHitbox intersection)
    {
        float contactX = intersection.Left + intersection.Width / 2.0f;
        float contactY = intersection.Top + intersection.Height / 2.0f;

        return new Vector2(contactX, contactY);
    }
}