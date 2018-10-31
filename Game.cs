using System;

namespace TicTacToe
{
    class Game
    {
        public Player[] players { get; set; }
        public String[] board { get; set; }
        public int turn { get; set; }

        public Game(Player p1, Player p2)
        {
            players = new Player[2];
            players[0] = p1;
            players[1] = p2;
            board = new String[9];
            for (int i = 0; i < 9; i++)
            {
                board[i] = " ";
            }
            turn = 0;
        }

        public void play()
        {
            Boolean done = false;
            while (!done)
            {
                displayBoard();
                Player current = players[turn % 2];
                Console.Write(current.name + "'s turn: ");
                current.moves.Sort();
                int newMove = makeMove(current);
                if (winMove(current, newMove))
                {
                    displayBoard();
                    Console.WriteLine(current.name + " wins!");
                    done = true;
                }
                else if (turn < 8)
                    turn++;
                else
                {
                    displayBoard();
                    Console.WriteLine("Game ends in a draw");
                    done = true;
                }
            }
        }
        public int makeMove(Player p)
        {
            Console.WriteLine("Enter your move");
            int X;
            String move = Console.ReadLine();
            while (!Int32.TryParse(move, out X) || X < 1 || X > 9 || (board[X - 1] == "X" || board[X - 1] == "O"))
            {
                Console.WriteLine("Invalid move, enter an available move");
                move = Console.ReadLine();
            }
            board[X - 1] = p.marker;
            p.moves.Add(X);
            return X;
        }
        public Boolean winMove(Player current, int move)
        {
            if (current.moves.Count < 3)
                return false;
            int moveRow = (move - 1) / 3;
            int moveCol = (move - 1) % 3 + 1;
            return checkDiags(current.marker) || checkRowsandCol(moveRow, moveCol, current.marker);
        }

        public void displayBoard()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" " + board[0] + " | " + board[1] + " | " + board[2] + " ");
            Console.WriteLine("-----------");
            Console.WriteLine(" " + board[3] + " | " + board[4] + " | " + board[5] + " ");
            Console.WriteLine("-----------");
            Console.WriteLine(" " + board[6] + " | " + board[7] + " | " + board[8] + " ");
            Console.WriteLine();
        }

        public Boolean checkDiags(String marker){
            //check diagonal
            for (int i = 0; i < 9; i = i + 4){
                if (board[i] != marker){
                    //check anti-diagonal
                    for (int j = 2; j < 7; j = j + 2){
                        if (board[j] != marker)
                            return false;
                    }
                    return true;
                }
            }
            return true;
        }

        public Boolean checkRowsandCol(int row, int col, String marker){
            //check row
            for (int i = 3 * row; i < 3 * (row + 1); i++){
                if (board[i] != marker){
                    for (int j = col; j < (col * 3) + 1; j = j + 3){
                        if (board[j - 1] != marker)
                            return false;
                    }
                    return true;
                }
            }
            return true;
        }
    }
}