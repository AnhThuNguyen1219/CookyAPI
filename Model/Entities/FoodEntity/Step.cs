using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CookyAPI.Model.Entities.FoodEntity
{
    public class Step
    {
        public int Id { get; set; }
        public int No{get;set;}
        public string Content { get; set; }
        public string Image { get; set; }
        public Food Food{get;set;}
    }
}