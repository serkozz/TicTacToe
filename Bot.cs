using System.Collections.Generic;
using System;

namespace MyTicTacToe
{
  public class Bot : GameField
  {
    char botSymbol;

    List<int> playerWinNextTurnFields = new List<int>();
    List<int> botWinNextTurnFields = new List<int>();
    List<int> diagonalFieldsAvailable = new List<int>();

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

    public char BotSymbol(bool isPlayerFirstTurn)
    {
      const char X = 'X';
      const char O = 'O';

      if (isPlayerFirstTurn)
        botSymbol = O;
      if (!isPlayerFirstTurn)
        botSymbol = X;

      return botSymbol;
    }

    public List<int> PlayerWinNextTurnFields(char[] gameField, char empty, bool isPlayerFirstTurn, out bool isPlayerWinNextTurn)
    {
      playerWinNextTurnFields.Clear();

      char botSymbol = BotSymbol(isPlayerFirstTurn);
      char playerSymbol = ' ';
      isPlayerWinNextTurn = false;

      if (botSymbol == 'X')
        playerSymbol = 'O';
      else if (botSymbol == 'O')
        playerSymbol = 'X';

      if ((playerSymbol == gameField[0]) && (gameField[0] == gameField[1]) && (gameField[2] == empty))//Проверяем, следующий ход игрока на возможность победы
        playerWinNextTurnFields.Add(2);
      if ((playerSymbol == gameField[1]) && (gameField[1] == gameField[2]) && (gameField[0] == empty))
        playerWinNextTurnFields.Add(0);
      if ((playerSymbol == gameField[0]) && (gameField[0] == gameField[2]) && (gameField[1] == empty)) // Первая строка
        playerWinNextTurnFields.Add(1);


      if ((playerSymbol == gameField[3]) && (gameField[3] == gameField[4]) && (gameField[5] == empty))
        playerWinNextTurnFields.Add(5);
      if ((playerSymbol == gameField[4]) && (gameField[4] == gameField[5]) && (gameField[3] == empty))
        playerWinNextTurnFields.Add(3);
      if ((playerSymbol == gameField[3]) && (gameField[3] == gameField[5]) && (gameField[4] == empty)) // Вторая строка
        playerWinNextTurnFields.Add(4);

      if ((playerSymbol == gameField[6]) && (gameField[6] == gameField[7]) && (gameField[8] == empty))
        playerWinNextTurnFields.Add(8);
      if ((playerSymbol == gameField[7]) && (gameField[7] == gameField[8]) && (gameField[6] == empty))
        playerWinNextTurnFields.Add(6);
      if ((playerSymbol == gameField[6]) && (gameField[6] == gameField[8]) && (gameField[7] == empty)) // Третья строка
        playerWinNextTurnFields.Add(7);

      if ((playerSymbol == gameField[0]) && (gameField[0] == gameField[3]) && (gameField[6] == empty))
        playerWinNextTurnFields.Add(6);
      if ((playerSymbol == gameField[3]) && (gameField[3] == gameField[6]) && (gameField[0] == empty))
        playerWinNextTurnFields.Add(0);
      if ((playerSymbol == gameField[0]) && (gameField[0] == gameField[6]) && (gameField[3] == empty)) // Первый столбец
        playerWinNextTurnFields.Add(3);

      if ((playerSymbol == gameField[1]) && (gameField[1] == gameField[4]) && (gameField[7] == empty))
        playerWinNextTurnFields.Add(7);
      if ((playerSymbol == gameField[4]) && (gameField[4] == gameField[7]) && (gameField[1] == empty))
        playerWinNextTurnFields.Add(1);
      if ((playerSymbol == gameField[1]) && (gameField[1] == gameField[7]) && (gameField[4] == empty)) // Второй столбец
        playerWinNextTurnFields.Add(4);

      if ((playerSymbol == gameField[2]) && (gameField[2] == gameField[5]) && (gameField[8] == empty))
        playerWinNextTurnFields.Add(8);
      if ((playerSymbol == gameField[5]) && (gameField[5] == gameField[8]) && (gameField[2] == empty))
        playerWinNextTurnFields.Add(2);
      if ((playerSymbol == gameField[2]) && (gameField[2] == gameField[8]) && (gameField[5] == empty)) // Третий столбец
        playerWinNextTurnFields.Add(5);

      if ((playerSymbol == gameField[0]) && (gameField[0] == gameField[4]) && (gameField[8] == empty))
        playerWinNextTurnFields.Add(8);
      if ((playerSymbol == gameField[4]) && (gameField[4] == gameField[8]) && (gameField[0] == empty))
        playerWinNextTurnFields.Add(0);
      if ((playerSymbol == gameField[0]) && (gameField[0] == gameField[8]) && (gameField[4] == empty)) // \ диагональ
        playerWinNextTurnFields.Add(4);

      if ((playerSymbol == gameField[2]) && (gameField[2] == gameField[4]) && (gameField[6] == empty))
        playerWinNextTurnFields.Add(6);
      if ((playerSymbol == gameField[4]) && (gameField[4] == gameField[6]) && (gameField[2] == empty))
        playerWinNextTurnFields.Add(2);
      if ((playerSymbol == gameField[2]) && (gameField[2] == gameField[6]) && (gameField[4] == empty)) // / диагональ
        playerWinNextTurnFields.Add(4);

      if (playerWinNextTurnFields.Count != 0)
        isPlayerWinNextTurn = true;

      return playerWinNextTurnFields;
    }

    public List<int> BotWinNextTurnFields(char[] gameField, char empty, bool isPlayerFirstTurn, out bool isBotWinNextTurn)
    {
      botWinNextTurnFields.Clear();
      isBotWinNextTurn = false;

      char botSymbol = BotSymbol(isPlayerFirstTurn);

      if ((botSymbol == gameField[0]) && (gameField[0] == gameField[1]) && (gameField[2] == empty))//Проверяем, следующий ход бота на возможность победы
        botWinNextTurnFields.Add(2);
      if ((botSymbol == gameField[1]) && (gameField[1] == gameField[2]) && (gameField[0] == empty))
        botWinNextTurnFields.Add(0);
      if ((botSymbol == gameField[0]) && (gameField[0] == gameField[2]) && (gameField[1] == empty)) // Первая строка
        botWinNextTurnFields.Add(1);


      if ((botSymbol == gameField[3]) && (gameField[3] == gameField[4]) && (gameField[5] == empty))
        botWinNextTurnFields.Add(5);
      if ((botSymbol == gameField[4]) && (gameField[4] == gameField[5]) && (gameField[3] == empty))
        botWinNextTurnFields.Add(3);
      if ((botSymbol == gameField[3]) && (gameField[3] == gameField[5]) && (gameField[4] == empty)) // Вторая строка
        botWinNextTurnFields.Add(4);

      if ((botSymbol == gameField[6]) && (gameField[6] == gameField[7]) && (gameField[8] == empty))
        botWinNextTurnFields.Add(8);
      if ((botSymbol == gameField[7]) && (gameField[7] == gameField[8]) && (gameField[6] == empty))
        botWinNextTurnFields.Add(6);
      if ((botSymbol == gameField[6]) && (gameField[6] == gameField[8]) && (gameField[7] == empty)) // Третья строка
        botWinNextTurnFields.Add(7);

      if ((botSymbol == gameField[0]) && (gameField[0] == gameField[3]) && (gameField[6] == empty))
        botWinNextTurnFields.Add(6);
      if ((botSymbol == gameField[3]) && (gameField[3] == gameField[6]) && (gameField[0] == empty))
        botWinNextTurnFields.Add(0);
      if ((botSymbol == gameField[0]) && (gameField[0] == gameField[6]) && (gameField[3] == empty)) // Первый столбец
        botWinNextTurnFields.Add(3);

      if ((botSymbol == gameField[1]) && (gameField[1] == gameField[4]) && (gameField[7] == empty))
        botWinNextTurnFields.Add(7);
      if ((botSymbol == gameField[4]) && (gameField[4] == gameField[7]) && (gameField[1] == empty))
        botWinNextTurnFields.Add(1);
      if ((botSymbol == gameField[1]) && (gameField[1] == gameField[7]) && (gameField[4] == empty)) // Второй столбец
        botWinNextTurnFields.Add(4);

      if ((botSymbol == gameField[2]) && (gameField[2] == gameField[5]) && (gameField[8] == empty))
        botWinNextTurnFields.Add(8);
      if ((botSymbol == gameField[5]) && (gameField[5] == gameField[8]) && (gameField[2] == empty))
        botWinNextTurnFields.Add(2);
      if ((botSymbol == gameField[2]) && (gameField[2] == gameField[8]) && (gameField[5] == empty)) // Третий столбец
        botWinNextTurnFields.Add(5);

      if ((botSymbol == gameField[0]) && (gameField[0] == gameField[4]) && (gameField[8] == empty))
        botWinNextTurnFields.Add(8);
      if ((botSymbol == gameField[4]) && (gameField[4] == gameField[8]) && (gameField[0] == empty))
        botWinNextTurnFields.Add(0);
      if ((botSymbol == gameField[0]) && (gameField[0] == gameField[8]) && (gameField[4] == empty)) // \ диагональ
        botWinNextTurnFields.Add(4);

      if ((botSymbol == gameField[2]) && (gameField[2] == gameField[4]) && (gameField[6] == empty))
        botWinNextTurnFields.Add(6);
      if ((botSymbol == gameField[4]) && (gameField[4] == gameField[6]) && (gameField[2] == empty))
        botWinNextTurnFields.Add(2);
      if ((botSymbol == gameField[2]) && (gameField[2] == gameField[6]) && (gameField[4] == empty)) // / диагональ
        botWinNextTurnFields.Add(4);

      if (botWinNextTurnFields.Count != 0)
        isBotWinNextTurn = true;

      return botWinNextTurnFields;
    }

    public List<int> DiagonalFields(char[] gameField, char empty, bool isPlayerFirstTurn, out bool isDiagonalFieldsAvailable)
    {
      diagonalFieldsAvailable.Clear();

      isDiagonalFieldsAvailable = false;

      if (empty == gameField[0])
        diagonalFieldsAvailable.Add(0);
      if (empty == gameField[2])
        diagonalFieldsAvailable.Add(2);
      if (empty == gameField[6])
        diagonalFieldsAvailable.Add(6);
      if (empty == gameField[8])
        diagonalFieldsAvailable.Add(8);

      if (diagonalFieldsAvailable.Count != 0)
        isDiagonalFieldsAvailable = true;

      return diagonalFieldsAvailable;
    }

    public void BotRandomTurn(char empty, char[] gameField, bool isPlayerFirstTurn, int turn)
    {
      int gameFieldNumber;
      bool botTurnFlag = true;

      Random random = new Random();

      List<int> availableFieldsList = new List<int>();
      availableFieldsList = AvailableFieldsIndex(gameField, empty);
      int[] availableFieldsArray = availableFieldsList.ToArray();

      gameFieldNumber = availableFieldsArray[random.Next(0, availableFieldsArray.Length)];

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

    public void BotAlgorithmicTurn(char empty, char[] gameField, bool isPlayerFirstTurn, int turn)
    {
      int gameFieldNumber = 0;
      bool botTurnFlag = true;

      bool isBotWinNextTurn = false;
      bool isPlayerWinNextTurn = false;
      bool isDiagonalFieldsAvailable = false;

      Random random = new Random();
      List<int> availableFieldsList = new List<int>();

      availableFieldsList = BotWinNextTurnFields(gameField, empty, isPlayerFirstTurn, out isBotWinNextTurn);

      if (!isBotWinNextTurn)
      {
        availableFieldsList = PlayerWinNextTurnFields(gameField, empty, isPlayerFirstTurn, out isPlayerWinNextTurn);

        if (!isPlayerWinNextTurn)
        {
          availableFieldsList = DiagonalFields(gameField, empty, isPlayerFirstTurn, out isDiagonalFieldsAvailable);

          if (!isDiagonalFieldsAvailable)
          {
            BotRandomTurn(empty, gameField, isPlayerFirstTurn, turn);
            return;
          }
        }
      }

      if (availableFieldsList.Count != 0)
        gameFieldNumber = availableFieldsList[0];

      do
      {
        Console.WriteLine("Текущий ход: " + turn);
        Console.WriteLine("Бот ходит...");

        if (availableFieldsList.Count != 0)
        {
          if (gameField[gameFieldNumber] == empty)
          {
            gameField[gameFieldNumber] = botSymbol;
            botTurnFlag = false;
          }
          else
          {
            BotRandomTurn(empty, gameField, isPlayerFirstTurn, turn);
            botTurnFlag = false;
          }

        }
        else
        {
          BotRandomTurn(empty, gameField, isPlayerFirstTurn, turn);
          botTurnFlag = false;
        }
      }
      while (botTurnFlag);
    }
  }
}