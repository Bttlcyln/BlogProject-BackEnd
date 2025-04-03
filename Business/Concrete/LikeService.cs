using Business.Abstract;
using Business.Constants;
using Core.Extensions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Like;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LikeService : ILikeService
    {
        private readonly ILikeDal _likeDal;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPostDal _postDal;

        public LikeService(ILikeDal likeDal,IHttpContextAccessor httpContextAccessor, IPostDal postDal)
        {
            _likeDal = likeDal;
            _httpContextAccessor = httpContextAccessor;
            _postDal = postDal;
        }

        public IResult Add(AddLikeRequest request)
        {
            int userId = _httpContextAccessor.GetUserId();
            Like likeEntity = new Like()
            {
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                PostId = request.PostId,
                UserId = userId,

                //CreatedAt = DateTime.Now,
                //IsActive = true,
                //PostId = request.PostId,
                //UserId = request.UserId, // bu şekilde alınmıyordu!!!!!!!!!!!!!!!!!!!!!!!!!
            };
            _likeDal.Add(likeEntity);
            return new SuccessResult();
        }

        public IResult Delete(int postId)
        {
            // likeId ye göre değil, userId ve postId ye göre bulmalısın
            // yani postId alınacak request olarak. UserId zaten elimizde vardı hatırlarsan (!) 
            Like like = _likeDal.Get(l => l.Id == postId);
            _likeDal.Delete(like);
            return new SuccessResult(Messages.LikeDeleted);
            
            //Like like = _likeDal.Get(l => l.Id == likeId);
            //_likeDal.Delete(like);
            //return new SuccessResult();
        }

        public IDataResult<List<Like>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Like like)
        {
            throw new NotImplementedException();
        }
    }
}
