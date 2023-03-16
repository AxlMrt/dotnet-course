using System;

namespace nombre_magique
{
  public class Magique
  {
    static int NombreAleatoire(int min, int max)
    {
      Random rand = new Random();
      int toGuess = rand.Next(min, max);

      return toGuess;
    }

    static int DemanderNombre(int min, int max)
    {
      int nombre = min - 1;
      while (nombre < min || nombre > max)
      {
        try
        {
          nombre = int.Parse(Console.ReadLine());

          if (nombre < min || nombre > max)
          {
            Console.Write($"Presque ! Entre {min} et {max}: ");
          }
        }
        catch
        {
          Console.Write("Vous devez entrer un chiffre valide: ");
        }
      }

      return nombre;
    }

    static void Jeu(int guess, int min, int max)
    {
      int tour = 4;
      int user = DemanderNombre(min, max);
  
      while (user != guess && tour != 0)
      {
        if (user > guess)
        {
          Console.WriteLine("Trop grand ! Mon chiffre est plus petit.");
          Console.WriteLine($"T'as encore {tour} essais.");
          Console.Write($"Donne moi un chiffre inférieur à {user}: ");
          user = DemanderNombre(min, max);
          tour -= 1;
        } else if (user < guess)
        {
          Console.WriteLine("Trop petit ! Mon chiffre est plus grand.");
          Console.WriteLine($"T'as encore {tour} essais.");
          Console.Write($"Donne moi un chiffre supérieur à {user}: ");
          user = DemanderNombre(min, max);
          tour -= 1;
        }
      }

      if (tour == 0)
      {
        Console.WriteLine("Désolé.. t'as perdu.");
        Restart(min, max);
      } else {
        Console.WriteLine("Bien joué ! T'as gagné !");
        Restart(min, max);
      }
    }

    static void Restart(int min, int max)
    {
      string restart = "";

      while (restart != "o" && restart != "n")
      {
        Console.Write("Tu veux rejouer ? (O/n): ");
        restart = Console.ReadLine();
        restart = restart.Trim().ToLower();

        if (restart == "")
        {
          Console.Write("Un espace n'est pas Oui(o) ou Non(n)..");
        }
      }

      if (restart == "o")
      {
        int newMin = DefMin();
        int newMax = DefMax();

        if (newMin >= newMax)
        {
          Console.WriteLine("Le minimum ne peut pas être supérieur au maximum..");
          newMin = DefMin();
          newMax = DefMax();
        }
        Console.Write($"Choisis un chiffre entre {newMin} et {newMax}: ");
        int newGuess = NombreAleatoire(newMin, newMax);
        Jeu(newGuess, newMin, newMax);
      } else if (restart == "n") {
        Console.WriteLine("A bientôt !");
      }
    }

    static int DefMin()
    {
      int min = -1;

      while (min < 0)
      {
        try
        {
          Console.Write("Choisis le premier chiffre qui sera le minimum: ");
          min = int.Parse(Console.ReadLine());
        }
        catch
        {
          Console.Write("Tu dois choisir un chiffre: ");
        }
      }

      return min;
    }

    static int DefMax()
    {
      int max = -1;
      
      while (max < 0)
      {
        try
        {
          Console.Write("Choisis le premier chiffre qui sera le maximum: ");
          max = int.Parse(Console.ReadLine());
        }
        catch
        {
          Console.Write("Tu dois choisir un chiffre: ");
        }
      }

      return max;
    }

    static void Main(string[] args)
    {
      int min = DefMin();
      int max = DefMax();

      if (min >= max)
      {
        Console.WriteLine("Le minimum ne peut pas être supérieur au maximum..");
        min = DefMin();
        max = DefMax();
      }

      int guessNum = NombreAleatoire(min, max);

      Console.Write($"Choisissez un chiffre entre {min} et {max}: ");
      Jeu(guessNum, min, max);
    }
  }
}