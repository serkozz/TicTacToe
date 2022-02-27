using System;

namespace MyTicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            GameField gameField = new GameField();
            Player player = new Player();
            Bot bot = new Bot();

            char[] field = new char[9];
            char empty = ' ';
            int turn = 0;
            bool gameOver = false;

            Array.Fill(field, empty);

            gameField.DisplayGameField(field);

            while (gameOver == false)
            {
                turn += 1;
                player.PlayerTurn(empty, field, turn);
                gameOver = gameField.DetermineWinner(empty, field, turn);
            }
            
            Console.ReadKey();
        }
    }
}
