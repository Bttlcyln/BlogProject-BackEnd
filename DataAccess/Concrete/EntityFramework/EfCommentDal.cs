using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.EntityFrameWorkDbContext;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCommentDal : EfEntityRepositoryBase<Comment, AppDbContext>, ICommentDal
    {
        public List<CommentDetailDto> GetCommentById(int postId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = (from comment in context.Comments
                              join user in context.Users on comment.UserId equals user.Id into userLeftJoin
                              from user in userLeftJoin.DefaultIfEmpty()
                              where comment.PostId == postId
                              orderby comment.CreatedAt descending
                              select new CommentDetailDto
                              {
                                  Id = comment.Id,
                                  UserId = comment.UserId,
                                  PostId = comment.PostId,
                                  Description = comment.Description,
                                  CreatedAt = comment.CreatedAt,
                                  IsActive = comment.IsActive,
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                              });
                return result.ToList();
            }
        }

        public List<CommentDetailDto> GetCommentDetail()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = from comment in context.Comments
                             join user in context.Users on comment.Id equals user.Id into userLeftJoin
                             from user in userLeftJoin.DefaultIfEmpty()
                             select new CommentDetailDto
                             {
                                 Id = comment.Id,
                                 PostId = comment.PostId,
                                 Description = comment.Description,
                                 CreatedAt = comment.CreatedAt,
                                 IsActive = comment.IsActive,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 
                             };
                return result.ToList();
            }
        }
    }
}
