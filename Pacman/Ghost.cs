using System.Drawing;
using PathFinder;
using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using Pacman.Properties;

namespace Pacman
{
  //<Tommy Bouffard>
  public class Ghost
  {
    //Position en X du fantôme
    private int xPosition = 0;
    //Position en Y du fantôme
    private int yPosition = 0;
    //État du fantôme (true si le pacman a une super pastille, faux si il n'en a pas).
    private static bool cowardState = false;
    //Nombre de fantômes
    private const int instancecount = 4;
    //Nombre de mise à jours
    private int nbUpdates = 0;
    //Nombre de mise à jours effectués avant un déplacement
    private int nbUpdatesBeforeMove = 5;
    //Vitesse du fantôme (nombre de cases)
    public int speed = 1;
    //x Initial du fantôme
    int initX = 0;
    //y initial du fantôme
    int initY = 0;


    /// <summary>
    /// Constructeur de ghost; initialise les composantes selon des valeurs données.
    /// </summary>
    /// <param name="gridX">Position en X reçue</param>
    /// <param name="gridY">Position en Y reçue</param>
    public Ghost(int gridX, int gridY)
    {
      xPosition = gridX;
      yPosition = gridY;
      cowardState = false;
      nbUpdates = 0;
      initX = gridX;
      initY = gridY;
    }

    /// <summary>
    /// Constructeur de ghost; Initialise les composantes.
    /// </summary>
    public Ghost()
    {
      cowardState = false;
      nbUpdates = 0;
    }
    /// <summary>
    /// Obtient la position en X du fantôme
    /// </summary>
    /// <returns>position en X du fantôme</returns>
    public int GetX()
    {
      return xPosition;
    }
    /// <summary>
    /// Obtient la position en Y du fantôme
    /// </summary>
    /// <returns>position en Y du fantôme</returns>
    public int GetY()
    {
      return yPosition;
    }
    /// <summary>
    /// Modifie la position en X selon un paramêtre reçu
    /// </summary>
    /// <param name="recievedX">entier reçu</param>
    public void SetX(int recievedX)
    {
      xPosition = recievedX;
    }
    /// <summary>
    /// Modifie la position en Y selon un paramêtre reçu
    /// </summary>
    /// <param name="recievedY">entier reçu</param>
    public void SetY(int recievedY)
    {
      yPosition = recievedY;
    }
    /// <summary>
    /// Déplace le fantôme dans la grille du jeu selon le paramêtre reçu
    /// </summary>
    /// <param name="direction">direction du fantôme</param>
    /// <param name="aMaze">Grille du jeu</param>
    public void Move(Direction direction, PacmanGrid aMaze)
    {
      aMaze.SetMazeElementAt(xPosition, yPosition, PacmanElement.None);
      if (direction == Direction.East)
      {
        xPosition++;
      }
      else if (direction == Direction.West)
      {
        xPosition--;
      }
      else if (direction == Direction.North)
      {
        yPosition--;
      }
      else if (direction == Direction.South)
      {
        yPosition++;
      }

      aMaze.SetMazeElementAt(xPosition,yPosition, PacmanElement.Ghost);
    }
    /// <summary>
    /// Met à jour le fantôme selon la position du pacman
    /// </summary>
    /// <param name="aMaze">Grille du jeu</param>
    /// <param name="pacman">Instance du pacman</param>
    public void Update(PacmanGrid aMaze,Pacman pacman)
    {
      nbUpdates++;
      if (nbUpdates % nbUpdatesBeforeMove == 0)
      {
        Point ghostPoint = new Point(xPosition, yPosition);
        Point pacPoint = new Point((int)(pacman.GetX()/20f), (int)(pacman.GetY()/20f));
        if (cowardState == true)
        {
          Move(PathFinder.PathFinder.FindShortestPath(aMaze,ghostPoint, new Point(initX,initY)),aMaze);
        }
        else
        {
          Move(PathFinder.PathFinder.FindShortestPath(aMaze, ghostPoint, pacPoint), aMaze);
        }
      }
    }
    /// <summary>
    /// Cette fonction change l'état du fantôme
    /// </summary>
    /// <param name="coward">État peureux du fantôme</param>
    public static void GhostChangeState(bool coward)
    {
      cowardState = coward;
    }
    
    public void Draw(Graphics g, int ELEMENT_WIDTH, int ELEMENT_HEIGHT)
    {
      if (GetState() == false)
      {
        g.DrawImage(Resources.Ghost,
                              xPosition * ELEMENT_WIDTH,
                              yPosition * ELEMENT_HEIGHT,
                              ELEMENT_WIDTH,
                              ELEMENT_HEIGHT);
      }
      else
      {
        g.DrawImage(Resources.GhostWeak,
                              xPosition * ELEMENT_WIDTH,
                              yPosition * ELEMENT_HEIGHT,
                              ELEMENT_WIDTH,
                              ELEMENT_HEIGHT);
      }
    }

    public static bool GetState()
    {
      return cowardState;
    }
  }
}
  //</Tommy Bouffard>
