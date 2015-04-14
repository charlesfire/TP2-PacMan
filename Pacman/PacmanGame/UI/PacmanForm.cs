using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Pacman
{
  public partial class Form1 : Form
  {
    //<Charles Lachance>
    private string[] levelsPath = null;
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
    private void Update()
    {
      CheckIfSuperPill(aGame.GetPacman());
      EndGameResult result = aGame.Update();
      if (result == EndGameResult.Win)
      {
        EndGameForm endGameForm = new EndGameForm();
        endGameForm.SetEndGameResult(result);
        mainTimer.Stop();
        currentLevel++;
        if (currentLevel < levelsPath.Length)
        {
          aGame.LoadGrid(levelsPath[currentLevel]);
          this.ClientSize = new Size(aGame.GetSize().Width, aGame.GetSize().Height);
          endGameForm.SetIsLastLevel(false);
          endGameForm.ShowDialog();
          mainTimer.Start();
        }
        else
        {
          endGameForm.Show();
        }
      }
      else if (result == EndGameResult.Loose)
      {
        EndGameForm endGameForm = new EndGameForm();
        endGameForm.SetEndGameResult(result);
        endGameForm.Show();
        mainTimer.Stop();
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

    private void PacmanForm_Load( object sender, EventArgs e )
    {
      //<Charles Lachance>
      levelsPath = File.ReadAllLines("./PacLevels/LevelList.txt");
      if (levelsPath.Length != 0)
      {
        aGame.LoadGrid(levelsPath[currentLevel]);
      }
      else
      {
        MessageBox.Show("Aucun niveau n'est présent dans le fichier de configuration", "Erreur de chargement", MessageBoxButtons.OK, MessageBoxIcon.Error);
        Application.Exit();
      }
      
      // Ajuster automatiquement la taille de la fenêtre selon la taille du labyrithe de jeu
      // Optionnel mais peut être intéressant si vous voulez que ça se fasse automatiquement
      this.ClientSize = new Size( aGame.GetSize( ).Width, aGame.GetSize( ).Height );
      mainTimer.Enabled = true;
      //</Charles Lachance>
    }

    private void TimerEnd(object sender, EventArgs e)
    {
      CowardTimer.Enabled = false;
      Ghost.GhostChangeState(false);
    }

    private void TimerSpawn(object sender, EventArgs e)
    {
      aGame.SpawnGhosts();
    }

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
  }
}
