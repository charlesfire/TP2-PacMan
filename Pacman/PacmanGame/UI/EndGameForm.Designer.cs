namespace Pacman
{
  partial class EndGameForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndGameForm));
      this.lblVictoryOrLoose = new System.Windows.Forms.Label();
      this.btnContinueQuit = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblVictoryOrLoose
      // 
      this.lblVictoryOrLoose.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblVictoryOrLoose.Font = new System.Drawing.Font("Motorwerk", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblVictoryOrLoose.ForeColor = System.Drawing.Color.White;
      this.lblVictoryOrLoose.Location = new System.Drawing.Point(0, 0);
      this.lblVictoryOrLoose.Name = "lblVictoryOrLoose";
      this.lblVictoryOrLoose.Size = new System.Drawing.Size(624, 282);
      this.lblVictoryOrLoose.TabIndex = 0;
      this.lblVictoryOrLoose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // btnContinueQuit
      // 
      this.btnContinueQuit.AutoSize = true;
      this.btnContinueQuit.Location = new System.Drawing.Point(268, 225);
      this.btnContinueQuit.Name = "btnContinueQuit";
      this.btnContinueQuit.Size = new System.Drawing.Size(75, 23);
      this.btnContinueQuit.TabIndex = 1;
      this.btnContinueQuit.Text = "Quitter";
      this.btnContinueQuit.UseVisualStyleBackColor = true;
      this.btnContinueQuit.Click += new System.EventHandler(this.btnContinueQuit_Click);
      // 
      // EndGameForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(624, 282);
      this.Controls.Add(this.btnContinueQuit);
      this.Controls.Add(this.lblVictoryOrLoose);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "EndGameForm";
      this.Text = "Pacman";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblVictoryOrLoose;
    private System.Windows.Forms.Button btnContinueQuit;
  }
}