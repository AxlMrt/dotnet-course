namespace SuperHeroApi.Services.SuperHeroService
{
  public interface ISuperHeroService
  {
    List<SuperHero> GetAllHeroes();
    SuperHero GetSingleHero(int id);
    List<SuperHero> AddHero(SuperHero hero);
    List<SuperHero> UpdateHero(int id, SuperHero req);
    List<SuperHero> DeleteHero(int id);
  }
}