//<Charles Lachance>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinder
{
  class PacmanGrid
  {
    private PacmanElement[,] mazeElements = null;
    private uint mazeWidth = 0;
    private uint mazeHeight = 0;

    public uint GetHeight()
    {
      return mazeHeight;
    }

    public uint GetWidth()
    {
      return mazeWidth;
    }

    public PacmanElement GetMazeElementAt(uint row, uint col)
    {
      if (row < mazeHeight && col < mazeWidth)
      {
        return mazeElements[row, col];
      }

      return PacmanElement.Undefined;
    }

    public void SetMazeElementAt(uint row, uint col, PacmanElement element)
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
        mazeElements = new PacmanElement[mazeRow.Count(), (mazeRow[0].Length/2 + 1)];
        for (int i = 0; i < mazeRow.Count(); i++)
        {
          string[] elements = mazeRow[i].Split(',');
          for (int j = 0; j < elements.Count(); j++)
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