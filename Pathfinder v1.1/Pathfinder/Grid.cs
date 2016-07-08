namespace Pathfinder
{
    using System.Collections.Generic;

    public class Grid
    {
        public float nodeRadius;
        private Node[,] grid;
        private int gridSizeX, gridSizeY;
        public List<Node> path;

        public Grid(int gridWorldSize_X, int gridWorldSize_Y)
        {
            gridSizeX = gridWorldSize_X;
            gridSizeY = gridWorldSize_Y;

            grid = new Node[gridSizeX, gridSizeY];

            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    bool walkable = true;
                    grid[x, y] = new Node(walkable, x, y);
                }
            }
        }

        public int MaxSize
        {
            get
            {
                return gridSizeX * gridSizeY;
            }
        }

        public List<Node> GetNeighbours(Node node)
        {
            List<Node> neighbours = new List<Node>();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0) continue;

                    int checkX = node.gridX + x;
                    int checkY = node.gridY + y;

                    if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                    {
                        neighbours.Add(grid[checkX, checkY]);
                    }
                }
            }
            return neighbours;
        }

        public Node NodeFromXY(int x, int y)
        {
            return grid[x, y];
        }
    }
}