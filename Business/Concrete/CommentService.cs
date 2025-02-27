using Business.Abstract;
using Business.Constants;
using Core.Extensions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Comment;
using Entities.DTOs.Post;
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
        private readonly IPostDal _postDal;
        private readonly INotificationDal _notificationDal;

        public CommentService(ICommentDal commentDal, IHttpContextAccessor httpContextAccessor, IPostDal postDal, INotificationDal notificationDal)
        {
            _commentDal = commentDal;
            _httpcontextAccessor = httpContextAccessor;
            _postDal = postDal;
            _notificationDal = notificationDal;
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
          
            var post = _postDal.Get(p => p.Id == request.PostId);
            if (post == null)
            {
                return new Result(false, "Gönderi bulunamadı.");
            }
         
            int postId = post.UserId;

            
            Notification notification = new Notification()
            {
                UserId = postId,
                CreatedAt = DateTime.UtcNow,
                IsRead = false,
                Title = $"{post.Content} başlıklı gönderine bir yorum geldi."
            };

            _notificationDal.Add(notification);

            return new Result(true, "Yorum eklendi ve bildirim gönderildi.");
        }
        // requestten gelen postId ye ait olan post tablosundaki kaydı çek
        // çektiğin kayıtta UserId yi kullanarak yeni bir notification kaydı oluştur
        // bu kayıdın description kısmına "…başlıklı gönderine bir yorum geldi" olacak şekilde açıklama yaz
        // notification'ı kaydet

        public IResult Delete(int commentId)
        {
            Comment comment = _commentDal.Get(c => c.Id == commentId);
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.CommentDeleted);
        }

        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(),Messages.CommentListed);
        }

        public IDataResult<List<CommentDetailDto>>GetCommentByPostId(int postId)
        {
            return new SuccessDataResult<List<CommentDetailDto>>(_commentDal.GetCommentById(postId));
        }

        public IDataResult<List<CommentDetailDto>> GetCommentDetail()
        {
            return new SuccessDataResult<List<CommentDetailDto>>(_commentDal.GetCommentDetail());
        }

        public IResult Update(UpdateCommentRequest request)
        {
            var comment = _commentDal.Get(c => c.Id == request.Id);
            if (comment is null)
            {
                return new ErrorResult();
            }
            comment.UserId = request.UserId;
            comment.PostId = request.PostId;
            comment.Description = request.Description;
           _commentDal.Update(comment);
            return new SuccessResult(Messages.CommentUpdated);
        }

       
    }
}
