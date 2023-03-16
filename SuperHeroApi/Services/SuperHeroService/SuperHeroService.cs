namespace SuperHeroApi.Services.SuperHeroService
{
  public class SuperHeroService : ISuperHeroService
  {
    private List<SuperHero> superHeroes = new List<SuperHero> {
      new SuperHero
      {
        Id = 1,
        Name = "Spider Man",
        FirstName = "Peter",
        LastName = "Parker",
        Place = "New York City"
      },
      new SuperHero
      {
        Id = 2,
        Name = "Iron Man",
        FirstName = "Tony",
        LastName = "Stark",
        Place = "Malibu"
      }
    };

    public List<SuperHero> AddHero(SuperHero hero)
    {
      superHeroes.Add(hero);
      return superHeroes;
    }

    public List<SuperHero> UpdateHero(int id, SuperHero req)
    {
      var hero = superHeroes.Find(x => x.Id == id);
      if (hero is null)
        return null;

      hero.Name = req.Name;
      hero.FirstName = req.FirstName;
      hero.LastName = req.LastName;
      hero.Place = req.Place;

      return superHeroes;
    }

    public List<SuperHero> GetAllHeroes()
    {
      return superHeroes;
    }

    public SuperHero GetSingleHero(int id)
    {
      var hero = superHeroes.Find(x => x.Id == id);
      if (hero is null)
        return null;

      return hero;
    }

    public List<SuperHero> DeleteHero(int id)
    {
      var hero = superHeroes.Find(x => x.Id == id);
      if (hero is null)
        return null;

      superHeroes.Remove(hero);
      return superHeroes;
    }
  }
}