using System;
using FormationCS;

namespace generateur_mot_de_passe
{
  public class Program
  {
    static void GenererMdp(int longueur_mot_de_passe)
    {
      const int NB_MDP = 10;

      string minuscule = "abcdefghijklmnopqrstuvwxyz";
      string majuscule = minuscule.ToUpper();
      string chiffres = "0123456789";
      string special = "~`!@#$%^&*()_-+={[}]|:;»'<,>.?/";
      string alphabet = "";

      Random rand = new Random();

      Console.WriteLine("Vous voulez un mot de passe avec:");
      Console.WriteLine("1. Uniquement des caractères en minuscule");
      Console.WriteLine("2. Des caractères en minuscule et majuscule");
      Console.WriteLine("3. Des caractères et des chiffres");
      Console.WriteLine("4. Caractères, chiffres et caractères spéciaux");
      int reponse = outils.LongueurMinMax("Votre choix: ", 1, 4);

      if (reponse == 1)
        alphabet = minuscule;
      else if (reponse == 2)
        alphabet = majuscule;
      else if (reponse == 3)
        alphabet = minuscule + majuscule + chiffres;
      else
        alphabet = minuscule + majuscule + chiffres + special;

      for (int i = 0; i < NB_MDP; i++)
      {
        string mdp = "";
        for (int j = 0; j < longueur_mot_de_passe; j++)
        {
          int index = rand.Next(0, alphabet.Length);
          mdp += $"{alphabet[index]}";
        }
          Console.WriteLine($"Mot de passe: {mdp}");
      }
    }

   
    static void Main(string[] args)
    {
      string question = "Quelle longueur voulez-vous pour votre mot de passe: ";
      int longueur_mot_de_passe = outils.NombrePositifNonNul(question);

      GenererMdp(longueur_mot_de_passe);
    }
  }
}