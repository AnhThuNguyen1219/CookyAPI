using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.UserEntity;
using CookyAPI.Model.Entities.FoodEntity;



namespace CookyAPI.Services
{
    public class UsersService : IUsersService
    {
        private DataContext _context;
        public UsersService(DataContext context)
        {
            _context = context;
        }
        public List<User> GetUsers()
        {
           // var users = new List<User>();
          //  users = _context.Users.All(x=>x.Food).ToList();
           //return users;
           var users =  _context.Users.OrderBy(u=>u.Id).Select(u => new User
           {
               Id = u.Id,
               Name = u.Name,
               EMail = u.EMail,
               Password = null,
               Food = u.Food.Select(f=>new Food{
                   Id = f.Id,
                   FoodName = f.FoodName,
                  // User = f.User
               }).ToList()
           }).ToList();
           return users;
        }

        public User GetUserById(int id)
        {
            var user =  _context.Users.Where(u=>u.Id == id).Select(u => new User
           {
               Id = u.Id,
               Name = u.Name,
               EMail = u.EMail,
               Password = null,
               Food = u.Food.Select(f=>new Food{
                   Id = f.Id,
                   FoodName = f.FoodName,
                  // User = f.User
               }).ToList()
           }).SingleOrDefault();
            
           return user;
        }
        public void UpdateUser(int id,User user)
        {
            var oldUser = new User();
            oldUser = _context.Users.FirstOrDefault(x=>x.Id==id);
            oldUser.Name = user.Name;
            oldUser.EMail = user.EMail;
            oldUser.Avatar = user.Avatar;
            // foreach (var userFood in user.Food.ToList())
            // {
            //     foreach (var oldFood in oldUser.Food.ToList())
            //     {
            //         if(userFood.FoodName.Equals(oldFood.FoodName)==false)oldUser.Food.Add(userFood);
            //     }
                
            // }
            
            _context.SaveChanges();
        }
        public void DelUser(int id)
        {
             var user = new User();
            user = _context.Users.Where(x=>x.Id==id).SingleOrDefault();
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            if(user.Food.ToList()!=null){
                foreach (var item in user.Food.ToList())
                {
                    _context.Foods.Add(item);
                    user.Food.Add(item);
                }
            
            }
            _context.SaveChanges();
        }

        public User GetLogin(Login user)
        {
            var users = _context.Users.FirstOrDefault(u=>u.Name==user.Name&&u.Password==user.Password);
            return users;
        }
    }
}