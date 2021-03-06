using System.Collections.Generic;
using PlatformService.Models;
using System.Linq;
using System;

namespace PlatformService.Data
{
  public class PlatformRepo : IPlatformRepo
  {
    //Start Dependency Injection
    private readonly AppDbContext _context;

    public PlatformRepo(AppDbContext context)
    {
      _context = context ;
    }
    //End Dependency Injection

    public void CreatePlatform(Platform plat)
    {
      if(plat == null)
      {
        throw new ArgumentNullException(nameof(plat));
      }

      _context.Platforms.Add(plat);
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
      return _context.Platforms.ToList();
    }

    public Platform GetPlatformById(int id)
    {
      return _context.Platforms.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

  }
}
