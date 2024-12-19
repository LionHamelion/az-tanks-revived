using Microsoft.Xna.Framework.Graphics;

namespace az_tanks_revived;

public class Maze
{
    private Map _map;
    private int _cellSize;
    private int _wallThickness;

    public Maze(GraphicsDevice graphicsDevice, int rows, int columns, int cellSize)
    {
        _cellSize = cellSize;
        _wallThickness = 5;
        _map = new Map(graphicsDevice);

        // Генерація стін
        AddPerimeterWalls(rows, columns);
        AddHardcodedWalls();
    }

    private void AddPerimeterWalls(int rows, int columns)
    {
        for (int col = 0; col < columns; col++)
        {
            _map.AddHorizontalWall(0, col, _cellSize, _wallThickness); // Верхня межа
            _map.AddHorizontalWall(rows, col, _cellSize, _wallThickness); // Нижня межа
        }

        for (int row = 0; row < rows; row++)
        {
            _map.AddVerticalWall(row, 0, _cellSize, _wallThickness); // Ліва межа
            _map.AddVerticalWall(row, columns, _cellSize, _wallThickness); // Права межа
        }
    }

    private void AddHardcodedWalls()
    {
        _map.AddHorizontalWall(5, 1, _cellSize, _wallThickness);
        // _map.AddHorizontalWall(1, 2, _cellSize, _wallThickness);
        // _map.AddVerticalWall(1, 3, _cellSize, _wallThickness);
        // _map.AddVerticalWall(2, 3, _cellSize, _wallThickness);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _map.Draw(spriteBatch);
    }
}