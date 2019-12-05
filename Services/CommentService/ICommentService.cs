using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.FoodEntity;

namespace CookyAPI.Services.CommentService
{
    public interface ICommentService
    {
        List<Comment> GetComments(int FoodId);
        void AddComment(Comment com);
        void UpdateComment(int Id, Comment comment);
        void DelComment(int Id);
    }
}