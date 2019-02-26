using System;
namespace Battleship
{
    /* 
     * Create and execute a Game   
    */
    public class Game
    {
        Player playerOne;
        Player playerTwo;
        public Game()
        {
        }

        public void CreateNewGame() 
        {
            playerOne = new Player();

            playerOne.AddBattleship("A1","C1");
            playerOne.AddBattleship("D1", "D1");
            playerOne.AddBattleship("H5", "H9");
            playerOne.AddBattleship("H5", "B9");


            Console.WriteLine(playerOne.ResolveAttack("A1"));
            Console.WriteLine(playerOne.ResolveAttack("B1"));
            Console.WriteLine(playerOne.ResolveAttack("C1"));
            Console.WriteLine(playerOne.ResolveAttack("D1"));
            Console.WriteLine(playerOne.ResolveAttack("J7"));
            Console.WriteLine(playerOne.ResolveAttack("H5"));
            Console.WriteLine(playerOne.ResolveAttack("H9"));
            Console.WriteLine(playerOne.ResolveAttack("H6"));
            Console.WriteLine(playerOne.ResolveAttack("H7"));
            Console.WriteLine(playerOne.ResolveAttack("H8"));
            Console.WriteLine(playerOne.ResolveAttack("B9"));

            playerTwo = new Player();
        }
    }
}
