using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.EntityFrameWorkDbContext;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPostDal : EfEntityRepositoryBase<Post, AppDbContext>, IPostDal
    {
        public List<PostDetailDto> GetPostDetail()
        {
           using (AppDbContext context = new AppDbContext())
            {
                var result = from post in context.Posts
                             join user in context.Users on post.Id equals user.Id into userLeftJoin
                             from user in userLeftJoin.DefaultIfEmpty()
                             select new PostDetailDto
                             {
                                 Id = post.Id,
                                 Content = post.Content,
                                 CreatedAt = post.CreatedAt,
                                 IsActive = post.IsActive,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 CommentCount = (context.Comments.Count(c=>c.PostId == post.Id))
                             };
                return result.ToList();
            }
        }
    }
}

