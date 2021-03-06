﻿using System.Drawing;
using Pacman.Properties;
using PathFinder;

/*
 *Cette classe contient l'ensemble des propriétés et des fonctions attachés aux fantômes dans le jeu.
 * 
 */
namespace Pacman
{
  //<Tommy Bouffard>
  public class Ghost
  {
    //Position en X du fantôme
    private int xPosition = 0;
    //Position en Y du fantôme
    private int yPosition = 0;
    //État du fantôme (true si le pacman a une super pastille, faux si il n'en a pas).
    private static bool cowardState = false;
    //Nombre de fantômes
    private const int instancecount = 4;
    //Nombre de mise à jours
    private int nbUpdates = 0;
    //Nombre de mise à jours effectués avant un déplacement
    private int nbUpdatesBeforeMove = 5;
    //x Initial du fantôme
    private int initX = 0;
    //y initial du fantôme
    private int initY = 0;
    //Élément en dessous du fantôme
    PacmanElement elementUnderGhost = PacmanElement.Undefined;

    /// <summary>
    /// Constructeur de ghost; initialise les composantes selon des valeurs données.
    /// </summary>
    /// <param name="gridX">Position en X reçue</param>
    /// <param name="gridY">Position en Y reçue</param>
    public Ghost(int gridX, int gridY)
    {
      xPosition = gridX;
      yPosition = gridY;
      cowardState = false;
      nbUpdates = 0;
      initX = gridX;
      initY = gridY;
      elementUnderGhost = PacmanElement.Undefined;
    }

    /// <summary>
    /// Constructeur de ghost; Initialise les composantes.
    /// </summary>
    public Ghost()
    {
      cowardState = false;
      nbUpdates = 0;
      elementUnderGhost = PacmanElement.Undefined;
    }
    /// <summary>
    /// Obtient la position en X du fantôme
    /// </summary>
    /// <returns>position en X du fantôme</returns>
    public int GetX()
    {
      return xPosition;
    }
    /// <summary>
    /// Obtient la position en Y du fantôme
    /// </summary>
    /// <returns>position en Y du fantôme</returns>
    public int GetY()
    {
      return yPosition;
    }
    /// <summary>
    /// Modifie la position en X selon un paramêtre reçu
    /// </summary>
    /// <param name="recievedX">entier reçu</param>
    public void SetX(int recievedX)
    {
      xPosition = recievedX;
    }
    /// <summary>
    /// Modifie la position en Y selon un paramêtre reçu
    /// </summary>
    /// <param name="recievedY">entier reçu</param>
    public void SetY(int recievedY)
    {
      yPosition = recievedY;
    }
    /// <summary>
    /// Déplace le fantôme dans la grille du jeu selon le paramêtre reçu
    /// </summary>
    /// <param name="direction">direction du fantôme</param>
    /// <param name="aMaze">Grille du jeu</param>
    public void Move(Direction direction, PacmanGrid aMaze)
    {
      aMaze.SetMazeElementAt(xPosition, yPosition, elementUnderGhost);

      if (direction == Direction.East)
      {
        xPosition++;
      }
      else if (direction == Direction.West)
      {
        xPosition--;
      }
      else if (direction == Direction.North)
      {
        yPosition--;
      }
      else if (direction == Direction.South)
      {
        yPosition++;
      }
      elementUnderGhost = aMaze.GetMazeElementAt(xPosition, yPosition);
      aMaze.SetMazeElementAt(xPosition,yPosition, PacmanElement.Ghost);
    }
    /// <summary>
    /// Met à jour le fantôme selon la position du pacman
    /// </summary>
    /// <param name="aMaze">Grille du jeu</param>
    /// <param name="pacman">Instance du pacman</param>
    public void Update(PacmanGrid aMaze,Pacman pacman)
    {
      nbUpdates++;
      if (nbUpdates % nbUpdatesBeforeMove == 0)
      {
        Point ghostPoint = new Point(xPosition, yPosition);
        Point pacPoint = new Point((int)(pacman.GetX()/20f), (int)(pacman.GetY()/20f));
        if (cowardState == true)
        {
          Move(PathFinder.PathFinder.FindShortestPath(aMaze,ghostPoint, new Point(initX,initY)),aMaze);
        }
        else
        {
          Move(PathFinder.PathFinder.FindShortestPath(aMaze, ghostPoint, pacPoint), aMaze);
        }
      }
    }
    /// <summary>
    /// Cette fonction change l'état du fantôme
    /// </summary>
    /// <param name="coward">État peureux du fantôme</param>
    public static void GhostChangeState(bool coward)
    {
      cowardState = coward;
    }
    /// <summary>
    /// Dessine le fantôme sur l'écran du jeu.
    /// </summary>
    /// <param name="g"></param>
    /// <param name="ELEMENT_WIDTH"></param>
    /// <param name="ELEMENT_HEIGHT"></param>
    public void Draw(Graphics g, int ELEMENT_WIDTH, int ELEMENT_HEIGHT)
    {
      if (GetState() == false)
      {
        g.DrawImage(Resources.Ghost,
                              xPosition * ELEMENT_WIDTH,
                              yPosition * ELEMENT_HEIGHT,
                              ELEMENT_WIDTH,
                              ELEMENT_HEIGHT);
      }
      else
      {
        g.DrawImage(Resources.GhostWeak,
                              xPosition * ELEMENT_WIDTH,
                              yPosition * ELEMENT_HEIGHT,
                              ELEMENT_WIDTH,
                              ELEMENT_HEIGHT);
      }
    }
    /// <summary>
    /// Obtient la valeur de l'état de choc du fantôme
    /// </summary>
    /// <returns>État de peur du fantôme</returns>
    public static bool GetState()
    {
      return cowardState;
    }
    /// <summary>
    /// Obtient la condition de si le fantôme est au dessus d'une pastille
    /// </summary>
    /// <returns>true si il a une pastille, faux si il n'en a pas</returns>
    public bool HasPill()
    {
      return (elementUnderGhost == PacmanElement.Pill || elementUnderGhost == PacmanElement.SuperPill);
    }
  }
}
//</Tommy Bouffard>
