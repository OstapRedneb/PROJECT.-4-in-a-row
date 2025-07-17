namespace ПРОЕКТ._4_в_ряд
{
    internal class Program
    {
        static void Main(string[] args) // Игра
        {
            while (true)
            {
                bool flag = false;
                Console.WriteLine("4 в ряд");
                Console.WriteLine();
                Console.WriteLine("1. Начать игру");
                Console.WriteLine("2. Выйти из игры");
                Console.WriteLine();
                string input;
                while (true)
                {
                    input = Console.ReadLine();
                    Console.Clear();
                    if (!(input == "1" || input == "2")) continue;
                    if (input == "2") flag = true;
                    break;
                }
                if (flag) break;

                Console.WriteLine();

                string[,] gameMap = new string[6, 7] { { "#", "#", "#", "#", "#", "#", "#"}, { "#", "#", "#", "#", "#", "#", "#" }, { "#", "#", "#", "#", "#", "#", "#" }, { "#", "#", "#", "#", "#", "#", "#" }, { "#", "#", "#", "#", "#", "#", "#" }, { "#", "#", "#", "#", "#", "#", "#" } };

                bool isZerowNow;
                for (int k = 0; k < 42; k++)
                {
                    if (k % 2 == 0) isZerowNow = false;
                    else isZerowNow = true;

                    if (isZerowNow) Console.WriteLine("Ходят нолики");
                    else Console.WriteLine("Ходят крестики");
                    Console.WriteLine("1 2 3 4 5 6 7");
                    PrintMap(gameMap);
                    Console.WriteLine("Введите цифру вашего хода:");
                    Console.WriteLine();

                    while (true)
                    {
                        input = Console.ReadLine();
                        if (!(input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7")) continue;
                        if (!InputContains(gameMap, input)) continue;
                        break;
                    }
                    gameMap = FindAndChange(gameMap, input, isZerowNow);

                    if (CheckWiner(gameMap, isZerowNow))
                    {
                        if (isZerowNow)
                        {
                            Console.WriteLine("1 2 3 4 5 6 7");
                            PrintMap(gameMap);
                            Console.WriteLine("Нолики победили!");
                        }
                        else
                        {
                            Console.WriteLine("1 2 3 4 5 6 7");
                            PrintMap(gameMap);
                            Console.WriteLine("Крестики победили!");
                        }
                        break;
                    }
                    if (k == 41)
                    {
                        Console.WriteLine("1 2 3 4 5 6 7");
                        PrintMap(gameMap);
                        Console.WriteLine("Ничья!");
                    }
                    Console.WriteLine();
                }
            }
        }
        static bool CheckWiner(string[,] gameMap, bool isZeroNow) // Проверить поле на наличие выигрыша 
        {
            string findChar;
            if (isZeroNow) findChar = "O";
            else findChar = "X";

            for (int i = 0; i < gameMap.GetLength(0); i++) 
            {
                for (int j = 0; j < gameMap.GetLength(1); j++) 
                {
                    if (i < 3 && j < 4) // Проверка диагоналей
                    {
                        if (gameMap[i, j] == gameMap[i + 1, j + 1] && gameMap[i, j] == gameMap[i + 2, j + 2] && gameMap[i, j] == gameMap[i + 3, j + 3] && gameMap[i, j] == findChar) return true;
                        if (gameMap[i, j + 3] == gameMap[i + 1, j + 2] && gameMap[i, j + 3] == gameMap[i + 2, j + 1] && gameMap[i, j + 3] == gameMap[i + 3, j] && gameMap[i + 3, j] == findChar) return true;
                    }
                    if (j < 4 && gameMap[i, j] == gameMap[i, j + 1] && gameMap[i, j] == gameMap[i, j + 2] && gameMap[i, j] == gameMap[i, j + 3] && gameMap[i, j] == findChar) return true; // Проверка горизонталей
                    if (i < 3 && gameMap[i, j] == gameMap[i + 1, j] && gameMap[i, j] == gameMap[i + 2, j] && gameMap[i, j] == gameMap[i + 3, j] && gameMap[i, j] == findChar) return true; // Проверка вертикалей
                }
            }

            return false;
        }
        static string[,] FindAndChange(string[,] gameMap, string input, bool isZeroNow) // Заменить в поле цифру на символ 
        {
            string result;
            if (isZeroNow) result = "O";
            else result = "X";

            for (int i = gameMap.GetLength(0) - 1; i >= 0; i--)
            {
                if (gameMap[i, int.Parse(input) - 1] == "#") 
                {
                    gameMap[i, int.Parse(input) - 1] = result;
                    return gameMap;
                }
            }

            return gameMap;
        }
        static bool InputContains(string[,] gameMap, string input) // Проверить ввод пользователя на наличие существующего уже хода на поле 
        {
            return !(gameMap[0, int.Parse(input) - 1] == "X" || gameMap[0, int.Parse(input) - 1] == "O");
        }
        static void PrintMap(string[,] gameMap) // Вывод поля через пробелы 
        {
            for (int i = 0; i < gameMap.GetLength(0); i++)
            {
                for (int j = 0; j < gameMap.GetLength(1); j++)
                {
                    if (gameMap[i, j] == "X") Console.ForegroundColor = ConsoleColor.Red;
                    if (gameMap[i, j] == "O") Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(gameMap[i, j] + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
