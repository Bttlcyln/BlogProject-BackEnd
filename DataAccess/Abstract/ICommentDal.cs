using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICommentDal : IEntityRepository<Comment>
    {
       List<CommentDetailDto> GetCommentById(int postId);
        List<CommentDetailDto> GetCommentDetail();
    }
}
