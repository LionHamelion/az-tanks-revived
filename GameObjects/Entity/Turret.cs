using System;
using az_tanks_revived.Scenes;

namespace az_tanks_revived.GameObjects.Entity;

public abstract class Turret(Tank tank)
{
    protected Tank tank = tank;
    protected void AddProjectileToScene(Projectile projectile)
    {
        if (DependencyFactory.GetCurrentScene() is GameScene gameScene)
        {
            gameScene.AddGameObject(projectile);
        }

    }
    public abstract void Shoot();
}
