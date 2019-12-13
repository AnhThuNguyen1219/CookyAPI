using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookyAPI.Model.Entities.FoodEntity
{
    public class Gerne
    {
        public int Id { get; set; }
        public string GerneName { get; set; }
        public ICollection<Food> Food { get; set; }

    }
}