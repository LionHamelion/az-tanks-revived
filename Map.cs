namespace az_tanks_revived;

public class Map
{
    public int Rows { get; } // Кількість рядків
    public int Columns { get; } // Кількість стовпців
    public bool[,] HorizontalWalls { get; } // Горизонтальні стіни
    public bool[,] VerticalWalls { get; } // Вертикальні стіни

    public Map(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;

        // Масив для горизонтальних стін: (rows + 1) рядків, кожен довжиною columns
        HorizontalWalls = new bool[rows + 1, columns];

        // Масив для вертикальних стін: rows рядків, кожен довжиною (columns + 1)
        VerticalWalls = new bool[rows, columns + 1];
    }

    // Додати горизонтальну стіну
    public void AddHorizontalWall(int row, int column)
    {
        if (row >= 0 && row <= Rows && column >= 0 && column < Columns)
            HorizontalWalls[row, column] = true;
    }

    // Додати вертикальну стіну
    public void AddVerticalWall(int row, int column)
    {
        if (row >= 0 && row < Rows && column >= 0 && column <= Columns)
            VerticalWalls[row, column] = true;
    }

    // Перевірка, чи є стіна
    public bool HasWall(int row, int column, bool isHorizontal)
    {
        if (isHorizontal)
            return row >= 0 && row <= Rows && column >= 0 && column < Columns && HorizontalWalls[row, column];
        else
            return row >= 0 && row < Rows && column >= 0 && column <= Columns && VerticalWalls[row, column];
    }
}

