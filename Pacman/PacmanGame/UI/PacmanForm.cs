using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Pacman;

namespace Pacman
{
  public partial class Form1 : Form
  {
    public Form1( )
    {
      InitializeComponent( );
    }

    /// <summary>
    /// L'instance de la classe PacmanGame.
    /// </summary>
    PacmanGame aGame = new PacmanGame();
    private void Update()
    {
      aGame.Update();
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
      aGame.LoadGrid("D:\\WORK HERE NOT IN GITHUB\\TP2-PacMan\\Pacman\\PacLevels\\Level - 1.paclevel");
      
      // Ajuster automatiquement la taille de la fenêtre selon la taille du labyrithe de jeu
      // Optionnel mais peut être intéressant si vous voulez que ça se fasse automatiquement
      this.ClientSize = new Size( aGame.GetSize( ).Width, aGame.GetSize( ).Height );
      mainTimer.Enabled = true;
    }

    private void TimerEnd(object sender, EventArgs e)
    {
      CowardTimer.Enabled = false;
      Ghost.GhostChangeState(false);
    }
  }
}
