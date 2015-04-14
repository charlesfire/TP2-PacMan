using System.Windows.Forms;

namespace Pacman
{
  public partial class EndGameForm : Form
  {
    private bool isLastLevel = true;

    public EndGameForm()
    {
      isLastLevel = true;
      InitializeComponent();
    }

    public void SetEndGameResult(EndGameResult result)
    {
      if (result == EndGameResult.Win)
      {
        lblVictoryOrLose.Text = "Victoire!";
      }
      else
      {
        lblVictoryOrLose.Text = "Defaite...";
      }
    }

    public void SetIsLastLevel(bool isLastLevel)
    {
      this.isLastLevel = isLastLevel;
      if (!isLastLevel)
      {
        btnContinueQuit.Text = "Prochain niveau";
      }
    }

    private void btnContinueQuit_Click(object sender, System.EventArgs e)
    {
      if (isLastLevel)
      {
        Application.Exit();
      }
      else
      {
        this.Close();
      }
    }
  }
}
