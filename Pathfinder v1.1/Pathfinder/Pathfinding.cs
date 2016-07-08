namespace Pathfinder
{
    using System;
    using System.Collections.Generic;

    public class Pathfinding
    {       
        private Grid _grid;

        public Pathfinding(int sizeX, int sizeY)
        {
            this._grid = new Grid(sizeX, sizeY);
        }

        public List<Node> GetPath()
        {
            return this._grid.path;
        }

        public void FindPath(Vector startPosition, Vector targetPosition)
        {
            Node startNode = this._grid.NodeFromXY(startPosition.x, startPosition.y);
            Node targetNode = this._grid.NodeFromXY(targetPosition.x, targetPosition.y);

            var openSet = new Heap<Node>(_grid.MaxSize);
            var closedSet = new HashSet<Node>();
            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                Node currentNode = openSet.RemoveFirst();

                closedSet.Add(currentNode);

                if (currentNode == targetNode)
                {
                    this.RetracePath(startNode, targetNode);
                    return;
                }

                foreach (Node neighbour in this._grid.GetNeighbours(currentNode))
                {
                    if (!neighbour.walkable || closedSet.Contains(neighbour))
                    {
                        continue;
                    }

                    int newMovementCostToNeighbour = currentNode.gCost + this.GetDistance(currentNode, neighbour);

                    if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        neighbour.gCost = newMovementCostToNeighbour;
                        neighbour.hCost = this.GetDistance(neighbour, targetNode);
                        neighbour.parent = currentNode;

                        if (!openSet.Contains(neighbour))
                        {
                            openSet.Add(neighbour);
                        }
                    }
                }
            }
        }

        private void RetracePath(Node startNode, Node endNode)
        {
            var path = new List<Node>();
            var currentNode = endNode;

            while (currentNode != startNode)
            {
                path.Add(currentNode);
                currentNode = currentNode.parent;
            }
            path.Reverse();

            this._grid.path = path;

        }

        private int GetDistance(Node nodeA, Node nodeB)
        {
            var dstX = Math.Abs(nodeA.gridX - nodeB.gridX);
            var dstY = Math.Abs(nodeA.gridY - nodeB.gridY);

            if (dstX > dstY)
            {
                return 14 * dstY + 10 * (dstX - dstY);
            }
            return 14 * dstX + 10 * (dstY - dstX);
        }
    }
}
