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
    Pacman pacman = new Pacman();

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
      ghosts = new Ghost[NB_GHOSTS];
      grid = new PacmanGrid();
    }

    // Vous aurez probablement à modifier le type de retour ici pour pouvoir
    // tester la fin de partie.  Par contre, pour vous donner un projet qui
    // compile, je n'avais pas le choix de mettre "void".
    public void Update()
    {
      foreach (Ghost ghost in ghosts)
      {
        if (ghost != null)
        {
          ghost.Update(grid);
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

      System.Diagnostics.Debug.WriteLine("Appel de la méthode Update");
    }

    public void Draw(Graphics g)
    {
      System.Diagnostics.Debug.WriteLine("Appel de la méthode Draw");

      for (int i = 0; i < grid.GetWidth(); i++)
      {
        for (int j = 0; j < grid.GetHeight(); j++)
        {
          switch (grid.GetMazeElementAt(i, j))
          {
            case PacmanElement.Pacman:
              g.DrawImage(Resources.pacman_moving,
                          i * ELEMENT_WIDTH,
                          j * ELEMENT_HEIGHT,
                          ELEMENT_WIDTH,
                          ELEMENT_HEIGHT);
              break;
            case PacmanElement.Wall:
              g.DrawImage(Resources.Wall,
                          i * ELEMENT_WIDTH,
                          j * ELEMENT_HEIGHT,
                          ELEMENT_WIDTH,
                          ELEMENT_HEIGHT);
              break;
          }
        }
      }

      // Pour afficher un bitmap inclus dans vos ressources (ex. Ghost.bmp), il suffit de faire
      //g.DrawImage(  Resources.Ghost,
      //              positionX, 
      //              positionY, 
      //              largeur du bitmap dans l'écran, 
      //              hauteur du bitmap dans l'écran);


    }

    public void LoadGrid(string path)
    {
      try
      {
        grid.InitFrom(File.ReadAllText(path));
      }
      catch (Exception ex)
      {
        //<Tommy Bouffard>
        MessageBox.Show(ex.Message, "Erreur de chargement", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //</Tommy Bouffard>
        Application.Exit();
      }
    }

    public Size GetSize()
    {
      return new Size(grid.GetWidth() * ELEMENT_WIDTH, grid.GetHeight() * ELEMENT_HEIGHT);
    }

    //</Charles Lachance>
  }
}

