using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.FoodEntity;

namespace CookyAPI.Services.GerneService
{
    public interface IGerneService
    {
        void AddGerne(Gerne ge);
        void DelGerne(int id);
        void UpdateGerne(int id, Gerne ge);
        List<Gerne> GetGerne();
        Gerne GetGerneById(int id);


    }
}