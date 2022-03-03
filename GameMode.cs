using System;

namespace MyTicTacToe
{
  public class GameMode
  {
    char[] field;
    bool gameOver;
    int turn;
    char empty;

    // Конструктор
    public GameMode(char[] field, bool gameOver, int turn, char empty)
    {
      this.field = field;
      this.gameOver = gameOver;
      this.turn = turn;
      this.empty = empty;
    }

    GameField gameField = new GameField();
    Player player = new Player();
    Bot bot = new Bot();

    public void PlayerVsAi()
    {
      Console.WriteLine("Кто будет ходить первым? 0 - Игрок, 1 - Бот");
      bool isPlayerFirstTurn = gameField.WhoMakesFirstTurn();
      Console.WriteLine("Игрок ходит первым: " + isPlayerFirstTurn);

      gameField.DisplayGameField(field);

      while (gameOver == false)
      {
        if (isPlayerFirstTurn)
        {
          turn++;
          player.PlayerVsAiTurn(empty, field, isPlayerFirstTurn, turn);
          gameOver = gameField.DetermineWinner(empty, field, isPlayerFirstTurn, turn, false);
          if (gameOver)
            break;
          turn++;
          //bot.BotRandomTurn(empty, field, isPlayerFirstTurn, turn);
          bot.BotAlgorithmicTurn(empty, field, isPlayerFirstTurn, turn);
          gameField.DisplayGameField(field);
          gameOver = gameField.DetermineWinner(empty, field, isPlayerFirstTurn, turn, false);
          if (gameOver)
            break;
        }

        if (!isPlayerFirstTurn)
        {
          turn++;
          //bot.BotRandomTurn(empty, field, isPlayerFirstTurn, turn);
          bot.BotAlgorithmicTurn(empty, field, isPlayerFirstTurn, turn);
          gameOver = gameField.DetermineWinner(empty, field, isPlayerFirstTurn, turn, false);
          if (gameOver)
            break;
          turn++;
          player.PlayerVsAiTurn(empty, field, isPlayerFirstTurn, turn);
          gameField.DisplayGameField(field);
          gameOver = gameField.DetermineWinner(empty, field, isPlayerFirstTurn, turn, false);
          if (gameOver)
            break;
        }
      }
    }

    public void PlayerVsPlayer(Player player)
    {
      bool isFirstPlayerFirstTurn = true;

      gameField.DisplayGameField(field);

      while (gameOver == false)
      {
        if (isFirstPlayerFirstTurn)
        {
          turn++;
          player.PlayerVsPlayerTurn(empty, field, isFirstPlayerFirstTurn, turn);
          gameOver = gameField.DetermineWinner(empty, field, isFirstPlayerFirstTurn, turn, true);
          if (gameOver)
            break;
          turn++;
          player.PlayerVsPlayerTurn(empty, field, isFirstPlayerFirstTurn, turn);
          gameField.DisplayGameField(field);
          gameOver = gameField.DetermineWinner(empty, field, isFirstPlayerFirstTurn, turn, true);
          if (gameOver)
            break;
        }

        if (!isFirstPlayerFirstTurn)
        {
          turn++;
          player.PlayerVsPlayerTurn(empty, field, isFirstPlayerFirstTurn, turn);
          gameOver = gameField.DetermineWinner(empty, field, isFirstPlayerFirstTurn, turn, true);
          if (gameOver)
            break;
          turn++;
          player.PlayerVsPlayerTurn(empty, field, isFirstPlayerFirstTurn, turn);
          gameField.DisplayGameField(field);
          gameOver = gameField.DetermineWinner(empty, field, isFirstPlayerFirstTurn, turn, true);
          if (gameOver)
            break;
        }
      }
    }
  }
}