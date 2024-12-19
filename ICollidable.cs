using Microsoft.Xna.Framework;

namespace az_tanks_revived;

public interface ICollidable
{
    Rectangle GetHitbox(); // Метод для отримання хітбоксу
    void OnCollision(GameObject other); // Метод для обробки колізії
}