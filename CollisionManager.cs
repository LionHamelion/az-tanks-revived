using System.Collections.Generic;
using az_tanks_revived.Interfaces;

namespace az_tanks_revived;

public class CollisionManager
{
    private static CollisionManager _instance;
    public static CollisionManager Instance => _instance ??= new CollisionManager();

    private List<ICollidable> _entities = new List<ICollidable>();
    private List<ICollidable> _staticObjects = new List<ICollidable>();

    // Додаємо Entity до окремого списку
    public void AddEntity(ICollidable entity)
    {
        if (!_entities.Contains(entity))
        {
            _entities.Add(entity);
        }
    }

    // Додаємо StaticObject до іншого списку
    public void AddStatic(ICollidable staticObject)
    {
        if (!_staticObjects.Contains(staticObject))
        {
            _staticObjects.Add(staticObject);
        }
    }

    // Перевірка колізій
    public void CheckCollisions()
    {
        // Перевіряємо Entity з іншими Entity
        for (int i = 0; i < _entities.Count; i++)
        {
            for (int j = i + 1; j < _entities.Count; j++)
            {
                var objA = _entities[i];
                var objB = _entities[j];

                if (objA.GetHitbox().Intersects(objB.GetHitbox()))
                {
                    objA.OnCollision(objB as GameObject);
                    objB.OnCollision(objA as GameObject);
                }
            }
        }

        // Перевіряємо Entity зі StaticObject
        foreach (var entity in _entities)
        {
            foreach (var staticObject in _staticObjects)
            {
                if (entity.GetHitbox().Intersects(staticObject.GetHitbox()))
                {
                    entity.OnCollision(staticObject as GameObject);
                    staticObject.OnCollision(entity as GameObject);
                }
            }
        }
    }

    // Очищення всіх списків (наприклад, при зміні рівня)
    public void Clear()
    {
        _entities.Clear();
        _staticObjects.Clear();
    }
}
