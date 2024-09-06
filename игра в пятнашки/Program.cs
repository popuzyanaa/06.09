using System;
using System.Collections.Generic;

class PuzzleGame
{
    private int[,] board;
    private int emptyTileRow;
    private int emptyTileCol;

    public PuzzleGame()
    {
        board = new int[4, 4];
        InitBoard();
        ShuffleBoard();
    }

    private void InitBoard()
    {
        int num = 1;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                board[i, j] = num;
                num++;
            }
        }
        board[3, 3] = 0;
        emptyTileRow = 3;
        emptyTileCol = 3;
    }

    private void ShuffleBoard()
    {
        Random rand = new Random();
        List<int> nums = new List<int>();
        for (int i = 0; i < 15; i++)
        {
            nums.Add(i);
        }
        nums.Add(0);

        for (int i = 0; i < 1000; i++)
        {
            int randIndex = rand.Next(0, nums.Count);
            int num = nums[randIndex];
            TryMoveTile(num);
        }
    }

    private void PrintBoard()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    private void TryMoveTile(int num)
    {
        int numRow = -1;
        int numCol = -1;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (board[i, j] == num)
                {
                    numRow = i;
                    numCol = j;
                    break;
                }
            }
            if (numRow != -1 && numCol != -1)
            {
                break;
            }
        }

        if ((Math.Abs(numRow - emptyTileRow) == 1 && numCol == emptyTileCol) ||
            (Math.Abs(numCol - emptyTileCol) == 1 && numRow == emptyTileRow))
        {
            board[emptyTileRow, emptyTileCol] = num;
            board[numRow, numCol] = 0;
            emptyTileRow = numRow;
            emptyTileCol = numCol;
        }
    }

    private bool CheckWin()
    {
        int num = 1;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (board[i, j] != num && num != 16)
                {
                    return false;
                }
                num++;
            }
        }
        return true;
    }

    public void StartGame()
    {
        Console.WriteLine("Добро пожаловать в игру-пятнашки");

        while (true)
        {
            Console.WriteLine("Текущее управление:");
            PrintBoard();

            if (CheckWin())
            {
                Console.WriteLine("Поздравляем, вы выиграли!");
                break;
            }

            Console.WriteLine("Введите число для перемещения (1-15): ");
            int num = Int32.Parse(Console.ReadLine());
            TryMoveTile(num);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        PuzzleGame game = new PuzzleGame();
        game.StartGame();
    }
}