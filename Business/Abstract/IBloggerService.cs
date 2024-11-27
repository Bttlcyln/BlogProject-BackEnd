using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBloggerService
    {
        IDataResult<List<Blogger>> GetAll();
        IResult Add(Blogger blogger);
        IResult Update(Blogger blogger);
        IResult Delete(int bloggerId);
        
    }
}
