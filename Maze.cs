using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace az_tanks_revived;

public class Maze
{
    private Map _map;
    private int _cellSize;
    private int _wallThickness;

    public Maze(int rows, int columns, int cellSize)
    {
        _cellSize = cellSize;
        _wallThickness = 25;
        _map = new Map();
        Point a = _map.ToMinimapCoordinates(new Point(24,44), _wallThickness, _cellSize);

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
        _map.AddVerticalWall(0, 1, _cellSize, _wallThickness);
        _map.AddVerticalWall(1, 1, _cellSize, _wallThickness);
        _map.AddVerticalWall(1, 2, _cellSize, _wallThickness);
        _map.AddVerticalWall(3, 1, _cellSize, _wallThickness);
        _map.AddHorizontalWall(2, 1, _cellSize, _wallThickness);
        _map.AddHorizontalWall(3, 2, _cellSize, _wallThickness);
    }
    public void Update(GameTime gameTime) {
        // Отримання поточного стану миші
        MouseState mouseState = Mouse.GetState();

        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            Console.WriteLine($"Mouse Clicked at: X = {mouseState.X}, Y = {mouseState.Y}");
            Console.WriteLine(_map.ToMinimapCoordinates(new (mouseState.X, mouseState.Y), _wallThickness,_cellSize));
        }
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        _map.Draw(spriteBatch);
    }
}