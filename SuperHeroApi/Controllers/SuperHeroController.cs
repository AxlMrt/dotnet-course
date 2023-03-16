using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Services.SuperHeroService;

namespace SuperHeroApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SuperHeroController : ControllerBase
  {
    private readonly ISuperHeroService _superHeroService;
    public SuperHeroController(ISuperHeroService superHeroService)
    {
      _superHeroService = superHeroService;
    }
    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> GetAllHero()
    {
      return _superHeroService.GetAllHeroes();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
    {
      var result = _superHeroService.GetSingleHero(id);
      if (result is null)
        return NotFound("Hero not found.");
      return result;
    }
    
    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
    {
      return _superHeroService.AddHero(hero);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero req)
    {
      var result = _superHeroService.UpdateHero(id, req);
      if (result is null)
        return NotFound("Hero not found.");

      return result;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
    {
      var result = _superHeroService.DeleteHero(id);
      if (result is null)
        return NotFound("Hero not found.");

      return result;
    }
  }
}