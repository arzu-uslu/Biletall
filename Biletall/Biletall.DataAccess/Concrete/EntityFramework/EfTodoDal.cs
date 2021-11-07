using Biletall.DataAccess.Abstract;
using Biletall.Entities.Concrete;

namespace Biletall.DataAccess.Concrete.EntityFramework
{
    public class EfTodoDal : EfEntityRepositoryBase<Todo, TodoSampleContext>, ITodoDal
    {
    }
}
