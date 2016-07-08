
namespace Pathfinder
{
    using System.Collections.Generic;

    public class AI
    {
        private Pathfinding _pathfinding;
        private Dictionary<string, Entity> _enemyList;
        private Dictionary<string, Entity> _friendlyList;
        private Me _me;

        public AI(int x , int y)
        {
            this._pathfinding = new Pathfinding(x, y);
            this._enemyList = new Dictionary<string, Entity>();
            this._friendlyList = new Dictionary<string, Entity>();
        }

        public void AddEntity(string name, int x, int y, bool enemy)
        {
            if (enemy)
            {
                this._enemyList.Add(name, new Entity(x, y));
                return;
            }
            this._friendlyList.Add(name, new Entity(x, y));
        }

        public void AddMe(int x, int y)
        {
            this._me = new Me(x, y);
        }
    }
}
