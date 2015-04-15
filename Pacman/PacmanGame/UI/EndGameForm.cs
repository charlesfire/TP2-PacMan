//<Charles Lachance>
/*
 * Classe représentant la fenêtre s'affichant lorsque le joueur finit un niveau ou
 *  perd ou finit le jeu
 * Créer par Charles Lachance
 */
using System.Windows.Forms;

namespace Pacman
{
  public partial class EndGameForm : Form
  {
    //Si le niveau que le joueur vient de finir était le dernier
    private bool isLastLevel = true;

    public EndGameForm()
    {
      isLastLevel = true;
      InitializeComponent();
    }

    /// <summary>
    /// Change le résultat de la partie à afficher
    /// </summary>
    /// <param name="result">Le résultat de la partie à afficher</param>
    public void SetEndGameResult(EndGameResult result)
    {
      //Si le joueur a gagné..
      if (result == EndGameResult.Win)
      {
        //On affiche une victoire
        lblVictoryOrLose.Text = "Victoire!";
      }
      else
      {
        //On affiche une défaite
        lblVictoryOrLose.Text = "Defaite...";
      }
    }

    /// <summary>
    /// Permet de changer si le niveau que le joueur viens de finir est le dernier
    /// </summary>
    /// <param name="isLastLevel">Si le niveau que le joueur viens de finir est le dernier</param>
    public void SetIsLastLevel(bool isLastLevel)
    {
      //Met à jour si le niveau que le joueur viens de finir est le dernier
      this.isLastLevel = isLastLevel;

      //Si le niveau que le joueur viens de finir n'est pas le dernier...
      if (!isLastLevel)
      {
        //On change le texte du bouton...
        btnContinueQuit.Text = "Prochain niveau";
      }
    }

    /// <summary>
    /// Évènement appeler lors du clique sur le bouton
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnContinueQuit_Click(object sender, System.EventArgs e)
    {
      //On ferme cette fenêtre
      this.Close();
    }
  }
}
//</Charles Lachance>