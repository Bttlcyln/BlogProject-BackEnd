using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Like;
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

        public LikeService(ILikeDal likeDal)
        {
            _likeDal = likeDal;
        }

        public IResult Add(AddLikeRequest request)
        {
            Like likeEntity = new Like()
            {
                CreatedAt = DateTime.Now,
                IsActive = true,
                PostId = request.PostId,
                UserId = request.UserId,
            };
            _likeDal.Add(likeEntity);
            return new SuccessResult();
        }

        public IResult Delete(int likeId)
        {
            Like like = _likeDal.Get(l => l.Id == likeId);
            _likeDal.Delete(like);
            return new SuccessResult();
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
