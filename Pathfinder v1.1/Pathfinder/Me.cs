
namespace Pathfinder
{
    using System.Collections.Generic;

    public class Me
    {
        private Vector _position;
        private bool _autoUpdatePosition = false;
        private List<Node> _path;

        public Me(int x, int y, bool autoUpdatePosition = false)
        {
            this._position = new Vector(x, y);
            this._path = new List<Node>();
            this._autoUpdatePosition = autoUpdatePosition;
        }

        public Me(Vector newVector)
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

        public string Run()
        {
            if(this._path != null && this._path.Count > 0)
            {
                if (this._path[0].gridX < this._position.x && this._path[0].gridY < this._position.y)
                {
                    if (this._autoUpdatePosition)
                    {
                        this._position.x -= 1;
                        this._position.y -= 1;
                    }
                    return "NW";
                }
            }
            return "";
        }
    }
}
