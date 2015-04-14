//<Charles Lachance>
/*
 * Classe d'exception représentant une erreur de format dans un fichier de niveau.
 * Créer par Charles Lachance
 */
using System;

namespace Pacman
{
  [Serializable()]
  public class InvalidLevelFormatException : System.Exception
  {
    /// <summary>
    /// Constructeur par défaut
    /// </summary>
    public InvalidLevelFormatException() : base()
    {

    }

    /// <summary>
    /// Constructeur prenant un message d'erreur en paramêtre.
    /// </summary>
    /// <param name="message">Le message d'erreur à conserver</param>
    public InvalidLevelFormatException(string message) : base(message) 
    {
    
    }
  }
}
//</Charles Lachance>