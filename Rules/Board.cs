﻿using System;

namespace Rules
{
    public class Board
    {
        private readonly int _x;
        private readonly int _y;
        private Cell[,] _board;
        
        public Board(int x, int y)
        {
            _x = x;
            _y = y;
            _board = new Cell[x,y];
            lol();
        }

        public bool CanPlay(int x, int y)
        {
            return x <= _x && y <= _y && IsFree(x, y);
        }

        public void lol()
        {
            for (var m = 0; m < _x ; m++)
            {
                for (var n = 0; n < _y ; n++)
                {
                    _board[m, n] = new Cell();
                }
            }
        }
        
        private bool IsFree(int x, int y)
        {
            return _board[x, y].State == State.Free;
        }

        // TODO
        public bool Play(int x, int y)
        {
            return true;
        }

        // TODO
        public bool AddMoveToBoard(int x, int y, State player)
        {
            return true;
        }
        
        
    }
}