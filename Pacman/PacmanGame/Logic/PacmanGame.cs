using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Windows.Input;
using Pacman.Properties;
namespace Pacman
{
  public class PacmanGame
  {

    /// <summary>
    /// Constructeur du jeu de Pacman
    /// </summary>
    public PacmanGame()
    {
    }


    

    // Vous aurez probablement à modifier le type de retour ici pour pouvoir
    // tester la fin de partie.  Par contre, pour vous donner un projet qui
    // compile, je n'avais pas le choix de mettre "void".
    public void Update( )
    {
      // A COMPLETER
      System.Diagnostics.Debug.WriteLine( "Appel de la méthode Update" );
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
