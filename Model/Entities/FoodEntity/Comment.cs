using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.UserEntity;

namespace CookyAPI.Model.Entities.FoodEntity
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
        public Food Food {get; set;}
    }
}