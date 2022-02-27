using System;

namespace MyTicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            bool WhoMakesFirstTurn()
            {
                string temp;
                bool tempFlag = true;
                bool isPlayerFirstTurn = true;

                do
                {
                    try
                    {
                        temp = Console.ReadLine();

                        if ((temp == "0"))
                        {
                            isPlayerFirstTurn = true;
                            tempFlag = false;
                        }
                        
                        else if ((temp == "1"))
                        {
                            isPlayerFirstTurn = false;
                            tempFlag = false;
                        }
                        else
                            throw new FormatException();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка. Введите номер клетки от 0 до 1");
                    }
                }
                while (tempFlag);

                return isPlayerFirstTurn;
            }
            
            GameField gameField = new GameField();
            Player player = new Player();
            Bot bot = new Bot();

            char[] field = new char[9];
            char empty = ' ';
            int turn = 0;
            bool gameOver = false;

            Array.Fill(field, empty);

            Console.WriteLine("Кто будет ходить первым? 0 - Игрок, 1 - Бот");
            bool isPlayerFirstTurn = WhoMakesFirstTurn();
            Console.WriteLine("Игрок ходит первым: " + isPlayerFirstTurn);

            gameField.DisplayGameField(field);

            while (gameOver == false)
            {
                turn += 1;
                player.PlayerTurn(empty, field, isPlayerFirstTurn, turn);
                gameOver = gameField.DetermineWinner(empty, field, turn);
            }
            
            Console.ReadKey();
        }
    }
}
