/*
 * Classe représentant la fenêtre principale du jeu pacman.
 * Créer par Charles Lachance
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Pacman
{
  public partial class Form1 : Form
  {
    //<Charles Lachance>

    //Les chemins d'accès des niveaux
    private string[] levelsPath = null;

    //Le niveau actuel
    private int currentLevel = 0;
    
    public Form1( )
    {
      InitializeComponent( );
      levelsPath = new string [0];
      currentLevel = 0;
    }

    /// <summary>
    /// L'instance de la classe PacmanGame.
    /// </summary>
    PacmanGame aGame = new PacmanGame();

    /// <summary>
    /// Met à jour le jeu
    /// </summary>
    private void Update()
    {
      //Vérifie si le pacman est en mode super pillule
      CheckIfSuperPill(aGame.GetPacman());

      //Met à jour le jeu et récupère l'état de la partie
      EndGameResult result = aGame.Update();

      //Si le joueur a gagné...
      if (result == EndGameResult.Win)
      {
        //On crée une fenêtre de fin de partie
        EndGameForm endGameForm = new EndGameForm();

        //On met à jour le résultat à afficher
        endGameForm.SetEndGameResult(result);

        //On arrête le jeu
        mainTimer.Stop();

        //On change de niveau
        currentLevel++;

        //Si le niveau existe...
        if (currentLevel < levelsPath.Length)
        {
          //On charge le niveau
          aGame.LoadGrid(levelsPath[currentLevel]);

          //On redimensionne la fenêtre
          this.ClientSize = new Size(aGame.GetSize().Width, aGame.GetSize().Height);

          //On met à jour la fenêtre de fin de partie pour que ce ne soit pas le dernier niveau
          endGameForm.SetIsLastLevel(false);

          //On affiche le message disant que le joueur a réussi le niveau
          endGameForm.ShowDialog();

          //On recommence le jeu
          mainTimer.Start();
        }
        else
        {
          //On affiche le message disant que le joueur a fini le jeu
          endGameForm.ShowDialog();

          //On quitte
          Application.Exit();
        }
      }
      else if (result == EndGameResult.Loose) //Si le joueur a perdu...
      {
        //On crée une fenêtre de fin de partie
        EndGameForm endGameForm = new EndGameForm();

        //On met à jour le résultat à afficher
        endGameForm.SetEndGameResult(result);

        //On pause le jeu
        mainTimer.Stop();

        //On affiche le message disant que le joueur a perdu
        endGameForm.ShowDialog();

        //On quitte
        Application.Exit();
      }
      //</Charles Lachance>
    }

    private void OnTimer( object sender, EventArgs e )
    {
      Update();
      Invalidate();
    }

    private void OnDraw( object sender, PaintEventArgs e )
    {
      aGame.Draw(e.Graphics);
    }

    /// <summary>
    /// Évènement appelé lors du chargement de la fenêtre
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PacmanForm_Load( object sender, EventArgs e )
    {
      //<Charles Lachance>
      //On récupère la liste des niveaux
      levelsPath = File.ReadAllLines("./PacLevels/LevelList.txt");

      //Si on a au moins un niveau...
      if (levelsPath.Length != 0)
      {
        //On charge le premier niveau
        aGame.LoadGrid(levelsPath[currentLevel]);
      }
      else
      {
        //On affiche un message d'erreur
        MessageBox.Show("Aucun niveau n'est présent dans le fichier de configuration", "Erreur de chargement", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //On quitte
        Application.Exit();
      }
      
      // Ajuster automatiquement la taille de la fenêtre selon la taille du labyrithe de jeu
      // Optionnel mais peut être intéressant si vous voulez que ça se fasse automatiquement
      this.ClientSize = new Size( aGame.GetSize( ).Width, aGame.GetSize( ).Height );
      mainTimer.Enabled = true;
      //</Charles Lachance>
    }

    //<Tommy Bouffard-Hébert>
    /// <summary>
    /// Événnement tick du timer de fantôme peureux: désactive le mode peureux.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TimerEnd(object sender, EventArgs e)
    {
      CowardTimer.Enabled = false;
      Ghost.GhostChangeState(false);
    }
    /// <summary>
    /// Timer du spawn de fantôme.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TimerSpawn(object sender, EventArgs e)
    {
      aGame.SpawnGhosts();
    }
    /// <summary>
    /// Vérifie si le pacman a pris une super pastille.
    /// </summary>
    /// <param name="pacman">le pacman du jeu</param>
    private void CheckIfSuperPill(Pacman pacman)
    {
      if (pacman.GetHasSuperPill() == true)
      {
        pacman.SetHasSuperPill(false);
        if (CowardTimer.Enabled == true)
        {
          CowardTimer = new Timer();
          CowardTimer.Interval = 5000;
        }
        CowardTimer.Enabled = true;
        Ghost.GhostChangeState(true);
      }
    }
    //</Tommy Bouffard-Hébert>
  }
}
