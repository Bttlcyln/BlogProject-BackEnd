using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.EntityFrameWorkDbContext;
using Entities.Concrete;
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
                              where comment.PostId == postId
                              select new CommentDetailDto
                              {
                                  Id = comment.Id,
                                  PostId = comment.PostId,
                                  Description = comment.Description,
                                  CreatedAt = comment.CreatedAt,
                                  IsActive = comment.IsActive,
                                  


                              });
                return result.ToList();
            }
        }
    }
}
