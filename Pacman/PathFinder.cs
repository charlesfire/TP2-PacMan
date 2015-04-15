//<Charles Lachance>
/*
 * Classe statique contenant les fonctions nécessaires pour la recherche de chemin des fantômes
 * Créer par Charles Lachance
 */
using System.Drawing;
namespace PathFinder
{
  public static class PathFinder
  {
    /// <summary>
    /// Trouve le chemin le plus court entre le point "from" et le point "to" situé sur la grille
    /// de jeu "maze" en considérent les obstacles
    /// </summary>
    /// <param name="maze">Le niveau actuel du jeu Pacman</param>
    /// <param name="from">Le point à partir du quel on souhaite trouver un chemin</param>
    /// <param name="to">Le point que l'on souhaite atteindre</param>
    /// <returns>Retourne la direction vers laquelle on doit se diriger pour atteindre le point "to"
    ///           en utilisant le chemin le plus court ou Direction.Undefined dans le cas où aucun chemin
    ///           existe entre les point "to" et "from"
    /// </returns>
    public static Direction FindShortestPath(PacmanGrid maze, Point from, Point to)
    {
      //Si le point "from" est valide (dans le range du tableau)...
      if (from.X < maze.GetWidth() && from.Y < maze.GetHeight() && from.X >= 0 && from.Y >= 0)
      {
        //On crée un tableau représentant les distances pour se rendre à chaque point du niveau
        int[,] costs = new int[maze.GetWidth(), maze.GetHeight()];

        //Pour chaque colonne du tableau...
        for (int i = 0; i < maze.GetWidth(); i++)
        {
          //Pour chaque ligne du tableau...
          for (int j = 0; j < maze.GetHeight(); j++)
          {
            //On initialise la distance pour se rendre à ce point à une valeur très grande
            costs[i, j] = int.MaxValue;
          }
        }

        //On initialise le point de départ avec une distance de 0
        costs[from.X, from.Y] = 0;

        //On construit le tableau des distances
        BuildPaths(maze, from, costs);

        //On trouve la prochaine direction à emprunter pour atteindre le point "to"
        return RecurseFindDirection(costs, from, to);
      }
      else
      {
        return Direction.Undefined;
      }
    }

    /// <summary>
    /// Construit un tableau des distances minimales à parcourir pour atteindre une case 
    /// quelconque du niveau à partir de la case situé au point "from".
    /// Prend en compte les obstacles.
    /// </summary>
    /// <param name="maze">Le niveau dans lequel on cherche la liste des distances</param>
    /// <param name="from">Le point à partir du quel on doit calculer les distances</param>
    /// <param name="costs">Le tableau des distances</param>
    public static void BuildPaths(PacmanGrid maze, Point from, int[,] costs)
    { 
      //Si la case à droite de la case actuelle fait partie du tableau et que cette case n'est pas un obstacle et que
      //  l'on a pas déjà trouvé de chemin plus court pour atteindre cette case...
      if (from.X + 1 < maze.GetWidth() && maze.GetMazeElementAt(from.X + 1, from.Y) != PacmanElement.Wall &&
      maze.GetMazeElementAt(from.X + 1, from.Y) != PacmanElement.Ghost && costs[from.X, from.Y] + 1 < costs[from.X + 1, from.Y])
      {
        //On met à jour la distance minimal à parcourir pour atteindre cette case
        costs[from.X + 1, from.Y] = costs[from.X, from.Y] + 1;

        //On continue la recherche à partir de cette case
        BuildPaths(maze, new Point(from.X + 1, from.Y), costs);
      }

      //Si la case à gauche de la case actuelle fait partie du tableau et que cette case n'est pas un obstacle et que
      //  l'on a pas déjà trouvé de chemin plus court pour atteindre cette case...
      if (from.X - 1 >= 0 && maze.GetMazeElementAt(from.X - 1, from.Y) != PacmanElement.Wall &&
      maze.GetMazeElementAt(from.X - 1, from.Y) != PacmanElement.Ghost && costs[from.X, from.Y] + 1 < costs[from.X - 1, from.Y])
      {
        //On met à jour la distance minimal à parcourir pour atteindre cette case
        costs[from.X - 1, from.Y] = costs[from.X, from.Y] + 1;

        //On continue la recherche à partir de cette case
        BuildPaths(maze, new Point(from.X - 1, from.Y), costs);
      }

      //Si la case en bas de la case actuelle fait partie du tableau et que cette case n'est pas un obstacle et que
      //  l'on a pas déjà trouvé de chemin plus court pour atteindre cette case...
      if (from.Y + 1 < maze.GetHeight() && maze.GetMazeElementAt(from.X, from.Y + 1) != PacmanElement.Wall &&
      maze.GetMazeElementAt(from.X, from.Y + 1) != PacmanElement.Ghost && costs[from.X, from.Y] + 1 < costs[from.X, from.Y + 1])
      {
        //On met à jour la distance minimal à parcourir pour atteindre cette case
        costs[from.X, from.Y + 1] = costs[from.X, from.Y] + 1;

        //On continue la recherche à partir de cette case
        BuildPaths(maze, new Point(from.X, from.Y + 1), costs);
      }

      //Si la case en haut de la case actuelle fait partie du tableau et que cette case n'est pas un obstacle et que
      //  l'on a pas déjà trouvé de chemin plus court pour atteindre cette case...
      if (from.Y - 1 >= 0 && maze.GetMazeElementAt(from.X, from.Y - 1) != PacmanElement.Wall &&
      maze.GetMazeElementAt(from.X, from.Y - 1) != PacmanElement.Ghost && costs[from.X, from.Y] + 1 < costs[from.X, from.Y - 1])
      {
        //On met à jour la distance minimal à parcourir pour atteindre cette case
        costs[from.X, from.Y - 1] = costs[from.X, from.Y] + 1;

        //On continue la recherche à partir de cette case
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
    /// <returns>La première direction qui mène au chemin le plus court</returns>

    //Je n'ai pas le choix de mettre la fonction public pour faire les tests unitaires.

    public static Direction RecurseFindDirection(int[,] costs, Point from, Point to)
    {
      //Condition de fin: Il n'existe pas de chemin possible dans ce cas.
      if (costs[from.X, from.Y] == int.MaxValue)
      {
        return Direction.None;
      }
      else if (to.X < costs.GetLength(0) && to.Y < costs.GetLength(1) && to.X >= 0 && to.Y >= 0)
      {
        //Condition de fin: le fantôme est adjacent au pacman
        if (costs[to.X, to.Y] != 1)
        {
          //(Pour les 4 cas) Si la distance est plus petite lorsqu'on change de case, on rappèle la fonction en cette case.
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
      //Il faut trouver la bonne case adjacente.
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
      //Condition de fin selement pour que le code compile.
      return Direction.Undefined;
    }
  }
    //</Tommy Bouffard>
}

