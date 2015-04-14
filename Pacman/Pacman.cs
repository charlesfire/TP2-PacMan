//<Charles Lachance>
using PathFinder;
namespace Pacman
{
  public class Pacman
  {
    private float x = 0.0f;
    private float y = 0.0f;
    private Direction direction = Direction.None;
    private bool hasSuperPill = false;

    public bool GetHasSuperPill()
    {
      return hasSuperPill;
    }

    public void SetHasSuperPill(bool hasSuperPill)
    {
      this.hasSuperPill = hasSuperPill;
    }

    public float GetX()
    {
      return x;
    }

    public float GetY()
    {
      return y;
    }

    public Direction GetDirection()
    {
      return direction;
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
      x = 0.0f;
      y = 0.0f;
      direction = Direction.East;
      hasSuperPill = false;
    }

    public void Move(Direction direction, PacmanGrid maze)
    {
      this.direction = direction;

      if (direction != Direction.Undefined && direction != Direction.None)
      {
        int xMove = ((int)direction - 2) % 2;
        int yMove = ((int)direction - 3) % 2;
        if (maze.GetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH) + xMove, ((int)y / PacmanGame.ELEMENT_HEIGHT) + yMove) != PacmanElement.Undefined &&
                maze.GetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH) + xMove, ((int)y / PacmanGame.ELEMENT_HEIGHT) + yMove) != PacmanElement.Wall)
        {
          maze.SetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH), (int)y / PacmanGame.ELEMENT_HEIGHT, PacmanElement.None);
          if (maze.GetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH) + xMove, ((int)y / PacmanGame.ELEMENT_HEIGHT) + yMove) == PacmanElement.Pill)
          {
            maze.ReducePillCount();
          }
          else if (maze.GetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH) + xMove, ((int)y / PacmanGame.ELEMENT_HEIGHT) + yMove) == PacmanElement.SuperPill)
          {
            hasSuperPill = true;
            maze.ReducePillCount();
          }

          maze.SetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH) + xMove, ((int)y / PacmanGame.ELEMENT_HEIGHT) + yMove, PacmanElement.Pacman);
          x += PacmanGame.ELEMENT_WIDTH * xMove;
          y += PacmanGame.ELEMENT_HEIGHT * yMove;
        }
      }
    }
  }
}
//</Charles Lachance>