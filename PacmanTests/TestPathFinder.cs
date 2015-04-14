using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman;
using PathFinder;


namespace PacmanTests
{
  [TestClass]
  public class TestPathFinder
  {
    [TestMethod]
    //Ce test vérifie si l'appel récursif détecte lorsqu'il n'y a pas de chemin possible pour se rendre au pacman
    public void TestRecurseFindDirection01()
    {
      int[,] costs = new int[5, 5]{{4,3,2,3,int.MaxValue},{3,2,1,2,int.MaxValue},{2,1,0,1,int.MaxValue}
                                  ,{3,2,1,int.MaxValue,int.MaxValue},{4,3,2,int.MaxValue,int.MaxValue}};
      Point from = new Point(2, 2);
      Point to = new Point(costs.GetLength(0), costs.GetLength(1));
      Assert.AreEqual(Direction.Undefined, PathFinder.PathFinder.RecurseFindDirection(costs,from,to));
    }
    [TestMethod]
    //Ce test vérifie si l'appel récursif fonctionne si deux chemins de tailles exactes sont possibles.
    public void TestRecurseFindDirection02()
    {
      int[,] costs = new int[5, 5]{{3,2,1,2,3},{2,1,0,1,2},{3,2,1,2,3}
                                  ,{4,3,2,3,4},{5,4,3,4,5}};
      Point from = new Point(2, 2);
      Point to = new Point(3, 3);
      Assert.AreEqual(Direction.East, PathFinder.PathFinder.RecurseFindDirection(costs, from, to));
    }
    [TestMethod]
    //Ce test vérifie si l'appel récursif fonctionne bien.
    public void TestRecurseFindDirection03()
    {
      int[,] costs = new int[5, 5]{{4,3,2,3,4},{3,2,1,2,3},{2,1,0,1,2}
                                  ,{3,2,1,2,3},{4,3,2,3,4}};
      Point from = new Point(2, 2);
      Point to = new Point(3, 2);
      Assert.AreEqual(Direction.East, PathFinder.PathFinder.RecurseFindDirection(costs, from, to));
    }
  }
}
  