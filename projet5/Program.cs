using System.Security.Cryptography;
using System;
using AsciiArt;

namespace jeu_du_pendu
{
  public class Program
  {
    static void AfficherMot(string mot, List<char> lettres, List<char> exclus)
    {
      if (String.Join(", ", exclus) != "")
      {
        Console.WriteLine($"Le mot ne contient pas: {String.Join(", ", exclus)}");
        Console.WriteLine();
      }

      foreach (char letter in mot)
      {
        if (lettres.Contains(letter))
        {
          Console.Write(letter);
        }
        else
        {
          Console.Write("_ ");
        }
      }
    }

    static char DemanderLettre()
    {
      Console.Write("Rentrez une lettre: ");

      while(true)
      {
        try
        {
          char lettre = char.Parse(Console.ReadLine());
          return Char.ToUpper(lettre);
        }
        catch
        {
          Console.Write("Vous devez entrer une lettre: ");
        }
      }
    }

    static bool isWin(string mot, List<char> lettres)
    {
      bool win = false;

      foreach (char lettre in lettres)
      {
        mot = mot.Replace(lettre.ToString(), "");
      }

      if (mot == "")
        win = true;

      return win;
    }

    static void DevinerMot(string mot)
    {
      const int NB_VIES = 6;
      var liste = new List<char>();
      var exclus = new List<char>();
      int viesRestantes = NB_VIES;

      while(viesRestantes > 0)
      {
        Console.WriteLine(Ascii.PENDU[NB_VIES - viesRestantes]);
        Console.WriteLine();

        AfficherMot(mot, liste, exclus);
        Console.WriteLine();

        char lettre = DemanderLettre();
        
        while(liste.Contains(lettre) || exclus.Contains(lettre))
        {
          Console.WriteLine("Cette lettre a déjà été utilisée !");
          lettre = DemanderLettre();
        }

        Console.Clear();

        if (mot.Contains(lettre))
        {
          Console.WriteLine("Cette lettre est dans le mot !");
          liste.Add(lettre);
        }
        else
        {
          Console.WriteLine("Cette lettre n'est pas dans le mot.");
          exclus.Add(lettre);
          string phrase = viesRestantes > 0 ? $"Il vous reste {viesRestantes} vies." : $"Vous avez perdu.. Le mot était {mot}";
          Console.WriteLine(phrase);
          viesRestantes--;
        }

        if (isWin(mot, liste))
        {
          System.Console.WriteLine("Gagné !");
          break;
        }
        Console.WriteLine();

      }
    }

    static string[] ChargerMots(string nomFichier)
    {
      try
      {
        return File.ReadAllLines(nomFichier);
      }
      catch (System.Exception ex)
      {
        Console.WriteLine($"Erreur de lecture du fichier {nomFichier} : {ex.Message}");
      }

      return null;
    }

    static bool Rejouer()
    {
      Console.WriteLine("Voulez vous recommencer: (O/n)");
      string reponse = Console.ReadLine();

      if (reponse.ToUpper() == "O")
      {
        return true;
      }
      else if (reponse.ToUpper() == "N")
      {
        return false;
      }
      else
      {
        System.Console.Write("Vous devez réponse Oui(o) ou Non (n): ");
        return Rejouer();
      }

    }
    static void Main(string[] args)
    {
      var mots = ChargerMots("mots.txt");
      if (mots.Length == 0 || mots == null)
      {
        Console.WriteLine("La liste de mots est vide.");
      }
      else
      {
        while(true)
        {
          Random rand = new Random();
          string mot = mots[rand.Next(0, mots.Length + 1)].Trim().ToUpper();
          DevinerMot(mot);

          if (!Rejouer())
          {
            Console.WriteLine("A bientôt !");
            break;
          }

        }
      }



    }
  }
}