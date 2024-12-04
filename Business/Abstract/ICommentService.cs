using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IDataResult<List<Comment>> GetAll();
        IResult Add(AddCommentRequest request);
        IResult Update(UpdateCommentRequest request);
        IResult Delete(int commentId);
        
    }
}
