using System;
using System.Collections.Generic;
using System.Threading;

namespace DSA.Maze
{
    class AsciiMaze
    {
        public static void Run(){
            Maze maze = new Maze(11, 7);
            maze.Generate();
            maze.Print();

            Console.WriteLine("\n(S = Start, E = Exit, # = Wall, ' ' = Path)");
            Console.WriteLine(@"Students: implement DepthFirstSearchSolver.Solve() to find a path!");

            DepthFirstSearchSolver solver = new DepthFirstSearchSolver();
            var path = solver.Solve(maze);

            if (path == null || path.Count == 0)
            {
                Console.WriteLine("No path found (or DFS not implemented yet).");
            }
            else
            {
                Console.WriteLine($"Path found! Length = {path.Count}\n");
                TracePath(maze, path);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        private static void TracePath(Maze maze, List<Node> path)
        {
            foreach (var node in path)
            {
                if (node != maze.Start && node != maze.Exit)
                    node.DisplayChar = '*';

                maze.Print();
                Thread.Sleep(50);
            }

            Console.WriteLine("\nReached the exit!"); 
        }
    }

    // ------------------------------------------------------------
    // MAZE STRUCTURE
    // ------------------------------------------------------------

    class Node
    {
        public int X, Y;
        public Node Up, Down, Left, Right;
        public char DisplayChar = ' ';

        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }

        public IEnumerable<Node> Neighbors()
        {
            if (Up != null) yield return Up;
            if (Down != null) yield return Down;
            if (Left != null) yield return Left;
            if (Right != null) yield return Right;
        }
    }

    class Maze
    {
        public Node[,] Grid { get; private set; }
        public Node Start { get; private set; }
        public Node Exit { get; private set; }

        private int width, height;
        private Random rand = new Random();

        public Maze(int width, int height)
        {
            this.width = width;
            this.height = height;

            Grid = new Node[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Grid[y, x] = new Node(x, y);
                }
            }
        }

        public void Generate()
        {
            Start = Grid[0, 0];
            Exit = Grid[height - 1, width - 1];

            HashSet<Node> visited = new HashSet<Node>();
            Carve(Start, visited);

            Start.DisplayChar = 'S';
            Exit.DisplayChar = 'E';
        }

        private void Carve(Node node, HashSet<Node> visited)
        {
            visited.Add(node);

            foreach (var next in ShuffledNeighbors(node))
            {
                if (!visited.Contains(next))
                {
                    Link(node, next);
                    Carve(next, visited);
                }
            }
        }

        private List<Node> ShuffledNeighbors(Node node)
        {
            var dirs = new List<(int dx, int dy)>
            {
                (1, 0), (-1, 0),
                (0, 1), (0, -1)
            };

            for (int i = dirs.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                (dirs[i], dirs[j]) = (dirs[j], dirs[i]);
            }

            List<Node> result = new List<Node>();

            foreach (var (dx, dy) in dirs)
            {
                int nx = node.X + dx;
                int ny = node.Y + dy;

                if (nx >= 0 && ny >= 0 && nx < width && ny < height)
                    result.Add(Grid[ny, nx]);
            }

            return result;
        }

        private void Link(Node a, Node b)
        {
            if (a.X == b.X)
            {
                if (a.Y < b.Y)
                {
                    a.Down = b;
                    b.Up = a;
                }
                else
                {
                    a.Up = b;
                    b.Down = a;
                }
            }
            else if (a.Y == b.Y)
            {
                if (a.X < b.X)
                {
                    a.Right = b;
                    b.Left = a;
                }
                else
                {
                    a.Left = b;
                    b.Right = a;
                }
            }
        }

        public void Print()
        {
            Console.Clear();

            int displayHeight = height * 2 + 1;
            int displayWidth = width * 2 + 1;

            char[,] output = new char[displayHeight, displayWidth];

            // Fill with walls
            for (int y = 0; y < displayHeight; y++)
            {
                for (int x = 0; x < displayWidth; x++)
                {
                    output[y, x] = '#';
                }
            }

            // Carve maze paths
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int cx = x * 2 + 1;
                    int cy = y * 2 + 1;

                    Node node = Grid[y, x];
                    output[cy, cx] = node.DisplayChar;

                    if (node.Right != null)
                        output[cy, cx + 1] = ' ';

                    if (node.Down != null)
                        output[cy + 1, cx] = ' ';
                }
            }

            // Print
            for (int y = 0; y < displayHeight; y++)
            {
                for (int x = 0; x < displayWidth; x++)
                {
                    Console.Write(output[y, x]);
                }
                Console.WriteLine();
            }
        }
    }

    // ------------------------------------------------------------
    // STUDENT ASSIGNMENT SECTION
    // ------------------------------------------------------------

    class DepthFirstSearchSolver
    {
        public List<Node> Solve(Maze maze)
        {
            Stack<Node> stack = new Stack<Node>();
            Dictionary<Node, Node> parent = new Dictionary<Node, Node>();
            HashSet<Node> visited = new HashSet<Node>();

            stack.Push(maze.Start);
            visited.Add(maze.Start);

            while (stack.Count > 0)
            {
                Node current = stack.Pop();

                if (current == maze.Exit)
                {
                    return ReconstructPath(parent, maze.Start, maze.Exit);
                }

                foreach (var neighbor in current.Neighbors())
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        parent[neighbor] = current;
                        stack.Push(neighbor);
                    }
                }
            }

            return new List<Node>();
        }

        private List<Node> ReconstructPath(Dictionary<Node, Node> parent, Node start, Node end)
        {
            List<Node> path = new List<Node>();
            var current = end;

            while (current != start)
            {
                path.Add(current);
                current = parent[current];
            }

            path.Add(start);
            path.Reverse();

            return path;
        }
    }
}
