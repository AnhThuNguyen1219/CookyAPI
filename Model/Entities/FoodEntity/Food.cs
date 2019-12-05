using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.UserEntity;
namespace CookyAPI.Model.Entities.FoodEntity
{
    public class Food
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public string Material { get; set; }
        public string PrepareTime { get; set; }
        public string CookTime { get; set; }
        public string Image{get;set;}
        public User User { get; set; }
        public Gerne Gerne{get; set;}
        public ICollection<Step> Step {get;set;}   
        public ICollection<Comment> Comment{get;set;}
    }
}