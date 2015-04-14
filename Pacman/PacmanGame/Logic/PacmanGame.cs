using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using Pacman.Properties;
using PathFinder;

namespace Pacman
{
  public class PacmanGame
  {
    //<Tommy Bouffard>
    //Hauteur du formulaire du jeu
    public const int ELEMENT_HEIGHT = 20;

    //Largeur du formulaire du jeu
    public const int ELEMENT_WIDTH = 20;

    //Pacman du jeu
    private Pacman pacman = null;

    //Nombre de fantômes dans le jeu
    private const int NB_GHOSTS = 4;

    //Tableau des fantômes dans le jeu
    private Ghost[] ghosts = new Ghost[NB_GHOSTS];
    //</Tommy Bouffard>

    //<Charles Lachance>

    private PacmanGrid grid = null;

    /// <summary>
    /// Constructeur du jeu de Pacman
    /// </summary>
    public PacmanGame()
    {
      pacman = new Pacman();
      ghosts = new Ghost[NB_GHOSTS];
      grid = new PacmanGrid();
    }

    // Vous aurez probablement à modifier le type de retour ici pour pouvoir
    // tester la fin de partie.  Par contre, pour vous donner un projet qui
    // compile, je n'avais pas le choix de mettre "void".
    public EndGameResult Update()
    {
      foreach (Ghost ghost in ghosts)
      {
        if (ghost != null)
        {
          ghost.Update(grid, pacman);
          if (ghost.GetX() == (int)pacman.GetX()/20f && ghost.GetY() == (int)pacman.GetY()/20f)
          {
            return EndGameResult.Loose;
          }
        }
      }

      if (Keyboard.IsKeyDown(Key.Right))
      {
        pacman.Move(Direction.East, grid);
      }
      else if (Keyboard.IsKeyDown(Key.Up))
      {
        pacman.Move(Direction.North, grid);
      }
      else if (Keyboard.IsKeyDown(Key.Left))
      {
        pacman.Move(Direction.West, grid);
      }
      else if (Keyboard.IsKeyDown(Key.Down))
      {
        pacman.Move(Direction.South, grid);
      }

      if (grid.GetPillCount() == 0)
      {
        return EndGameResult.Win;
      }
      
      return EndGameResult.NotFinished;
    }

    public void Draw(Graphics g)
    {
      for (int i = 0; i < grid.GetWidth(); i++)
      {
        for (int j = 0; j < grid.GetHeight(); j++)
        {
          switch (grid.GetMazeElementAt(i, j))
          {
            case PacmanElement.Pacman:
              g.TranslateTransform(i * ELEMENT_WIDTH + ELEMENT_WIDTH / 2, j * ELEMENT_HEIGHT + ELEMENT_HEIGHT/2);
              switch (pacman.GetDirection())
              {
                case Direction.North:
                  g.RotateTransform(270f);
                  break;
                case Direction.West:
                  g.RotateTransform(180f);
                  break;
                case Direction.South:
                  g.RotateTransform(90f);
                  break;
                default:
                  break;
              }
              g.DrawImage(Resources.pacman_moving,
                          -ELEMENT_WIDTH / 2,
                          -ELEMENT_HEIGHT / 2,
                          ELEMENT_WIDTH,
                          ELEMENT_HEIGHT);
              g.ResetTransform();
              break;
            case PacmanElement.Wall:
              g.DrawImage(Resources.Wall,
                          i * ELEMENT_WIDTH,
                          j * ELEMENT_HEIGHT,
                          ELEMENT_WIDTH,
                          ELEMENT_HEIGHT);
              break;
              //<Tommy Bouffard>
            case PacmanElement.Pill:
              g.DrawImage(Resources.Pill,
                          i * ELEMENT_WIDTH,
                          j * ELEMENT_HEIGHT,
                          ELEMENT_WIDTH,
                          ELEMENT_HEIGHT);
              break;
            case PacmanElement.SuperPill:
              g.DrawImage(Resources.SuperPill,
                          i * ELEMENT_WIDTH,
                          j * ELEMENT_HEIGHT,
                          ELEMENT_WIDTH,
                          ELEMENT_HEIGHT);
              break;
          }
        }
      }
      foreach (Ghost ghost in ghosts)
      {
        if (ghost != null)
        {
          ghost.Draw(g,ELEMENT_WIDTH,ELEMENT_HEIGHT);
        }
      }
    }

    public Pacman GetPacman()
    {
      return pacman;
    }
    //</Tommy Bouffard>

    public void LoadGrid(string path)
    {
      try
      {
        ghosts = new Ghost[NB_GHOSTS];
        grid.InitFrom(File.ReadAllText(path));
        for (int i = 0; i < grid.GetWidth(); i++)
        {
          for (int j = 0; j < grid.GetHeight(); j++)
          {
            if (grid.GetMazeElementAt(i, j) == PacmanElement.Pacman)
            {
              pacman.SetX(i * ELEMENT_WIDTH);
              pacman.SetY(j * ELEMENT_HEIGHT);
            }
          }
        }
      }
      catch (Exception ex)
      {
        //<Tommy Bouffard>
        MessageBox.Show(ex.Message, "Erreur de chargement", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //</Tommy Bouffard>
        Application.Exit();
      }
    }
    /// <summary>
    /// Crée les instances du fantômes dans la partie.
    /// </summary>
    public void SpawnGhosts()
    {
      int ghostNumber = 0;
      if (ghosts[ghosts.Length - 1] == null && ghosts[ghosts.Length-2] == null && ghosts[0] == null && ghosts[1]==null)
      {
        for (int i = 0; i < grid.GetWidth(); i++)
        {
          for (int j = 0; j < grid.GetHeight(); j++)
          {
            if (grid.GetMazeElementAt(i, j) == PacmanElement.Ghost)
            {
              ghosts[ghostNumber] = new Ghost(i, j);
              ghostNumber++;
            }
          }
        }
      }
    }

    public Size GetSize()
    {
      return new Size(grid.GetWidth() * ELEMENT_WIDTH, grid.GetHeight() * ELEMENT_HEIGHT);
    }

    //</Charles Lachance>
  }
}

