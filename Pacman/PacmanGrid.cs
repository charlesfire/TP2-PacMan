//<Charles Lachance>
/*
 * Classe représentant un niveau du jeu Pacman
 * Créer par Charles Lachance
 */
using System.Linq;

namespace PathFinder
{
  public class PacmanGrid
  {
    //Tableau représentant l'ensemble des éléments du jeu
    private PacmanElement[,] mazeElements = null;

    //Taille horizontale du jeu (nombre d'éléments sur une ligne)
    private int mazeWidth = 0;

    //Taille verticale du jeu (nombre d'éléments sur une colonne)
    private int mazeHeight = 0;
    //<Tommy Bouffard>
    //Nombre de pillules dans la partie
    private int pillCount = 0;
    //</Tommy Bouffard>

    /// <summary>
    /// Obtient la taille verticale du jeu (nombre d'éléments sur une colonne)
    /// </summary>
    /// <returns>Retourne la taille verticale du jeu (nombre d'éléments sur une colonne)</returns>
    public int GetHeight()
    {
      return mazeHeight;
    }

    /// <summary>
    /// Obtient la taille horizontale du jeu (nombre d'éléments sur une ligne)
    /// </summary>
    /// <returns>Retourne la taille horizontale du jeu (nombre d'éléments sur une ligne)</returns>
    public int GetWidth()
    {
      return mazeWidth;
    }

    /// <summary>
    /// Obtient l'élément du jeu situé à la position (col, row)
    /// </summary>
    /// <param name="col">La colonne sur laquelle se situe l'élément que l'on souhaite récupérer</param>
    /// <param name="row">La ligne sur laquelle se situe l'élément que l'on souhaite récupérer</param>
    /// <returns>Retourne l'élément du jeu situé à la position (col, row) ou PacmanElement.Undefined
    ///             lorsque la position spécifié est en dehors du tableau
    /// </returns>
    public PacmanElement GetMazeElementAt(int col, int row)
    {
      //Si la position est valide...
      if (row < mazeHeight && col < mazeWidth && row >= 0 && col >= 0)
      {
        return mazeElements[row, col];
      }

      return PacmanElement.Undefined;
    }

    /// <summary>
    /// Change l'élément du jeu situé à la position (col, row) pour l'élément "element"
    /// </summary>
    /// <param name="col">La colonne sur laquelle se situe l'élément que l'on souhaite changer</param>
    /// <param name="row">La ligne sur laquelle se situe l'élément que l'on souhaite changer</param>
    /// <param name="element">Le nouvel élément que l'on souhaite mettre à la position (col, row)</param>
    public void SetMazeElementAt(int col, int row, PacmanElement element)
    {
      //Si la position est valide...
      if (row < mazeHeight && col < mazeWidth && row >= 0 && col >= 0)
      {
        //On change l'élément à la position (col, row)
        mazeElements[row, col] = element;
      }
    }

    /// <summary>
    /// Initialise le tableau du jeu avec une version sous forme de chaine de caractère
    /// </summary>
    /// <param name="mazeDescription">La description du niveau sous forme de chaine de caractère</param>
    public void InitFrom(string mazeDescription)
    {
      //On récuppère chaque ligne du niveau
      string[] mazeRow = mazeDescription.Split(';');

      //Si le niveau a au moins une ligne...
      if (mazeRow.Count() > 0)
      {
        //On met à jour les dimensions du niveau
        mazeHeight = mazeRow.Count() - 1;
        mazeWidth = mazeRow[0].Split(',').Count();
        mazeElements = new PacmanElement[mazeHeight, mazeWidth];

        //Pour chaque ligne du niveau...
        for (int i = 0; i < mazeHeight; i++)
        {
          //On récupère les cases de la ligne "i"
          string[] elements = mazeRow[i].Split(',');

          //Pour chaque case de la ligne "i"...
          for (int j = 0; j < mazeWidth; j++)
          {
            //On crée un élément par défaut
            int element = 7; //PacmanElement.Undefined

            //On essaie de récuppérer l'élément allant à la position (i,j)
            int.TryParse(elements[j], out element);

            //Si l'élément est une valeur non définie...
            if (element >= 7)
            {
              //On lance une exception
              throw new Pacman.InvalidLevelFormatException("Format de niveau non valide.");
            }

            //On met à jour le tableau du jeu
            mazeElements[i, j] = (PacmanElement)element;

            //<Tommy Bouffard>
            if (element == 4 || element == 6)
            {
              pillCount++;
            }
            //</Tommy Bouffard>
          }
        }
      }
    }
    //<Tommy Bouffard>

    /// <summary>
    /// Obtient la valeur du nombre de points restants.
    /// </summary>
    /// <returns>nombre de points restants</returns>
    public int GetPillCount()
    {
      return pillCount;
    }
    /// <summary>
    /// Change la valeur du nombre de points restants selon une valeur reçue
    /// </summary>
    /// <param name="recievedPillCount">Nouveau nombre de points restants</param>
    public void SetPillCount(int recievedPillCount)
    {
      pillCount = recievedPillCount;
    }
    /// <summary>
    /// Réduis le nombre de points de 1.
    /// </summary>
    public void ReducePillCount()
    {
      pillCount--;
    }
    //</Tommy Bouffard>

    public PacmanGrid()
    {
      mazeElements = null;
      mazeWidth = 0;
      mazeHeight = 0;
      pillCount = 0;
    }
  }
}
//</Charles Lachance>