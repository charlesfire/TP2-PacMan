//<Charles Lachance>
using System.Drawing;
namespace PathFinder
{
  public static class PathFinder
  {
    public static void FindShortestPath(PacmanGrid maze, Point from, Point to)
    {
      if (from.X < maze.GetWidth() && from.Y < maze.GetHeight() && from.X >= 0 && from.Y >= 0)
      {
        int[,] costs = new int[maze.GetWidth(), maze.GetHeight()];
        for (int i = 0; i < maze.GetWidth(); i++)
        {
          for (int j = 0; j < maze.GetHeight(); j++)
          {
            costs[i,j] = int.MaxValue;
          }
        }

        costs[from.X, from.Y] = 0;
        BuildPaths(maze, from, costs);
      }
    }

    private static void BuildPaths(PacmanGrid maze, Point from, int[,] costs)
    {
      if (from.X + 1 < maze.GetWidth() && maze.GetMazeElementAt(from.X + 1, from.Y) != PacmanElement.Wall && costs[from.X, from.Y] + 1 < costs[from.X + 1, from.Y])
      {
        costs[from.X + 1, from.Y] = costs[from.X, from.Y] + 1;
        BuildPaths(maze, new Point(from.X + 1, from.Y), costs);
      }

      if (from.X - 1 >= 0 && maze.GetMazeElementAt(from.X - 1, from.Y) != PacmanElement.Wall && costs[from.X, from.Y] + 1 < costs[from.X - 1, from.Y])
      {
        costs[from.X - 1, from.Y] = costs[from.X, from.Y] + 1;
        BuildPaths(maze, new Point(from.X - 1, from.Y), costs);
      }

      if (from.Y + 1 < maze.GetHeight() && maze.GetMazeElementAt(from.X, from.Y + 1) != PacmanElement.Wall && costs[from.X, from.Y] + 1 < costs[from.X, from.Y + 1])
      {
        costs[from.X, from.Y + 1] = costs[from.X, from.Y] + 1;
        BuildPaths(maze, new Point(from.X, from.Y + 1), costs);
      }

      if (from.Y - 1 >= 0 && maze.GetMazeElementAt(from.X, from.Y - 1) != PacmanElement.Wall && costs[from.X, from.Y] + 1 < costs[from.X, from.Y - 1])
      {
        costs[from.X, from.Y - 1] = costs[from.X, from.Y] + 1;
        BuildPaths(maze, new Point(from.X, from.Y - 1), costs);
      }
    }
  }
}
//</Charles Lachance>