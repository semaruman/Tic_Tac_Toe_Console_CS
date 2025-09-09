using System;

public class MainClass
{
    public static void Main()
    {
        PlayTicTacToe();
    }


    static void PlayTicTacToe()
    {
        string[,] map =
        {
            { "1", "2", "3" },
            { "4", "5", "6" },
            { "7", "8", "9" },
        };
        bool ZeroMotion = false;


        for (int i = 0; i < 9; i++)
        {
            Console.Clear();
            if (!ZeroMotion)
            {
                Console.WriteLine("Ходят крестики");
                PrintMap(map);
                Console.WriteLine("Введите цифру вашего хода:\n");
                string motion = GetPlayerCellNumber(map);
                MakeMove(map, motion, ZeroMotion);
                ZeroMotion = true;

                if (HasWinner(map))
                {
                    Console.Clear();
                    PrintMap(map);
                    Console.WriteLine();
                    Console.WriteLine("Крестики победили!");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Ходят нолики");
                PrintMap(map);
                Console.WriteLine("Введите цифру вашего хода:\n");
                string motion = GetPlayerCellNumber(map);
                MakeMove(map, motion, ZeroMotion);
                ZeroMotion = false;

                if (HasWinner(map))
                {
                    Console.Clear();
                    PrintMap(map);
                    Console.WriteLine();
                    Console.WriteLine("Нолики победили!");
                    break;
                }
            }


            if (i == 8 && !HasWinner(map))
            {
                Console.WriteLine("Ничья!");
                break;
            }
        }
    }

    // Функция для вывода поля в консоль
    static void PrintMap(string[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == "X")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(matrix[i, j] + " ");
                    Console.ResetColor();
                }
                else if (matrix[i, j] == "O")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(matrix[i, j] + " ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(matrix[i, j] + " ");
                }

            }
            Console.WriteLine();
        }
    }


    // Функция для проверки, занята ли клетка
    static bool IsMoveCorrect(string[,] matrix, string cellNumber)
    {
        int index = Convert.ToInt32(cellNumber) - 1;
        bool res = matrix[index / 3, index % 3] != "X" && matrix[index / 3, index % 3] != "O";
        return res;
    }


    // Функция для обработки хода пользователя
    static string GetPlayerCellNumber(string[,] matrix)
    {
        string number_input;
        while (true)
        {
            number_input = Console.ReadLine();
            if (number_input.Length != 1)
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, введите цифру от 1 до 9.");
                continue;
            }
            else if (Convert.ToChar(number_input) >= '1' && Convert.ToChar(number_input) <= '9' && IsMoveCorrect(matrix, number_input))
            {
                break;
            }
            else if (Convert.ToChar(number_input) < '1' || Convert.ToChar(number_input) > '9') 
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, введите цифру от 1 до 9.");
            }
            else
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, введите цифру пустой ячейки.");
            }
        }
        return number_input;
    }


    // Функция для добавления хода пользователя на поле
    static string[,] MakeMove(string[,] matrix, string cellNumber, bool isZeroNow)
    {
        int index = Convert.ToInt32(cellNumber) - 1;
        matrix[index / 3, index % 3] = isZeroNow ? "O" : "X";
        return matrix;
    }


    // Функция для проверки, есть ли победитель
    static bool HasWinner(string[,] matrix)
    {
        int n = 3;
        string symbol = string.Empty;
        string[,] gamefield = matrix;

        int i = 0;
        int j = 0;
        if (gamefield[i, j] == gamefield[i + 1, j + 1] && gamefield[i, j] == gamefield[i + 2, j + 2] || gamefield[i, j] == gamefield[i + 1, j] && gamefield[i, j] == gamefield[i + 2, j] || gamefield[i, j] == gamefield[i, j + 1] && gamefield[i, j] == gamefield[i, j + 2]) //главная диагональ, верхняя горизонталь и левая вертикаль
        {
            symbol = gamefield[i, j];
        }
        if (gamefield[i, j + 1] == gamefield[i + 1, j + 1] && gamefield[i, j + 1] == gamefield[i + 2, j + 1]) //средняя вертикаль
        {
            symbol = gamefield[i, j + 1];
        }
        if (gamefield[i, j + 2] == gamefield[i + 1, j + 2] && gamefield[i, j + 2] == gamefield[i + 2, j + 2]) //правая вертикаль
        {
            symbol = gamefield[i, j + 2];
        }
        if (gamefield[i, j + 2] == gamefield[i + 1, j + 1] && gamefield[i, j + 2] == gamefield[i + 2, j]) //побочная диагональ
        {
            symbol = gamefield[i, j + 2];
        }
        if (gamefield[i + 1, j] == gamefield[i + 1, j + 1] && gamefield[i + 1, j] == gamefield[i + 1, j + 2]) //средняя горизонталь
        {
            symbol = gamefield[i + 1, j];
        }
        if (gamefield[i + 2, j] == gamefield[i + 2, j + 1] && gamefield[i + 2, j] == gamefield[i + 2, j + 2]) //нижняя горизонталь
        {
            symbol = gamefield[i + 2, j];
        }
        if (symbol == "X")
        {
            return true;
        }
        if (symbol == "O")
        {
            return true;
        }
        if (symbol == String.Empty)
        {
            return false;
        }
        return false;
    }
}