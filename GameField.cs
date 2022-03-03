using System;

namespace MyTicTacToe
{
    public class GameField
    {
        public void DisplayGameField(char[] gameField) //Метод для вывода игрового поля
        {
            string line = "---+---+---";
            string verticalSeparator = "|";
            Console.Clear();
            Console.WriteLine($" { gameField[0] } { verticalSeparator } { gameField[1] } { verticalSeparator } { gameField[2] } ");
            Console.WriteLine(line);
            Console.WriteLine($" { gameField[3] } { verticalSeparator } { gameField[4] } { verticalSeparator } { gameField[5] } ");
            Console.WriteLine(line);
            Console.WriteLine($" { gameField[6] } { verticalSeparator } { gameField[7] } { verticalSeparator } { gameField[8] } ");
        }

        public bool DetermineWinner(char empty, char[] gameField, bool isPlayerFirstTurn, int turn) //Метод ввода данных и определения победителя
        {
            bool victory = (empty != gameField[0]) && (gameField[0] == gameField[1]) && (gameField[1] == gameField[2]) || //Проверяем, появился ли победитель после хода игрока
            (empty != gameField[3]) && (gameField[3] == gameField[4]) && (gameField[4] == gameField[5]) ||
            (empty != gameField[6]) && (gameField[6] == gameField[7]) && (gameField[7] == gameField[8]) ||
            (empty != gameField[0]) && (gameField[0] == gameField[3]) && (gameField[3] == gameField[6]) ||
            (empty != gameField[1]) && (gameField[1] == gameField[4]) && (gameField[4] == gameField[7]) ||
            (empty != gameField[2]) && (gameField[2] == gameField[5]) && (gameField[5] == gameField[8]) ||
            (empty != gameField[0]) && (gameField[0] == gameField[4]) && (gameField[4] == gameField[8]) ||
            (empty != gameField[2]) && (gameField[2] == gameField[4]) && (gameField[4] == gameField[6]);
            
            DisplayGameField(gameField);

            if (victory && turn % 2 != 0 && isPlayerFirstTurn)
                Console.WriteLine("Победил игрок");
            else if(victory && turn % 2 != 0 && !isPlayerFirstTurn)
                Console.WriteLine("Победил бот");
            else if (turn == 8)
            {
                victory = true;
                Console.WriteLine("Ничья");
            }
            return victory;
        }

        public bool WhoMakesFirstTurn()
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
                    Console.WriteLine("Ошибка. Введите номер от 0 до 1");
                }
            }
            while (tempFlag);

            return isPlayerFirstTurn;
        }
    }
}