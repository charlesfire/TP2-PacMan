//<Charles Lachance>
using System.Linq;

namespace PathFinder
{
  public class PacmanGrid
  {
    private PacmanElement[,] mazeElements = null;
    private int mazeWidth = 0;
    private int mazeHeight = 0;
    //<Tommy Bouffard>
    //Nombre de points dans la partie
    private int pillCount = 0;
    //</Tommy Bouffard>
    public int GetHeight()
    {
      return mazeHeight;
    }

    public int GetWidth()
    {
      return mazeWidth;
    }

    public PacmanElement GetMazeElementAt(int col, int row)
    {
      if (row < mazeHeight && col < mazeWidth)
      {
        return mazeElements[row, col];
      }

      return PacmanElement.Undefined;
    }

    public void SetMazeElementAt(int col, int row, PacmanElement element)
    {
      if (row < mazeHeight && col < mazeWidth)
      {
        mazeElements[row, col] = element;
      }
    }

    public void InitFrom(string mazeDescription)
    {
      string[] mazeRow = mazeDescription.Split(';');
      if (mazeRow.Count() > 0)
      {
        mazeHeight = mazeRow.Count() - 1;
        mazeWidth = mazeRow[0].Split(',').Count();
        mazeElements = new PacmanElement[mazeHeight, mazeWidth];
        for (int i = 0; i < mazeHeight; i++)
        {
          string[] elements = mazeRow[i].Split(',');
          for (int j = 0; j < mazeWidth; j++)
          {
            int element = 7;
            int.TryParse(elements[j], out element);
            if (element >= 7)
            {
              throw new Pacman.InvalidLevelFormatException("Format de niveau non valide.");
            }

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