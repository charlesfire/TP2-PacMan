using System.Drawing;
using PathFinder;

namespace Pacman
{
  public class PacmanGame
  {
    //<Tommy Bouffard>
    //Hauteur du formulaire du jeu
    public const int GAME_HEIGHT = 1;
    //Largeur du formulaire du jeu
    public const int GAME_WIDTH = 1;
    //Pacman du jeu
    Pacman pacman = new Pacman();

    //Nombre de fantômes dans le jeu
    private int NB_GHOSTS = 4;

    //Tableau des fantômes dans le jeu
    private Ghost[] ghosts = new Ghost[NB_GHOSTS];

    //...? (à compléter)
    private bool[] pills = new bool[1];
    //</Tommy Bouffard>

    //<Charles Lachance>
    /// <summary>
    /// Constructeur du jeu de Pacman
    /// </summary>
    public PacmanGame()
    {
      ghosts = new Ghost[NB_GHOSTS];
      pills = new bool[1];
    }
    //</Charles Lachance>

    // Vous aurez probablement à modifier le type de retour ici pour pouvoir
    // tester la fin de partie.  Par contre, pour vous donner un projet qui
    // compile, je n'avais pas le choix de mettre "void".
    public void Update()
    {
      // A COMPLETER
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
  }
}

