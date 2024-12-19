using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace az_tanks_revived;

public class Maze
{
    private Map _map; // Карта, яка зберігає дані про стіни
    private Texture2D _wallTexture; // Текстура стін
    private int _wallThickness = 5; // Товщина стін
    private int _cellSize; // Розмір клітинки в пікселях

    public Maze(GraphicsDevice graphicsDevice, int rows, int columns, int cellSize)
    {
        _cellSize = cellSize;

        // Ініціалізація карти
        _map = new Map(rows, columns);

        // Створення текстури для стін
        _wallTexture = new Texture2D(graphicsDevice, 1, 1);
        _wallTexture.SetData(new[] { Color.White });

        // Захардкоджені стіни
        AddHardcodedWalls();
        //AddRandomWalls(25,25);
        AddPerimeterWalls();
    }

    // Додати захардкоджені стіни
    private void AddHardcodedWalls()
    {
        _map.AddHorizontalWall(0, 0);
        _map.AddHorizontalWall(1, 2);
        _map.AddHorizontalWall(1, 3);
        _map.AddVerticalWall(1, 3);
        _map.AddVerticalWall(1, 2);
        _map.AddHorizontalWall(2, 2);
        _map.AddVerticalWall(2, 0);
        _map.AddVerticalWall(3, 3);
    }

    // Додати стіни по периметру карти
    private void AddPerimeterWalls()
    {
        // Верхня і нижня межі
        for (int col = 0; col < _map.Columns; col++)
        {
            _map.AddHorizontalWall(0, col); // Верхня межа
            _map.AddHorizontalWall(_map.Rows, col); // Нижня межа
        }

        // Ліва і права межі
        for (int row = 0; row < _map.Rows; row++)
        {
            _map.AddVerticalWall(row, 0); // Ліва межа
            _map.AddVerticalWall(row, _map.Columns); // Права межа
        }
    }

    // Метод для наповнення мапи рандомними стінами
    public void AddRandomWalls(int horizontalWallCount, int verticalWallCount)
    {
        Random random = new Random();

        // Додаємо рандомні горизонтальні стіни
        for (int i = 0; i < horizontalWallCount; i++)
        {
            int row = random.Next(0, _map.Rows + 1);
            int column = random.Next(0, _map.Columns);
            _map.AddHorizontalWall(row, column);
        }

        // Додаємо рандомні вертикальні стіни
        for (int i = 0; i < verticalWallCount; i++)
        {
            int row = random.Next(0, _map.Rows);
            int column = random.Next(0, _map.Columns + 1);
            _map.AddVerticalWall(row, column);
        }
    }

    // Метод для малювання всіх стін
    public void Draw(SpriteBatch spriteBatch)
    {
        // Малюємо горизонтальні стіни
        for (int row = 0; row <= _map.Rows; row++)
        {
            for (int col = 0; col < _map.Columns; col++)
            {
                if (_map.HasWall(row, col, true))
                {
                    var rect = new Rectangle(
                        col * _cellSize, 
                        row * _cellSize, 
                        _cellSize + _wallThickness, // Додаємо товщину для з'єднання в кутах
                        _wallThickness
                    );
                    spriteBatch.Draw(_wallTexture, rect, Color.Black);
                }
            }
        }

        // Малюємо вертикальні стіни
        for (int row = 0; row < _map.Rows; row++)
        {
            for (int col = 0; col <= _map.Columns; col++)
            {
                if (_map.HasWall(row, col, false))
                {
                    var rect = new Rectangle(
                    col * _cellSize, 
                    row * _cellSize, 
                    _wallThickness, 
                    _cellSize + _wallThickness // Додаємо товщину для з'єднання в кутах
                );
                    spriteBatch.Draw(_wallTexture, rect, Color.Black);
                }
            }
        }
    }
}
