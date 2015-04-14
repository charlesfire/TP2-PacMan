//<Charles Lachance>
using System;

namespace Pacman
{
  [Serializable()]
  public class InvalidLevelFormatException : System.Exception
  {
    public InvalidLevelFormatException() : base() { }
    public InvalidLevelFormatException(string message) : base(message) { }
    public InvalidLevelFormatException(string message, System.Exception inner) : base(message, inner) { }

    protected InvalidLevelFormatException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) { }
  }
}
//</Charles Lachance>