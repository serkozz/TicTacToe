using System;

namespace MyTicTacToe
{
    public class Player : GameField
    {
        public void PlayerTurn(char empty, char[] gameField, int turn)
        {
            char X = 'X';
            char O = 'O';
            int player, gameFieldNumber;
            string playerInput = " ";
            bool playerTurnFlag = true;
            //player = (turn % 2) + 1;
            char playerSymbol = 'O';

            do
            {
                try
                {
                    Console.WriteLine("Текущий ход: " + turn);
                    Console.Write("Игрок выберите клетку от 0 до 8: ");
                    playerInput = Console.ReadLine();
                    gameFieldNumber = Convert.ToInt32(playerInput);
                    if ((playerInput.Length == 1) && (gameFieldNumber >= 0) && (gameFieldNumber <= 8))
                    {
                        if (gameField[gameFieldNumber] == empty)
                        {
                            gameField[gameFieldNumber] = playerSymbol;
                            playerTurnFlag = false;
                        }
                        else
                        Console.WriteLine("Ошибка. Выбранная клетка занята");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка. Введите номер клетки от 0 до 8");
                }
            }
            while (playerTurnFlag);

            DisplayGameField(gameField);
        }
    }
}