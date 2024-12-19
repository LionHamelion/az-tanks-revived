using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace az_tanks_revived;

public class Map
{
    private GraphicsDevice _graphicsDevice;
    public List<Wall> Walls { get; private set; } = new List<Wall>();

    public Map(GraphicsDevice graphicsDevice)
    {
        _graphicsDevice = graphicsDevice;
    }

    // Додавання горизонтальної стіни
    public void AddHorizontalWall(int row, int column, int cellSize, int wallThickness)
    {
        var bounds = new Rectangle(
            column * cellSize, 
            row * cellSize, 
            cellSize + wallThickness, // Додаємо товщину для стикування
            wallThickness
        );
        Walls.Add(new Wall(_graphicsDevice, bounds));
    }

    // Додавання вертикальної стіни
    public void AddVerticalWall(int row, int column, int cellSize, int wallThickness)
    {
        var bounds = new Rectangle(
            column * cellSize, 
            row * cellSize, 
            wallThickness,
            cellSize + wallThickness // Додаємо товщину для стикування
        );
        Walls.Add(new Wall(_graphicsDevice, bounds));
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var wall in Walls)
        {
            wall.Draw(spriteBatch);
        }
    }
}

