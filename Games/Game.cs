namespace CourseWork
{
    public abstract class Game
    {
        private static int gameID;
        public int GameID { get; }
        public abstract string GameType { get; }
        public GameAccount Player1 { get; }
        public GameAccount Player2 { get; }
        public GameAccount CrossPlayer { get; private set; }
        public GameAccount ZeroPlayer { get; private set; }
        public int Points { get; protected set; }
        public char[] Board { get; }
        public GameAccount CurrentPlayer { get; protected set; }
        public GameAccount Winner { get; protected set; }
        public GameAccount Looser { get; protected set; }

        public Game(GameAccount player1, GameAccount player2)
        {
            GameID = ++gameID;
            Player1 = player1;
            Player2 = player2;

            Board = new char[9];
            for (int i = 0; i < 9; i++)
            {
                Board[i] = (char)('1' + i); 
            }

            while (true)
            {
                Console.WriteLine($"Player 1 ({Player1.UserName}), choose your symbol: ");
                string choice = Console.ReadLine()?.ToLower();

                if (choice == "x")
                {
                    CrossPlayer = Player1;
                    ZeroPlayer = Player2;
                    break;
                }
                else if (choice == "0")
                {
                    CrossPlayer = Player2;
                    ZeroPlayer = Player1;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please answer with 'x' or '0'.");
                }
            }

            CurrentPlayer = CrossPlayer;
        }

        protected void DisplayBoard()
        {
            Console.Clear();
            for (int i = 0; i < 9; i++)
            {
                Console.Write(Board[i]);
                if ((i + 1) % 3 != 0)
                    Console.Write(" | ");
                else if (i != 8)
                    Console.WriteLine("\n---------");
            }
            Console.WriteLine();
        }

        protected int GetTurn()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter your move (1-9): ");
                    int move = int.Parse(Console.ReadLine());

                    if (move < 1 || move > 9 || Board[move - 1] == 'X' || Board[move - 1] == 'O')
                    {
                        Console.WriteLine("Invalid move. Try again.");
                        continue;
                    }
                    return move - 1; 
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                }
            }
        }

        protected char GetPlayerSymbol()
        {
            return CurrentPlayer == CrossPlayer ? 'X' : 'O';
        }

        protected void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == CrossPlayer ? ZeroPlayer : CrossPlayer;
        }

        protected bool IsWinner(char symbol)
        {
            int[,] winPatterns = new int[,]
            {
                {0, 1, 2}, {3, 4, 5}, {6, 7, 8},
                {0, 3, 6}, {1, 4, 7}, {2, 5, 8},
                {0, 4, 8}, {2, 4, 6}
            };

            for (int i = 0; i < 8; i++)
            {
                if (Board[winPatterns[i, 0]] == symbol &&
                    Board[winPatterns[i, 1]] == symbol &&
                    Board[winPatterns[i, 2]] == symbol)
                {
                    return true;
                }
            }
            return false;
        }

        protected bool IsBoardFull()
        {
            foreach (var cell in Board)
            {
                if (cell != 'X' && cell != 'O')
                    return false;
            }
            return true;
        }

        protected GameAccount GetOpponent()
        {
            return CurrentPlayer == CrossPlayer ? ZeroPlayer : CrossPlayer;
        }

        protected virtual void HandleGameEnd(GameAccount winner, GameAccount loser)
        {
            Console.WriteLine("Game over.");
            if (winner != null)
            {
                Console.WriteLine($"Congratulations {winner.UserName}, you are the winner!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }

        public virtual void Play()
        {
            bool isGameRunning = true;

            while (isGameRunning)
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine($"\nPlayer {CurrentPlayer.UserName}'s turn ({GetPlayerSymbol()}):");
                int move = GetTurn();

                Board[move] = GetPlayerSymbol();

                if (IsWinner(GetPlayerSymbol()))
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine($"Player {CurrentPlayer.UserName} wins!");
                    HandleGameEnd(CurrentPlayer, GetOpponent());
                    isGameRunning = false;
                }
                else if (IsBoardFull())
                {
                    Console.Clear();
                    DisplayBoard();
                    HandleGameEnd(null, null);
                    isGameRunning = false;
                }
                else
                {
                    SwitchPlayer();
                }
            }
        }
    }
}
