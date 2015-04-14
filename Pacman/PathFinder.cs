//<Charles Lachance>
using System.Drawing;
namespace PathFinder
{
  public static class PathFinder
  {
    public static Direction FindShortestPath(PacmanGrid maze, Point from, Point to)
    {
      if (from.X < maze.GetWidth() && from.Y < maze.GetHeight() && from.X >= 0 && from.Y >= 0)
      {
        int[,] costs = new int[maze.GetWidth(), maze.GetHeight()];
        for (int i = 0; i < maze.GetWidth(); i++)
        {
          for (int j = 0; j < maze.GetHeight(); j++)
          {
            costs[i, j] = int.MaxValue;
          }
        }
        costs[from.X, from.Y] = 0;
        BuildPaths(maze, from, costs);
        return RecurseFindDirection(costs, from, to);
      }
      else
      {
        return Direction.Undefined;
      }
    }

    private static void BuildPaths(PacmanGrid maze, Point from, int[,] costs)
    {
      if (from.X + 1 < maze.GetWidth() && maze.GetMazeElementAt(from.X + 1, from.Y) != PacmanElement.Wall &&
      maze.GetMazeElementAt(from.X + 1, from.Y) != PacmanElement.Ghost && costs[from.X, from.Y] + 1 < costs[from.X + 1, from.Y])
      {
        costs[from.X + 1, from.Y] = costs[from.X, from.Y] + 1;
        BuildPaths(maze, new Point(from.X + 1, from.Y), costs);
      }

      if (from.X - 1 >= 0 && maze.GetMazeElementAt(from.X - 1, from.Y) != PacmanElement.Wall &&
      maze.GetMazeElementAt(from.X - 1, from.Y) != PacmanElement.Ghost && costs[from.X, from.Y] + 1 < costs[from.X - 1, from.Y])
      {
        costs[from.X - 1, from.Y] = costs[from.X, from.Y] + 1;
        BuildPaths(maze, new Point(from.X - 1, from.Y), costs);
      }

      if (from.Y + 1 < maze.GetHeight() && maze.GetMazeElementAt(from.X, from.Y + 1) != PacmanElement.Wall &&
      maze.GetMazeElementAt(from.X, from.Y + 1) != PacmanElement.Ghost && costs[from.X, from.Y] + 1 < costs[from.X, from.Y + 1])
      {
        costs[from.X, from.Y + 1] = costs[from.X, from.Y] + 1;
        BuildPaths(maze, new Point(from.X, from.Y + 1), costs);
      }

      if (from.Y - 1 >= 0 && maze.GetMazeElementAt(from.X, from.Y - 1) != PacmanElement.Wall &&
      maze.GetMazeElementAt(from.X, from.Y - 1) != PacmanElement.Ghost && costs[from.X, from.Y] + 1 < costs[from.X, from.Y - 1])
      {
        costs[from.X, from.Y - 1] = costs[from.X, from.Y] + 1;
        BuildPaths(maze, new Point(from.X, from.Y - 1), costs);
      }
    }
    //</Charles Lachance>

    //<Tommy Bouffard>
    /// <summary>
    /// Cette fonction essaie de déterminer la première direction que le fantôme doit prendre
    /// pour se rendre au pacman.
    /// </summary>
    /// <param name="costs">Tableau de distances</param>
    /// <param name="from">Position du fantôme</param>
    /// <param name="to">Position de la destination</param>
    /// <returns></returns>
    private static Direction RecurseFindDirection(int[,] costs, Point from, Point to)
    {
      if (costs[from.X, from.Y] == int.MaxValue)
      {
        return Direction.None;
      }
      else if (to.X < costs.GetLength(0) && to.Y < costs.GetLength(1) && to.X > 0 && to.Y > 0)
      {
        if (costs[to.X, to.Y] != 1)
        {
          if (costs[to.X, to.Y] > costs[to.X + 1, to.Y])
          {
            to.X = to.X + 1;
            return RecurseFindDirection(costs, from, to);
          }
          else if (costs[to.X, to.Y] > costs[to.X, to.Y + 1])
          {
            to.Y = to.Y + 1;
            return RecurseFindDirection(costs, from, to);
          }
          else if (costs[to.X, to.Y] > costs[to.X - 1, to.Y])
          {
            to.X = to.X - 1;
            return RecurseFindDirection(costs, from, to);
          }
          else if (costs[to.X, to.Y] > costs[to.X, to.Y - 1])
          {
            to.Y = to.Y - 1;
            return RecurseFindDirection(costs, from, to);
          }
        }
      }
      if (to.X == from.X + 1 && to.Y == from.Y)
      {
        return Direction.East;
      }
      else if (to.X == from.X && to.Y == from.Y + 1)
      {
        return Direction.South;
      }
      else if (to.X == from.X - 1 && to.Y == from.Y)
      {
        return Direction.West;
      }
      else if (to.X == from.X && to.Y == from.Y - 1)
      {
        return Direction.North;
      }
      return Direction.Undefined;
    }
  }
    //</Tommy Bouffard>
}

