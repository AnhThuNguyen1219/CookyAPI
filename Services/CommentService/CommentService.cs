using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.FoodEntity;
using CookyAPI.Model.Entities.UserEntity;

namespace CookyAPI.Services.CommentService
{
    public class CommentService : ICommentService
    {
        DataContext _context;
        public CommentService(DataContext context)
        {
            _context = context;
        }
        public void AddComment(Comment com)
        {
            _context.Comments.Add(com);
            var user = _context.Users.Where(f=>f.Id==com.User.Id).SingleOrDefault(); 
            user.Comment.Add(com);
            var food = _context.Foods.Where(f=>f.Id == com.Food.Id).SingleOrDefault();
            food.Comment.Add(com);
            _context.SaveChanges();
        }

        public void DelComment(int Id)
        {
            var com = _context.Comments.Where(c=>c.Id==Id).SingleOrDefault();
            _context.Comments.Remove(com);
        }

        public List<Comment> GetComments(int FoodId)
        {
            var listCom = _context.Comments.Where(f=>f.Food.Id==FoodId).Select(c=>
            new Comment{
                Content = c.Content,
                User = new User
                {
                    Id = c.User.Id,
                    Name = c.User.Name
                }
            }).ToList();
            return listCom;
        }

        public void UpdateComment(int Id, Comment comment)
        {
            var com = _context.Comments.Where(c=>c.Id == Id).SingleOrDefault();
            com.Content = comment.Content;
            _context.SaveChanges();
        }
    }
}