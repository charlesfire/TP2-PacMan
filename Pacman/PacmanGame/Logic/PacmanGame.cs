using System;
using System.Drawing;
using System.IO;
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
    }
    //</Charles Lachance>

    // Vous aurez probablement à modifier le type de retour ici pour pouvoir
    // tester la fin de partie.  Par contre, pour vous donner un projet qui
    // compile, je n'avais pas le choix de mettre "void".
    public void Update()
    {
      foreach (Ghost ghost in ghosts)
      {
        ghost.Update(grid);
      }

      System.Diagnostics.Debug.WriteLine("Appel de la méthode Update");
    }

    public void Draw(Graphics g)
    {
      // A COMPLETER
      System.Diagnostics.Debug.WriteLine("Appel de la méthode Draw");


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
        Console.WriteLine(ex.Message);
      }
    }
  }
}

