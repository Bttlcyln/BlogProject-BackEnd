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
    public class BloggerManager : IBloggerService
    {
        public IResult Add(Blogger blogger)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int bloggerId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Blogger>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Blogger blogger)
        {
            throw new NotImplementedException();
        }
    }
}
