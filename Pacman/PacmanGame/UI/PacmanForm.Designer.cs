namespace Pacman
{
  partial class Form1
  {
    /// <summary>
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Nettoyage des ressources utilisées.
    /// </summary>
    /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
    protected override void Dispose( bool disposing )
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose( );
      }
      base.Dispose( disposing );
    }

    #region Code généré par le Concepteur Windows Form

    /// <summary>
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent( )
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.mainTimer = new System.Windows.Forms.Timer(this.components);
      this.CowardTimer = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // mainTimer
      // 
      this.mainTimer.Interval = 16;
      this.mainTimer.Tick += new System.EventHandler(this.OnTimer);
      // 
      // CowardTimer
      // 
      this.CowardTimer.Interval = 15000;
      this.CowardTimer.Tick += new System.EventHandler(this.TimerEnd);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(384, 362);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Pacman";
      this.Load += new System.EventHandler(this.PacmanForm_Load);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnDraw);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Timer mainTimer;
    private System.Windows.Forms.Timer CowardTimer;
  }
}

