using System;

namespace MyTicTacToe
{
    public class GameMode
    {
        char[] field;
        bool gameOver;
        int turn;
        char empty;

        // Конструктор для режима игрок против бота
        public GameMode(char[] field, bool gameOver, int turn, char empty)
        {
            this.field = field;
            this.gameOver = gameOver;
            this.turn = turn;
            this.empty = empty;
        }

        // Конструктор для режима игрок против игрока
        // public GameMode(char[] field, bool gameOver, int turn, char empty, Player firstPlayer, Player secondPlayer)
        // {
        //     this.field = field;
        //     this.gameOver = gameOver;
        //     this.turn = turn;
        //     this.empty = empty;
        //     this.firstPlayer = firstPlayer;
        //     this.secondPlayer = secondPlayer;
        // }

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
                    gameOver = gameField.DetermineWinner(empty, field, isPlayerFirstTurn, turn);
                    if (gameOver)
                        break;
                    turn++;
                    //bot.BotRandomTurn(empty, field, isPlayerFirstTurn, turn);
                    bot.BotAlgorithmicTurn(empty, field, isPlayerFirstTurn, turn);
                    gameField.DisplayGameField(field);
                }

                if (!isPlayerFirstTurn)
                {
                    turn++;
                    //bot.BotRandomTurn(empty, field, isPlayerFirstTurn, turn);
                    bot.BotAlgorithmicTurn(empty, field, isPlayerFirstTurn, turn);
                    gameOver = gameField.DetermineWinner(empty, field, isPlayerFirstTurn, turn);
                    if (gameOver)
                        break;
                    turn++;
                    player.PlayerVsAiTurn(empty, field, isPlayerFirstTurn, turn);
                    gameField.DisplayGameField(field);
                }
            }
        }

        public void PlayerVsPlayer(Player firstPlayer, Player secondPlayer)
        {
            Console.WriteLine("Кто будет ходить первым? 0 - Игрок 1, 1 - Игрок 2");
            bool isFirstPlayerFirstTurn = gameField.WhoMakesFirstTurn();
            Console.WriteLine("Игрок 1 ходит первым: " + isFirstPlayerFirstTurn);

            gameField.DisplayGameField(field);

            while (gameOver == false)
            {
                if (isFirstPlayerFirstTurn)
                {
                    turn++;
                    firstPlayer.PlayerVsPlayerTurn(empty, field, isFirstPlayerFirstTurn, turn);
                    gameOver = gameField.DetermineWinner(empty, field, isFirstPlayerFirstTurn, turn);
                    if (gameOver)
                        break;
                    turn++;
                    secondPlayer.PlayerVsPlayerTurn(empty, field, isFirstPlayerFirstTurn, turn);
                    gameField.DisplayGameField(field);
                }

                if (!isFirstPlayerFirstTurn)
                {
                    turn++;
                    bot.BotRandomTurn(empty, field, isFirstPlayerFirstTurn, turn);
                    gameOver = gameField.DetermineWinner(empty, field, isFirstPlayerFirstTurn, turn);
                    if (gameOver)
                        break;
                    turn++;
                    player.PlayerVsPlayerTurn(empty, field, isFirstPlayerFirstTurn, turn);
                    gameField.DisplayGameField(field);
                }
            }
        }
    }
}