using System.Collections.Generic;
using az_tanks_revived.GameObjects.Static;
using az_tanks_revived.HitboxSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace az_tanks_revived;

public class Map
{
    public List<Wall> Walls { get; private set; } = new List<Wall>();

    // Додавання горизонтальної стіни
    public void AddHorizontalWall(int row, int column, int cellSize, int wallThickness)
    {
        var bounds = new RectHitbox(
            column * cellSize, 
            row * cellSize, 
            cellSize + wallThickness, // Додаємо товщину для стикування
            wallThickness
        );
        Walls.Add(new Wall(bounds));
    }

    // Додавання вертикальної стіни
    public void AddVerticalWall(int row, int column, int cellSize, int wallThickness)
    {
        var bounds = new RectHitbox(
            column * cellSize, 
            row * cellSize, 
            wallThickness,
            cellSize + wallThickness // Додаємо товщину для стикування
        );
        Walls.Add(new Wall(bounds));
    }

    public Point ToMinimapCoordinates (Point point, int wallThickness, int cellSize) {
        point.X /= wallThickness;
        point.Y /= wallThickness;
        int tunnelWidth = (cellSize - wallThickness)/wallThickness;
        return new (ProcessCoordinate(point.X, tunnelWidth), ProcessCoordinate(point.Y, tunnelWidth));
    }
    private int ProcessCoordinate(int n, int gap)
    {
        int block = n / (gap + 1);
        int pos = n % (gap + 1);
        return 2 * block + (pos > 0 ? 1 : 0);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var wall in Walls)
        {
            wall.Draw(spriteBatch);
        }
    }
}

