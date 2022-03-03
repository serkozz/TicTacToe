using System;

namespace MyTicTacToe
{
  public class Player : GameField
  {
    public void PlayerVsAiTurn(char empty, char[] gameField, bool isPlayerFirstTurn, int turn)
    {
      const char X = 'X';
      const char O = 'O';
      int gameFieldNumber;

      string playerInput = " ";
      bool playerTurnFlag = true;
      char playerSymbol = ' ';

      if (isPlayerFirstTurn == true)
        playerSymbol = X;
      if (isPlayerFirstTurn == false)
        playerSymbol = O;

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
    }

    public void PlayerVsPlayerTurn(char empty, char[] gameField, bool isFirstPlayerFirstTurn, int turn)
    {
      const char X = 'X';
      const char O = 'O';

      int gameFieldNumber = default;
      bool playerTurnFlag = true;

      char player1Symbol = ' ';
      char player2Symbol = ' ';
      string playerInput = " ";

      int currentPlayer = 1;
      int remainder = 0;

      if (isFirstPlayerFirstTurn == true)
      {
        player1Symbol = X;
        player2Symbol = O;
      }

      else
      {
        player1Symbol = O;
        player2Symbol = X;
      }

      do
      {
        try
        {
          Console.WriteLine("Текущий ход: " + turn);
          remainder = turn % 2;

          if (remainder != 0)
            currentPlayer = 1;
          else
            currentPlayer = 2;

          Console.Write("Игрок {0} выберите клетку от 0 до 8: ", currentPlayer);

          playerInput = Console.ReadLine();
          gameFieldNumber = Convert.ToInt32(playerInput);

          if ((playerInput.Length == 1) && (gameFieldNumber >= 0) && (gameFieldNumber <= 8))
          {
            if (gameField[gameFieldNumber] == empty && currentPlayer == 1)
            {
              gameField[gameFieldNumber] = player1Symbol;
              playerTurnFlag = false;
            }
            else if (gameField[gameFieldNumber] == empty && currentPlayer == 2)
            {
              gameField[gameFieldNumber] = player2Symbol;
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
    }
  }
}