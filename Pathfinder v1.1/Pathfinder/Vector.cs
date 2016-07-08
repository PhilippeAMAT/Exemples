namespace Pathfinder
{
    public class Vector
    {
        private int _x { get; set; }
        private int _y { get; set; }

        public Vector(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int x
        {
            get
            {
                return _x;
            }
            set
            {
                _x = x;
            }
        }

        public int y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = y;
            }
        }
    }
}
