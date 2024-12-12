using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostService : IPostService
    {
        private readonly IPostDal _postDal;

        public PostService(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public IResult Add(AddPostRequest request)
        {
            Post postEntity = new Post()
            {
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = request.UserId,
                Content = request.Content,
            };
            _postDal.Add(postEntity);
            return new SuccessResult(Messages.PostAdded);
        }

        public IResult Delete(int postId)
        {
            Post post = _postDal.Get(p => p.Id ==postId);
            _postDal.Delete(post);
            return new SuccessResult(Messages.PostDeleted);
        }
        public IDataResult<List<Post>> GetAll()
        {
            return new SuccessDataResult<List<Post>>(_postDal.GetAll(), Messages.PostListed);
        }

        public IDataResult<List<PostDetailDto>> GetPostDetail()
        {
            return new SuccessDataResult<List<PostDetailDto>>(_postDal.GetPostDetail());
        }

        public IResult Update(UpdatePostRequest request)
        {
            var post = _postDal.Get(p=> p.Id == request.Id);
            if (post is null)
            {
                return new ErrorResult();
            }
            post.Content = request.Content;
            post.UserId = request.UserId;
            _postDal.Update(post);
            return new SuccessResult(Messages.PostUpdated);
        }
    }
}
