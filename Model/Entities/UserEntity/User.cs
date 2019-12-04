using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.FoodEntity;
namespace CookyAPI.Model.Entities.UserEntity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Password{get;set;}
        public string Avatar { get; set; }
        public int Role { get; set; }
        public ICollection<Food> Food{get;set;}  
    }
}