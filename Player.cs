using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Player
    {
        public String name { get; set; }
        public String marker { get; set; }
        public List<int> moves { get; set; }

        public Player(String n, String m)
        {
            name = n;
            marker = m;
            moves = new List<int>();
        }
    }
}