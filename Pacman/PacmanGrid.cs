//<Charles Lachance>
using System.Linq;

namespace PathFinder
{
  public class PacmanGrid
  {
    private PacmanElement[,] mazeElements = null;
    private int mazeWidth = 0;
    private int mazeHeight = 0;

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
            mazeElements[i, j] = (PacmanElement)element;
          }
        }
      }
    }

    public PacmanGrid()
    {
      mazeElements = null;
      mazeWidth = 0;
      mazeHeight = 0;
    }
  }
}
//</Charles Lachance>