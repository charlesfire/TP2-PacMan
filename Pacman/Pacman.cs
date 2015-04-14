//<Charles Lachance>
/*
 * Classe représentant le pacman contrôlé par le joueur
 * Créer par Charles Lachance
 */
using PathFinder;
namespace Pacman
{
  public class Pacman
  {
    //La position visuelle en x du pacman
    private float x = 0.0f;

    //La position visuelle en y du pacman
    private float y = 0.0f;

    //La direction vers laquelle le pacman regarde
    private Direction direction = Direction.None;

    //Si le pacman viens juste de rammasser une super pillule
    private bool hasSuperPill = false;

    /// <summary>
    /// Détermine si le pacman viens juste de ramasser une super pillule
    /// </summary>
    /// <returns>Retourne vrai si le pacman viens juste de ramasser une super pillule, retourne faux sinon</returns>
    public bool GetHasSuperPill()
    {
      return hasSuperPill;
    }

    /// <summary>
    /// Permet de changer si le pacman viens juste de ramasser une super pillule ou non
    /// </summary>
    /// <param name="hasSuperPill">Si le pacman viens juste de ramasser une super pillule</param>
    public void SetHasSuperPill(bool hasSuperPill)
    {
      this.hasSuperPill = hasSuperPill;
    }

    /// <summary>
    /// Obtient la position visuelle en x du pacman
    /// </summary>
    /// <returns>Retourne la position visuelle en x du pacman</returns>
    public float GetX()
    {
      return x;
    }

    /// <summary>
    /// Obtient la position visuelle en y du pacman
    /// </summary>
    /// <returns>Retourne la position visuelle en y du pacman</returns>
    public float GetY()
    {
      return y;
    }

    /// <summary>
    /// Obtient la direction vers laquelle le pacman regarde
    /// </summary>
    /// <returns>Retourne la direction vers laquelle le pacman regarde</returns>
    public Direction GetDirection()
    {
      return direction;
    }

    /// <summary>
    /// Modifie la position visuelle en x du pacman
    /// </summary>
    /// <param name="x">La nouvelle position en x du pacman</param>
    public void SetX(float x)
    {
      this.x = x;
    }

    /// <summary>
    /// Modifie la position visuelle en y du pacman
    /// </summary>
    /// <param name="y">La nouvelle position en y du pacman</param>
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
    
    /// <summary>
    /// Déplace le pacman dans une direction donnée si possible
    /// </summary>
    /// <param name="direction">La direction vers laquelle on souhaite déplacer le pacman</param>
    /// <param name="maze">Le niveau actuel du jeu</param>
    public void Move(Direction direction, PacmanGrid maze)
    {
      //Si la direction est une direction valide...
      if (direction != Direction.Undefined && direction != Direction.None)
      {
        //On calcule le déplacement du pacman
        int xMove = ((int)direction - 2) % 2;
        int yMove = ((int)direction - 3) % 2;

        //Si le pacman ne se dirige pas dans un mur ou une case non définie...
        if (maze.GetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH) + xMove, ((int)y / PacmanGame.ELEMENT_HEIGHT) + yMove) != PacmanElement.Undefined &&
                maze.GetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH) + xMove, ((int)y / PacmanGame.ELEMENT_HEIGHT) + yMove) != PacmanElement.Wall)
        {
          //On change la direction du pacman
          this.direction = direction;

          //On retire le pacman de sa position actuelle
          maze.SetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH), (int)y / PacmanGame.ELEMENT_HEIGHT, PacmanElement.None);

          //Si le pacman se déplace sur une pillule...
          if (maze.GetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH) + xMove, ((int)y / PacmanGame.ELEMENT_HEIGHT) + yMove) == PacmanElement.Pill)
          {
            //On diminue le nombre de pillule restante
            maze.ReducePillCount();
          }
          //Sinon si le pacman se déplace sur une super pillule
          else if (maze.GetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH) + xMove, ((int)y / PacmanGame.ELEMENT_HEIGHT) + yMove) == PacmanElement.SuperPill)
          {
            //On le marque comme venant juste de manger une super pillule
            hasSuperPill = true;

            //On diminue le nombre de pillule restante
            maze.ReducePillCount();
          }

          //On replace le pacman à sa nouvelle position
          maze.SetMazeElementAt(((int)x / PacmanGame.ELEMENT_WIDTH) + xMove, ((int)y / PacmanGame.ELEMENT_HEIGHT) + yMove, PacmanElement.Pacman);

          //On met à jour la position visuelle du pacman
          x += PacmanGame.ELEMENT_WIDTH * xMove;
          y += PacmanGame.ELEMENT_HEIGHT * yMove;
        }
      }
    }
  }
}
//</Charles Lachance>