using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPostService
    {
        IDataResult<List<Post>> GetAll();
        IDataResult<List<PostDetailDto>> GetPostDetail();
        IResult Add(AddPostRequest request);
        IResult Update(UpdatePostRequest request);
        IResult Delete(int postId);
    }
}
