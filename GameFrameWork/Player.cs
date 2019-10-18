using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWork
{
    class Player : Entity
    {
        public Player() : this('@')
        {

        }
        public Player(char icon) : base(icon)
        {
            PlayerInput.AddKeyEvent(MoveRight, ConsoleKey.RightArrow);
            PlayerInput.AddKeyEvent(MoveLeft, ConsoleKey.LeftArrow);
        }
        private void MoveRight()
        {
            if(x < MyScene.Size-1)
            {
                x++;
            }
        }
        private void MoveUp()
        {
            if (!CurrentScene.GetCollision(x, y - 1))
            {
                Y--;
            }
        }
        private void MoveDown()
        {
            if (!CurrentScene.GetCollision(x, y + 1))
            {
                Y++;
            }
        }

        private void MoveLeft()
        {
            if(x > 0)
            {
                x--;
            }
        }
    }
}
