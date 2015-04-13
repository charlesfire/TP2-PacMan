//<Charles Lachance>
using PathFinder;
namespace Pacman
{
  public class Pacman
  {
    private float speed = 20f;
    private float x = 0.0f;
    private float y = 0.0f;
    private Direction direction = Direction.None;

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
      speed = 20;
      x = 0.0f;
      y = 0.0f;
      direction = Direction.East;
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
          maze.SetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH) + xMove, ((int)y / PacmanGame.ELEMENT_HEIGHT) + yMove, PacmanElement.Pacman);
          x += 20 * xMove;
          y += 20 * yMove;
        }
      }
    }
  }
}
//</Charles Lachance>