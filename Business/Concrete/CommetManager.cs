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
    public class CommetManager : ICommentService
    {
        public IResult Add(Comment comment)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int commentId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Comment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
