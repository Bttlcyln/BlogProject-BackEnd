using Business.Abstract;
using Business.Constants;
using Core.Extensions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Comment;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly ICommentDal _commentDal;
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public CommentService(ICommentDal commentDal, IHttpContextAccessor httpContextAccessor)
        {
            _commentDal = commentDal;
            _httpcontextAccessor = httpContextAccessor;
        }

        public IResult Add(AddCommentRequest request)
        {
            int userId = _httpcontextAccessor.GetUserId();

            Comment commentyEntity = new Comment()
            {
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = userId,
                PostId = request.PostId,
                Description = request.Description,
            };

            _commentDal.Add(commentyEntity);
            return new Result(true,"");
        }

        public IResult Delete(int commentId)
        {
            Comment comment = _commentDal.Get(c => c.Id == commentId);
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.CommentDeleted);
        }

        public IDataResult<List<Comment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(UpdateCommentRequest request)
        {
            var comment = _commentDal.Get(c => c.Id == request.Id);
            if (comment is null)
            {
                return new ErrorResult();
            }
            comment.UserId = request.USerId;
            comment.PostId = request.PostId;
            comment.Description = request.Description;
           _commentDal.Update(comment);
            return new SuccessResult(Messages.CommentUpdated);
        }
    }
}
