using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFrameWork
{
    class Scene
    {
        private List<Entity> _entities = new List<Entity>();
        private int _sizeX;
        private int _sizeY;
        private bool[,] _collision;

        public Scene() : this(24,6)
        {
            
        }
        public Scene(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            //Create the collision grid
            _collision = new bool[_sizeX, _sizeY];
        }
        public int SizeX
        {
            get
            {
                return _sizeX;
            }
        }
        public int SizeY
        {
            get
            {
                return _sizeY;
            }
        }
        public void Start()
        {
            foreach(Entity e in _entities)
            {
                e.Start();
            }
        }
        public void Update()
        {
            _collision = new bool[_sizeX, _sizeY];

            foreach (Entity e in _entities)
            {
                e.Update();
            }
        }
        public void Draw()
        {
            //Clear the screen
            Console.Clear();

            char[] display = new char[24];

            foreach(Entity e in _entities)
            {
                e.Draw();
                if (e.x >= 0 && e.x < _sizeX
                    && e.Y >= 0 && e.Y < _sizeY)
                {
                    display[(int)e.X, (int)e.Y] = e.Icon;
                }
            }
            for (int i = 0; i < _size; i++)
            {
                Console.Write(display[i]);
            }
        }

        //Add an Entity to the Scene
        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
            entity.MyScene = this;
        }

        //Remove an Entity from the Scene
        public void RemoveEntity(Entity entity)
        {
            _entities.Add(entity);
            entity.MyScene = null;
        }

        //Clear the Scene
        public void ClearEntities()
        {
            foreach(Entity e in _entities)
            {
                e.MyScene = null;
            }
            _entities.Clear();
        }
        //Returns whether there is a solid entity
        public bool GetCollision(float x, float y)
        {
            if (x >= 0 && y >= 0 && x < _sizeX && y < _sizeY)
            {
                return _collision[(int)x, (int)y];
            }
            else
            {
                return false;
            }
        }
    }
}
