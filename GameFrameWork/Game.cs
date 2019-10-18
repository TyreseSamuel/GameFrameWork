using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWork
{
    class Game
    {
        //Whether or not the Game should finish Running and exit
        public static bool Gameover = false;

        private Scene _currentScene;
        public Game()
        {
            _currentScene = new Scene();
        }
        public void Run()
        {
            Wall wall1 = new Wall(0, 0);
            Wall wall2 = new Wall(1, 0);
            Wall wall3 = new Wall(2, 0);
            Wall wall4 = new Wall(3, 0);
            Wall wall5 = new Wall(4, 0);
            Wall wall6 = new Wall(5, 0);

            Player player = new Player();
            player.x = 4;
            player.Y = 3;
            Entity enemy = new Entity('#');
            enemy.x = 4;
            enemy.Y = 5;

            _currentScene.AddEntity(player);
            _currentScene.AddEntity(enemy);

            _currentScene.Start();

            //Loop until the game is over
            while (!Gameover)
            {
                _currentScene.Update();
                _currentScene.Draw();
                PlayerInput.ReadKey();
            }
        }
    }
}
