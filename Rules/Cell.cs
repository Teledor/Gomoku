﻿namespace Rules
{
    public class Cell
    {
        public State State = State.Free;
        private int _x;
        private int _y;

        public Cell(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}