using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.FoodEntity;

namespace CookyAPI.Services.GerneService
{
    public class GerneService : IGerneService
    {
        DataContext _context;
        public GerneService(DataContext context)
        {
            _context = context;
        }
        public void AddGerne(Gerne ge)
        {
            _context.Gernes.Add(ge);
        }

        public void DelGerne(int id)
        {
            var ge = new Gerne();
            ge = _context.Gernes.Where(g=>g.Id == id).SingleOrDefault();
            _context.Gernes.Remove(ge);
            _context.SaveChanges();
        }

        public List<Gerne> GetGerne()
        {
            var listge = new List<Gerne>();
            listge = _context.Gernes.Select(ge => new Gerne 
            {
                Id = ge.Id,
                GerneName = ge.GerneName

            }).ToList();
            return listge;
        }

        public Gerne GetGerneById(int id)
        {
            var ge = new Gerne();
            ge = _context.Gernes.Select(ger => new Gerne 
            {
                Id = ge.Id,
                GerneName = ge.GerneName

            }).Where(ger=>ger.Id ==id).SingleOrDefault();
            return ge;
        }

        public void UpdateGerne(int id, Gerne ge)
        {
            var oldGe = _context.Gernes.Where(ger=>ger.Id==id).SingleOrDefault();
            oldGe.GerneName = ge.GerneName;
            
            _context.SaveChanges();
        }

        

        
    }
}