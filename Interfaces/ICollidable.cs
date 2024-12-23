using az_tanks_revived.HitboxSystem;

namespace az_tanks_revived.Interfaces;

public interface ICollidable
{
    Hitbox GetHitbox(); // Метод для отримання хітбоксу
    void OnCollision(GameObject other); // Метод для обробки колізії
}