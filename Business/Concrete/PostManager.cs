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
    public class PostManager : IPostService
    {
        public IResult Add(Post post)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int postId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Post>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
