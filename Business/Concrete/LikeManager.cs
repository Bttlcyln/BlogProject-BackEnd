using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LikeManager : ILikeService
    {
        public IResult Add(Like like)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int likeId)
        {
            throw new NotImplementedException();
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
