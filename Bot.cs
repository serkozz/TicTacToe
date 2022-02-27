using System.Collections.Generic;
using System;

namespace MyTicTacToe
{
    public class Bot : GameField
    {

        public List<int> AvailableFieldsIndex(char[] gameField, char empty)
        {
            List<int> availableFieldsArrayIndex = new List<int>();

            for (int i = 0; i < gameField.Length; i++)
            {
                if (gameField[i] == empty)
                    availableFieldsArrayIndex.Add(i);
            }
            return availableFieldsArrayIndex;
        }

        public void BotTurn(char empty, char[] gameField, bool isPlayerFirstTurn, int turn)
        {
            char X = 'X';
            char O = 'O';
            int gameFieldNumber;
            bool botTurnFlag = true;
            char botSymbol = ' ';
            Random random = new Random();

            List<int> availableFieldsList = new List<int>();
            availableFieldsList = AvailableFieldsIndex(gameField, empty);
            int[] availableFieldsArray = availableFieldsList.ToArray();

            gameFieldNumber = availableFieldsArray[random.Next(0, availableFieldsArray.Length)];

            if (isPlayerFirstTurn == true)
                botSymbol = O;
            if (isPlayerFirstTurn == false)
                botSymbol = X;

            do
            {
                Console.WriteLine("Текущий ход: " + turn);
                Console.WriteLine("Бот ходит...");
                if (gameField[gameFieldNumber] == empty)
                {
                    gameField[gameFieldNumber] = botSymbol;
                    botTurnFlag = false;
                }
            }
            while (botTurnFlag);
        }
    }
}