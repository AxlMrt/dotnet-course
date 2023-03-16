namespace FormationCS
{
  static class outils
  {
    public static int NombrePositifNonNul(string question)
    {
      return LongueurMinMax(question, 6, 16);
    }

    public static int LongueurMinMax(string question, int min, int max)
    {
      int nombre = DemanderNombre(question);
    
      if (nombre >= min && nombre <= max)
      {
        return nombre;
      }

      Console.WriteLine($"Le nombre doit-être compris entre {min} et {max}: ");
      return LongueurMinMax(question, min, max);
    }
    public static int DemanderNombre(string question)
    {
      Console.Write(question);
      while (true)
      {
        string reponse = Console.ReadLine();
        try
        {
          int reponseInt = int.Parse(reponse);
          return reponseInt;
        }
        catch
        {
          Console.Write("Vous devez entrer un nombre valide: ");
        }
      }
    }

  }
}