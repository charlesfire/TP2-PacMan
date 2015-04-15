/*
 * Classe principale du jeu Pacman. Représente le jeu Pacman dont le but est de manger
 *    toutes les pillules sans se faire attraper par les fantômes.
 * Créer par Charles Lachance et Tommy Bouffard
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using Pacman.Properties;
using PathFinder;

namespace Pacman
{
  public class PacmanGame
  {
    //<Tommy Bouffard>
    //Hauteur du formulaire du jeu
    public const int ELEMENT_HEIGHT = 20;

    //Largeur du formulaire du jeu
    public const int ELEMENT_WIDTH = 20;

    //Pacman du jeu
    private Pacman pacman = null;

    //Nombre de fantômes dans le jeu
    private const int NB_GHOSTS = 4;

    //Tableau des fantômes dans le jeu
    private Ghost[] ghosts = new Ghost[NB_GHOSTS];
    //</Tommy Bouffard>

    //<Charles Lachance>

    //Le niveau du jeu actuel
    private PacmanGrid grid = null;

    /// <summary>
    /// Constructeur du jeu de Pacman
    /// </summary>
    public PacmanGame()
    {
      pacman = new Pacman();
      ghosts = new Ghost[NB_GHOSTS];
      grid = new PacmanGrid();
    }

    /// <summary>
    /// Met à jour le jeu et détermine si la partie est terminée
    /// </summary>
    /// <returns>Retourne si le joueur a perdu/gagné ou si la partie n'est pas terminée</returns>
    public EndGameResult Update()
    {
      //Pour chaque fantôme du jeu...
      foreach (Ghost ghost in ghosts)
      {
        //Si le fantôme existe...
        if (ghost != null)
        {
          //On met à jour le fantôme
          ghost.Update(grid, pacman);

          //Si un fantôme est à la même position que le pacman...
          if (ghost.GetX() == (int)pacman.GetX()/ELEMENT_WIDTH && ghost.GetY() == (int)pacman.GetY()/ELEMENT_HEIGHT)
          {
            //Le joueur a perdu
            return EndGameResult.Loose;
          }
        }
      }

      //Si la flèche droite est pressée...
      if (Keyboard.IsKeyDown(Key.Right))
      {
        //On essaie de déplacer le pacman vers la droite
        pacman.Move(Direction.East, grid);
      }
      else if (Keyboard.IsKeyDown(Key.Up)) //Si la flèche haut est pressée...
      {
        //On essaie de déplacer le pacman vers le haut
        pacman.Move(Direction.North, grid);
      }
      else if (Keyboard.IsKeyDown(Key.Left)) //Si la flèche gauche est pressée...
      {
        //On essaie de déplacer le pacman vers la gauche
        pacman.Move(Direction.West, grid);
      }
      else if (Keyboard.IsKeyDown(Key.Down)) //Si la flèche bas est pressée...
      {
        //On essaie de déplacer le pacman vers le bas
        pacman.Move(Direction.South, grid);
      }

      //Si toutes les pillules ont été mangé...
      if (grid.GetPillCount() == 0)
      {
        //Le joueur a gagné
        return EndGameResult.Win;
      }
      
      return EndGameResult.NotFinished;
    }

    /// <summary>
    /// Affiche le jeu à l'écran
    /// </summary>
    /// <param name="g">Objet permettant de dessiner à l'écran</param>
    public void Draw(Graphics g)
    {
      //Pour chaque colonne du niveau du jeu...
      for (int i = 0; i < grid.GetWidth(); i++)
      {
        //Pour chaque ligne du niveau du jeu...
        for (int j = 0; j < grid.GetHeight(); j++)
        {
          //Si l'élément à la position (i,j) est un...
          switch (grid.GetMazeElementAt(i, j))
          {
            case PacmanElement.Pacman: //Pacman
              //On déplace le centre pour dessiner
              g.TranslateTransform(i * ELEMENT_WIDTH + ELEMENT_WIDTH / 2, j * ELEMENT_HEIGHT + ELEMENT_HEIGHT/2);

              //Si le pacman regarde vers...
              switch (pacman.GetDirection())
              {
                case Direction.North: //Le nord
                  //On tourne le pacman
                  g.RotateTransform(270f);
                  break;
                case Direction.West: //L'ouest
                  //On tourne le pacman
                  g.RotateTransform(180f);
                  break;
                case Direction.South: //Le sud
                  //On tourne le pacman
                  g.RotateTransform(90f);
                  break;
                default:
                  break;
              }

              //On dessine le pacman
              g.DrawImage(Resources.pacman_moving,
                          -ELEMENT_WIDTH / 2,
                          -ELEMENT_HEIGHT / 2,
                          ELEMENT_WIDTH,
                          ELEMENT_HEIGHT);
              //On réinitialise les tranformations
              g.ResetTransform();
              break;
            case PacmanElement.Wall: //Mur
              //On dessine un mur
              g.DrawImage(Resources.Wall,
                          i * ELEMENT_WIDTH,
                          j * ELEMENT_HEIGHT,
                          ELEMENT_WIDTH,
                          ELEMENT_HEIGHT);
              break;
              //<Tommy Bouffard>
            case PacmanElement.Pill: //Pillule
              //On dessine une pillule
              g.DrawImage(Resources.Pill,
                          i * ELEMENT_WIDTH,
                          j * ELEMENT_HEIGHT,
                          ELEMENT_WIDTH,
                          ELEMENT_HEIGHT);
              break;
            case PacmanElement.SuperPill: //Super Pillule
              //On dessine une super pillule
              g.DrawImage(Resources.SuperPill,
                          i * ELEMENT_WIDTH,
                          j * ELEMENT_HEIGHT,
                          ELEMENT_WIDTH,
                          ELEMENT_HEIGHT);
              break;
          }
        }
      }

      //Pour chaque fantôme du jeu...
      foreach (Ghost ghost in ghosts)
      {
        //Si le fantôme existe...
        if (ghost != null)
        {
          //On affiche le fantôme
          ghost.Draw(g,ELEMENT_WIDTH,ELEMENT_HEIGHT);
        }
      }
    }

    /// <summary>
    /// Obtient le pacman du jeu
    /// </summary>
    /// <returns>Retourne le pacman du jeu</returns>
    public Pacman GetPacman()
    {
      return pacman;
    }
    //</Tommy Bouffard>

    /// <summary>
    /// Charge un niveau du jeu
    /// </summary>
    /// <param name="path">Le chemin d"accès du niveau</param>
    public void LoadGrid(string path)
    {
      try
      {
        //On recrée le tableau des fantômes pour se débarasser de ceux du niveau précédent
        ghosts = new Ghost[NB_GHOSTS];

        //On initialise la grille du jeu
        grid.InitFrom(File.ReadAllText(path));

        //Pour chaque élément de la grille du jeu...
        for (int i = 0; i < grid.GetWidth(); i++)
        {
          for (int j = 0; j < grid.GetHeight(); j++)
          {
            //Si l'élément est le pacman...
            if (grid.GetMazeElementAt(i, j) == PacmanElement.Pacman)
            {
              //On initialise la position du pacman
              pacman.SetX(i * ELEMENT_WIDTH);
              pacman.SetY(j * ELEMENT_HEIGHT);
              return;
            }
          }
        }
      }
      catch (Exception ex) //Erreur
      {
        //<Tommy Bouffard>
        //On affiche le message d'erreur
        MessageBox.Show(ex.Message, "Erreur de chargement", MessageBoxButtons.OK, MessageBoxIcon.Error);
        Application.Exit();
      }
    }
    /// <summary>
    /// Crée les instances du fantômes dans la partie.
    /// </summary>
    public void SpawnGhosts()
    {
      int ghostNumber = 0;
      if (ghosts[ghosts.Length - 1] == null && ghosts[ghosts.Length-2] == null && ghosts[0] == null && ghosts[1]==null)
      {
        for (int i = 0; i < grid.GetWidth(); i++)
        {
          for (int j = 0; j < grid.GetHeight(); j++)
          {
            if (grid.GetMazeElementAt(i, j) == PacmanElement.Ghost)
            {
              ghosts[ghostNumber] = new Ghost(i, j);
              ghostNumber++;
            }
          }
        }
      }
    }
    //</Tommy Bouffard>

    /// <summary>
    /// Obtient la taille que le jeu prend dans la fenêtre
    /// </summary>
    /// <returns>Retourne la taille que le jeu prend dans la fenêtre</returns>
    public Size GetSize()
    {
      return new Size(grid.GetWidth() * ELEMENT_WIDTH, grid.GetHeight() * ELEMENT_HEIGHT);
    }

    //</Charles Lachance>
  }
}

