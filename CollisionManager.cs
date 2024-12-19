using System.Collections.Generic;

namespace az_tanks_revived;

public class CollisionManager
{
    private static CollisionManager _instance;
    public static CollisionManager Instance => _instance ??= new CollisionManager();

    private List<ICollidable> _collidables = new List<ICollidable>();

    public void AddCollidable(ICollidable collidable)
    {
        Instance._collidables.Add(collidable);
    }

    public void CheckCollisions()
    {
        for (int i = 0; i < Instance._collidables.Count; i++)
        {
            for (int j = i + 1; j < Instance._collidables.Count; j++)
            {
                var objA = Instance._collidables[i];
                var objB = Instance._collidables[j];

                if (objA.GetHitbox().Intersects(objB.GetHitbox()))
                {
                    objA.OnCollision(objB as GameObject);
                    objB.OnCollision(objA as GameObject);
                }
            }
        }
    }
}