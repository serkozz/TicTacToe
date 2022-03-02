using System;

namespace MyTicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            char[] field = new char[9];
            char empty = ' ';
            int turn = 0;
            bool gameOver = false;

            GameMode gameMode = new GameMode(field, gameOver, turn, empty);
            GameField gameField = new GameField();
            Player player = new Player();
            Player firstPlayer = new Player();
            Player secondPlayer = new Player();
            Bot bot = new Bot();

            string gameModeInput;
            int gameModeChanger;
            bool gameModeFlag = true;

            Array.Fill(field, empty);

            Console.WriteLine("Выберите режим игры: 0 - Игрок vs Бот, 1 - Игрок vs Игрок");

            do
            {
                try
                {
                    gameModeInput = Console.ReadLine();
                    gameModeChanger = Convert.ToInt32(gameModeInput);

                    if (gameModeChanger == 0)
                    {
                        gameModeFlag = false;
                        gameMode.PlayerVsAi();
                    }
                    if (gameModeChanger == 1)
                    {
                        gameModeFlag = false;
                        gameMode.PlayerVsPlayer(firstPlayer, secondPlayer);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка, введите число от 0 до 1");
                }
            }
            while (gameModeFlag);

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}