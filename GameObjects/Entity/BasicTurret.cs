using System;
using Microsoft.Xna.Framework;

namespace az_tanks_revived.GameObjects.Entity;

public class BasicTurret : Turret
{
    public BasicTurret(Tank tank) : base(tank){}
    private Projectile projectile;
    public override void Shoot()
    {
        if (projectile == null) {
            projectile = new (tank, new (tank.Transform.Position.X, tank.Transform.Position.Y - 100), Transform.Up * 2);
            AddProjectileToScene(projectile);
        }
    }
}
