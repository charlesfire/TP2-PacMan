
using PathFinder;
namespace Pacman
{
  public class Pacman
  {
    private float speed = 20f;
    private float x = 0.0f;
    private float y = 0.0f;

    public float GetX()
    {
      return x;
    }

    public float GetY()
    {
      return y;
    }

    public void SetX(float x)
    {
      this.x = x;
    }

    public void SetY(float y)
    {
      this.y = y;
    }

    public Pacman()
    {
      speed = 20;
      x = 0.0f;
      y = 0.0f;
    }

    public void Move(Direction direction, PacmanGrid maze)
    {
      switch(direction)
      {
        case Direction.East:
          if (maze.GetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH) + 1, (int)y / PacmanGame.ELEMENT_HEIGHT) != PacmanElement.Undefined &&
              maze.GetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH) + 1, (int)y / PacmanGame.ELEMENT_HEIGHT) != PacmanElement.Wall)
          {
            maze.SetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH) + 1, (int)y / PacmanGame.ELEMENT_HEIGHT, PacmanElement.Pacman);
            x += 20;
          }
          break;
        case Direction.North:
          if (maze.GetMazeElementAt((int)x / PacmanGame.ELEMENT_WIDTH, ((int)y / PacmanGame.ELEMENT_HEIGHT) - 1) != PacmanElement.Undefined &&
              maze.GetMazeElementAt((int)x / PacmanGame.ELEMENT_WIDTH, ((int)y / PacmanGame.ELEMENT_HEIGHT) - 1) != PacmanElement.Wall)
          {
            maze.SetMazeElementAt((int)x / PacmanGame.ELEMENT_WIDTH, ((int)y / PacmanGame.ELEMENT_HEIGHT) - 1, PacmanElement.Pacman);
            y -= 20;
          }
          break;
        case Direction.West:
          if (maze.GetMazeElementAt((int)x / PacmanGame.ELEMENT_WIDTH, ((int)y / PacmanGame.ELEMENT_HEIGHT) + 1) != PacmanElement.Undefined &&
              maze.GetMazeElementAt((int)x / PacmanGame.ELEMENT_WIDTH, ((int)y / PacmanGame.ELEMENT_HEIGHT) + 1) != PacmanElement.Wall)
          {
            maze.SetMazeElementAt((int)x / PacmanGame.ELEMENT_WIDTH, ((int)y / PacmanGame.ELEMENT_HEIGHT) + 1, PacmanElement.Pacman);
            y += 20;
          }
          break;
        case Direction.South:
          if (maze.GetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH) - 1, (int)y / PacmanGame.ELEMENT_HEIGHT) != PacmanElement.Undefined &&
              maze.GetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH) - 1, (int)y / PacmanGame.ELEMENT_HEIGHT) != PacmanElement.Wall)
          {
            maze.SetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH) - 1, (int)y / PacmanGame.ELEMENT_HEIGHT, PacmanElement.Pacman);
            x -= 20;
          }
          break;
        default:
          break;
      }
    }
  }
}
