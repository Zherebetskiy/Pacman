using PacmanLibrary.Foods;
using PacmanLibrary.Ghosts;
using PacmanLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PacmanLibrary
{
    public class Game : IGame
    {
        Pacman pacman;
        List<Ghost> ghosts;
        IField field;
        int lifes;
        int points;

        public bool SaveScore { get; set; }

        public IPoint[,] Field { get { return field.ChangedField; } }

        public int Score { get { return pacman.Score; } }

        public int Lifes { get { return lifes; } }


        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public Game(IField field)
        {
            SaveScore = false;

            this.field = field;
            points = field.Points;
            lifes = 3;
            pacman = new Pacman(field.ChangedField);

            var blinky = new Blinky(field);
            var pinky = new Pinky(field);
            var inky = new Inky(blinky, field);
            var clyde = new Clyde(field);

            ghosts = new List<Ghost> { blinky, pinky, inky, clyde };
        }

        void UpdatePacmanPosition()
        {
            field.ChangedField[pacman.OldPosition.X, pacman.OldPosition.Y] = new EmptyBlock(pacman.OldPosition.X, pacman.OldPosition.Y);
            field.ChangedField[pacman.X, pacman.Y] = pacman;
        }

        public void ChangeDirection(string key)
        {
            pacman.OldMoving = pacman.CurrentMoving;

            switch (key)
            {
                case "ArrowLeft":
                    pacman.CurrentMoving = Direction.left;
                    break;
                case "ArrowRight":
                    pacman.CurrentMoving = Direction.right;
                    break;
                case "ArrowUp":
                    pacman.CurrentMoving = Direction.up;
                    break;
                case "ArrowDown":
                    pacman.CurrentMoving = Direction.down;
                    break;
                default:
                    break;
            }
        }

        public void PlayGame(object key)
        {
            foreach (var ghost in ghosts)
            {
                ghost.Go(pacman, field.ChangedField);
            }

            pacman.Go(null);


            if (field.ChangedField[pacman.X, pacman.Y] is IEatable someFood)
            {
                someFood.BeEatenByPacman(pacman, this);
            }

            foreach (var ghost in ghosts)
            {
                if (pacman.OldPosition == ghost.Position)
                {
                    if (ghost.behavior == Behavior.frightened)
                    {
                        ghost.BeEatenByPacman(pacman, this);
                    }
                    else
                    {
                        ghost.EatPacman(this);
                    }                  
                }
            }
            
            if (points <= 1)
            {
                NextLevel();
            }

            UpdatePacmanPosition();
        }

        void NextLevel()
        {
            points = field.Points;

            BaseField();

            StartPositions();
        }

        public void ChangeBehaviorOnFrightened()
        {
            foreach (var ghost in ghosts)
            {
                ghost.ChangeBehaviorOnFrightened(null, null);
            }
        }

        public void LoseLife()
        {
            lifes--;

            if (lifes < 1)
            {
                SaveScore = true;
               // GameOver();
            }

            StartPositions();
        }

        void StartPositions()
        {
            foreach (var ghost in ghosts)
            {
                ghost.StartPosition();
            }

            pacman.StartPosition();
        }

        //public void NewGame()
        //{
        //    field.ChangedField = field.CurrentField;
        //    StartPositions();
        //    pacman = new Pacman(field.ChangedField);
        //    lifes = 3;
        //    points = field.Points;
        //}

       public void GameOver()
        {
            BaseField();

            lifes = 3;
            StartPositions();
            pacman = new Pacman(field.ChangedField);
            points = field.Points;
        }

        void BaseField()
        {
            for (int i = 0; i < field.ChangedField.GetLength(0); i++)
            {
                for (int j = 0; j < field.ChangedField.GetLength(1); j++)
                {
                    field.ChangedField[i, j] = field.CurrentField[i, j];
                }
            }
        }
    }
}
//refactoring.guru