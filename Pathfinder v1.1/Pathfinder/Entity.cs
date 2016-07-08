

namespace Pathfinder
{
    public class Entity
    {
        private Vector _position;

        public Entity(int x, int y)
        {
            this._position = new Vector(x, y);
        }

        public Entity(Vector newVector)
        {
            this._position = newVector;
        }

        public Vector Position
        {
            get
            {
                return this._position;
            }
            set
            {
                this._position = value;
            }
        }

        public void UpdatePosition(int x, int y)
        {
            this._position.x = x;
            this._position.y = y;
        }

        public int X
        {
            get
            {
                return this._position.x;
            }
            set
            {
                this._position.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this._position.y;
            }
            set
            {
                this._position.y = value;
            }
        }
    }
}
