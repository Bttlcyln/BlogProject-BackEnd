using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Like;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILikeService
    {
        IDataResult<List<Like>> GetAll();
        IResult Add(AddLikeRequest request);
        IResult Update(Like like);
        IResult Delete(int likeId);
    }
}
