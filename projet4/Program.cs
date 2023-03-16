using System;

namespace generateur_phrase
{
  class Program
  {

    static string GenererMot(string[] mots)
    {
      Random rand = new Random();
      int random = rand.Next(0, mots.Length);
      return mots[random];
    }
    public static void Main(string[] args)
    {
      string[] sujets = {
        "Marie-Anne",
        "Axel",
        "Le chien",
        "Le chat",
        "La lune",
        "Le soleil",
        "Le boucher"
      };

      string[] verbes = {
        "accepte",
        "mange",
        "écrase",
        "coupe",
        "avale",
        "se bat avec",
        "s'accroche à",
      };

      string[] complements = {
        "une pomme",
        "le temps",
        "dans le salon",
        "même s’il est effrayé",
        "comme le ferait un enfant",
        "au cas où il aurait faim",
        "tous les matins"
      };

      const int NB_PHRASE = 100;
      int doublons = 0;
      var liste = new List<string>();

      while (liste.Count < NB_PHRASE)
      {
        string sujet = GenererMot(sujets);
        string verbe = GenererMot(verbes);
        string complement = GenererMot(complements);

        string phrase = $"{sujet} {verbe} {complement}";
        phrase = phrase.Replace("à les", "aux");
        phrase = phrase.Replace("à le", "au");

        if (liste.Contains(phrase))
        {
          doublons++;
        } else {
          liste.Add(phrase);
        }
      }

      foreach(string phrase in liste)
      {
        System.Console.WriteLine(phrase);
      }
      System.Console.WriteLine($"Doublons évités: {doublons}");

    }
  }
}