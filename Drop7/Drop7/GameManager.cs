﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Drop7
{
    public class GameManager
    {
        private Game _game;
        public Game MyGame
        {
            get
            {
                if (_game != null)
                    return _game;
                return new Game();
            }
        }

        public bool InProgress { get; set; }

        // this could later abstract out to variuous game types, but this will be merely a pass through for now
        public GameManager()
        {
            _game = new Game();
        }

        public void StartGame()
        {
            _game.Start();
            _game.MyBoard.PrintBoard();
            InProgress = true;
        }

        public bool CheckValidInput(int column)
        {
            return MyGame.CanDrop(column);
        }

        public void ProgressGame(int column)
        {
            if (MyGame.Progress(column))
                EndGame();
            else
            {
                Console.WriteLine();
                MyGame.MyBoard.PrintBoard();
            }
        }

        public void EndGame()
        {
            InProgress = false;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(MyGame.Score);
        }
    }
}
