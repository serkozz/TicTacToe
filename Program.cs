using System;

namespace MyTicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            GameField gameField = new GameField();
            Player player = new Player();
            Bot bot = new Bot();

            char[] field = new char[9];
            char empty = ' ';
            int turn = 0;
            bool gameOver = false;

            Array.Fill(field, empty);

            Console.WriteLine("Кто будет ходить первым? 0 - Игрок, 1 - Бот");
            bool isPlayerFirstTurn = gameField.WhoMakesFirstTurn();
            Console.WriteLine("Игрок ходит первым: " + isPlayerFirstTurn);

            gameField.DisplayGameField(field);

            while (gameOver == false)
            {
                if (isPlayerFirstTurn)
                {
                    turn++;
                    player.PlayerTurn(empty, field, isPlayerFirstTurn, turn);
                    gameOver = gameField.DetermineWinner(empty, field, turn);
                    if (gameOver)
                        break;
                    bot.BotTurn(empty, field, isPlayerFirstTurn, turn);
                    gameField.DisplayGameField(field);
                }

                if (!isPlayerFirstTurn)
                {
                    turn++;
                    bot.BotTurn(empty, field, isPlayerFirstTurn, turn);
                    gameOver = gameField.DetermineWinner(empty, field, turn);
                    if (gameOver)
                        break;
                    player.PlayerTurn(empty, field, isPlayerFirstTurn, turn);
                    gameField.DisplayGameField(field);
                }
            }
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}