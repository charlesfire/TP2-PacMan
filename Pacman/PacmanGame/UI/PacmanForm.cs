using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Pacman;
using System.Collections.Generic;

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
      EndGameResult result = aGame.Update();
      if (result == EndGameResult.Win)
      {
        currentLevel++;
        if (currentLevel < levelsPath.Length)
        {
          aGame.LoadGrid(levelsPath[currentLevel]);
          this.ClientSize = new Size(aGame.GetSize().Width, aGame.GetSize().Height);
        }
        else
        {
          Application.Exit();
        }
      }
      else if (result == EndGameResult.Loose)
      {

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
      aGame.LoadGrid(levelsPath[currentLevel]);
      
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
  }
}
