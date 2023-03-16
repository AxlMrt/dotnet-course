using System;
namespace jeu_de_math
{
  public class Program
  {
    enum e_Operateur
    {
      ADDITION = 1,
      SOUSTRACTION = 2,
      MULTIPLICATION = 3
    }

    static bool PoserQuestion(int min, int max)
    {
      int a = Aleatoire(min, max);
      int b = Aleatoire(min, max);
      e_Operateur o = (e_Operateur)Aleatoire(1, 3);
      int op = Operation(a, b, o);
      int reponseInt = 0;

      while (true)
      {
        string reponse = Console.ReadLine();

        try
        {
          reponseInt = int.Parse(reponse);
          break;
        }
        catch
        {
          Console.WriteLine("Vous devez entrer un nombre valide.");
        }
      }

      if (reponseInt == op)
      {
        return true;
      }

      return false;
    }

    static int Aleatoire(int min, int max)
    {
      Random random = new Random();
      return random.Next(min, max + 1);
    }

    static int Operation(int a, int b, e_Operateur op)
    {
      int result = 0;

      switch (op)
      {
        case e_Operateur.ADDITION:
          Console.Write($"{a} + {b} = ");
          result = a + b;
          break;
        case e_Operateur.SOUSTRACTION:
          Console.Write($"{a} - {b} = ");
          result = a - b;
          break;
        case e_Operateur.MULTIPLICATION:
          Console.Write($"{a} x {b} = ");
          result = a * b;
          break;
      }

      return result;
    }

    static void Main(string[] args)
    {
      const int NOMBRE_MIN = 1;
      const int NOMBRE_MAX = 10;
      const int NB_QUESTION = 3;
      int score = 0;
      int moyenne = NB_QUESTION / 2;

      for (int i = 0; i < NB_QUESTION; i++)
      {
        Console.WriteLine($"Question n°{i + 1}/{NB_QUESTION}:");
        bool bonneReponse = PoserQuestion(NOMBRE_MIN, NOMBRE_MAX);

        if (bonneReponse)
        {
          Console.WriteLine("Bonne réponse!");
          score++;
        } else {
          Console.WriteLine("Mauvaise réponse!");
        }
      }

      Console.WriteLine($"Vous avez {score}/{NB_QUESTION} bonnes réponses !");
      
      if (score == NB_QUESTION)
      {
        Console.WriteLine("Excellent score!");
      }
      else if (score == moyenne)
      {
        Console.WriteLine("Tout juste la moyenne !");
      }
      else if (score == 0)
      {
        Console.WriteLine("Vous devriez réviser vos maths..");
      }
    }    
  }
}