
namespace Pathfinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathfinding = new Pathfinding(30, 30);
            Vector seeker = new Vector(2, 2);
            Vector target = new Vector(2, 28);

            var distance = seeker.Distance(target);

            pathfinding.FindPath(seeker, target);
            var path = pathfinding.GetPath();
            return;
        }
    }
}
