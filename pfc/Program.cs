using System;

namespace Pfc
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Holà ! C'est un simple jeu de Pierre, Feuille et Ciseaux !");
      Console.WriteLine("Il est simplement fait pour tester un peu c# et voir mes capacités.");
      Console.WriteLine("Tu peux choisir entre trois chiffres:\n1: Pierre\n2: Feuille\n3: Ciseaux");
  
      string human = HumanMove();
      string computer = RandomComputMove();
      Console.WriteLine($"Tu as choisi {human}.");
      Console.WriteLine($"L'ordinateur a choisi {computer}.");

      string isWin = Game(human, computer);
      Console.WriteLine($"C'est {isWin} !");
    }

    public static string RandomComputMove()
    {
      string[] moveList = { "pierre", "feuille", "ciseaux" };
      Random rand = new Random();
      int randMove = rand.Next(moveList.Length);
      string move = moveList[randMove];
      return move;
    }

    public static string HumanMove()
    {
      string userInput = "";
      int move = 0;

      while (move < 1 || move > 3)
      {
        do
        {
          userInput = Console.ReadLine();
          Console.WriteLine("Fais un effort..");
        } while (!int.TryParse(userInput, out move));
        Console.WriteLine("S'il te plait, tape 1: Pierre, 2: Feuille, 3: Ciseaux.");
      }

      return move == 1 ? "pierre" :
              move == 2 ? "feuille" : "ciseaux";
    }

    public static string Game(string human, string computer)
    {
      string isWin = "";

      if (human == "pierre" && computer == "pierre") isWin = "exaeco";
      if (human == "feuille" && computer == "feuille") isWin = "exaeco";
      if (human == "ciseaux" && computer == "ciseaux") isWin = "exaeco";

      if (human == "pierre" && computer == "ciseaux") isWin = "gagné";
      if (human == "feuille" && computer == "pierre") isWin = "gagné";
      if (human == "ciseaux" && computer == "feuille") isWin = "gagné";

      if (human == "pierre" && computer == "feuille") isWin = "perdu";
      if (human == "feuille" && computer == "ciseaux") isWin = "perdu";
      if (human == "ciseaux" && computer == "pierre") isWin = "perdu";

      return isWin;
    }
  }
}