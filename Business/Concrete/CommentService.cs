using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Comment;
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

        public CommentService(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IResult Add(AddCommentRequest request)
        {
            Comment commentyEntity = new Comment()
            {
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = request.UserId,
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
