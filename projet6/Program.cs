using System.Net;
using Newtonsoft.Json;

namespace project_pizza
{
  class Personalized : Pizza
  {
    static int nbPizz = 1;
    protected int numero = nbPizz;

    public Personalized() : base("Personalized", 5f, false, null)
    {

      this.ingredients = new List<string>();

      while (true)
      {
        if (ingredients.Count > 0)
        {
          Console.WriteLine($"Selected: {string.Join(", ", ingredients)}");
        }

        Console.Write($"Choose your ingredients for the Personalized {numero} (Enter to finish): ");
        string ingr = Console.ReadLine();
        ingr = Capitalize(ingr);

        if (string.IsNullOrEmpty(ingr))
          break;

        if (ingredients.Contains(ingr))
        {
          Console.WriteLine("You've already choose this ingredient.");
          Console.WriteLine();
        }
        else
        {
          ingredients.Add(ingr);
          Console.Clear();
        }
      }

      nbPizz++;
      this.name = name + $" {numero}";
      this.price = price + (1.5f * ingredients.Count);
    }
  }

  public class Pizza
  {
    public string name { get; init; }
    public float price { get; init; }
    public bool vegetarian { get; init; }
    public List<string> ingredients { get; init; }

    public Pizza(string name, float price, bool vegetarian, List<string> ingredients = null)
    {
      this.name = name;
      this.price = price;
      this.vegetarian = vegetarian;
      this.ingredients = ingredients;
    }

    public void Print()
    {
      Console.WriteLine(vegetarian ? $"Pizza {Capitalize(name)} (V) - {price}$" : $"Pizza {Capitalize(name)} - {price}$");
      PrintIngredient();
      Console.WriteLine();
    }

    private void PrintIngredient()
    {
      if (ingredients == null)
      {
        Console.WriteLine("  - Ingredients not found -");
      }
      else
      {
        Console.Write($"  Ingredients: -{string.Join(" .", CapitalizeList(ingredients))}");
        Console.WriteLine();
      }
    }

    protected static string Capitalize(string s)
    {
      if (string.IsNullOrEmpty(s))
        return s;

      string name = s[0].ToString().ToUpper() + s[1..].ToLower();
      return name;
    }

    private static List<string> CapitalizeList(List<string> s)
    {
      return s.Select(i => Capitalize(i)).ToList();
    }
  }

  public class Program
  {
    static void OrderByUpper(List<Pizza> pizzas)
    {
      pizzas = pizzas.OrderBy(x => x.price).ToList();

      foreach(var pizza in pizzas)
      {
        pizza.Print();
      }
    }

    static void OrderByLower(List<Pizza> pizzas)
    {
      pizzas = pizzas.OrderByDescending(x => x.price).ToList();

      foreach(var pizza in pizzas)
      {
        pizza.Print();
      }
    }

    static List<Pizza> GetData(string pathAndFile)
    {
      string json = "";

      try
      {
        json = File.ReadAllText(pathAndFile);
      }
      catch (Exception ex)
      {
        System.Console.WriteLine("Something went wrong: File not found.");

      }

      List<Pizza> pizzas = null;
      try
      {
        pizzas = JsonConvert.DeserializeObject<List<Pizza>>(json);
      }
      catch (System.Exception ex)
      {
        System.Console.WriteLine("Something went wrong: Data is not valid.");
      }
  
      return pizzas;
    }

    static void Generate(string path, string pathAndFile)
    {
      if (!Directory.Exists(path))
      {
        System.Console.WriteLine("Creating directory..");
        Directory.CreateDirectory(path);
      }

      if (File.Exists(pathAndFile))
      {
        System.Console.WriteLine("File already exist. Replacing..");
      }
      else
      {
        System.Console.WriteLine("Creating file.");
      }

      List<Pizza> pizzas = new()
      {
        new Pizza("Margherita", 8, true, new List<string>(){"TomaTo sauce", "mozZarella", "Parmigiano RegGiano", "BasilIc"}),
        new Pizza("Meat", 12.5f, false),
        new Pizza("ChEese", 11.5f, true, new List<string>(){"Cream", "monteRey Jack", "Parmigiano REggiano", "AsiAgo"}),
        new Pizza("bBQ Chicken", 12.5f, false),
        new Pizza("VegGie", 9, true),
        new Pizza("La Marie-Anne", 14, false, new List<string>(){"Cream", "Pancetta", "Parmigiano REggiano", "Egg", "Dry tomatoes"}),
/*         new Personalized(),
        new Personalized() */
      };

      string json = JsonConvert.SerializeObject(pizzas);

      using (var writeStream = File.CreateText(pathAndFile))
      {
        writeStream.Write(json);
      }
    }

    static List<Pizza> GenerateFromUrl()
    {
      string url = "https://codeavecjonathan.com/res/pizzas2.json";
      WebClient client = new WebClient();

      string res = "";
      try
      {
        res = client.DownloadString(url);
      }
      catch (System.Exception ex)
      {
        System.Console.WriteLine("Something went wrong: Url not valid.");
      }

      List<Pizza> pizzas = null;
      try
      {
        pizzas = JsonConvert.DeserializeObject<List<Pizza>>(res);
      }
      catch (System.Exception ex)
      {
        System.Console.WriteLine("Something went wrong: Date is not valid.");
      }

      return pizzas;
    }
    static void Main(string[] args)
    {
      string path = "assets";
      string filename = "pizzas.json";
      string pathAndFile = Path.Combine(path, filename);

      /* Generate(path, pathAndFile); */
      List<Pizza> pizzas = GetData(pathAndFile);
      List<Pizza> pizzasUrl = GenerateFromUrl();

      foreach( Pizza pizza in pizzas)
      {
        pizza.Print();
      }

      foreach( Pizza pizza in pizzasUrl)
      {
        pizza.Print();
      }
    }
  }
}